using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Feature.ScribanToReact.Models;
using System.Text.Json;

namespace Feature.ScribanToReact
{
    public class ScribanToReact
    {
        public static string CreateReactComponent(string componentName, string scribanContent)
        {
            var propertiesDictionary = GetDictionaryOfProperties(scribanContent);
            var reactTemplate = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\react templates\\tsx-template.txt");

            if (ModifyReactTemplate(reactTemplate, propertiesDictionary, componentName, scribanContent, out string modifiedReactTemplate))
            {
                return modifiedReactTemplate;
            }

            return string.Empty;
        }

        private static Dictionary<string, string> GetDictionaryOfProperties(string scribanContent)
        {
            var scribanMatch = Regex.Match(scribanContent, @"\{\{(.+?)\}\}");
            var arrayOfScribanSnippets = new List<string>();
            var propertiesDictionary = new Dictionary<string, string>();

            while (scribanMatch.Success)
            {
                arrayOfScribanSnippets.Add(scribanMatch.Value);
                scribanMatch = scribanMatch.NextMatch();
            }

            foreach (var snippet in arrayOfScribanSnippets)
            {
                var property = FindFieldNameFromScriban(snippet);

                if (property != null)
                    propertiesDictionary.Add(snippet, property);
            }

            return propertiesDictionary;
        }

        private static bool ModifyReactTemplate(string reactTemplate, Dictionary<string, string> propertiesDictionary, string componentName, string scribanContent, out string modifiedReactTemplate)
        {
            modifiedReactTemplate = reactTemplate;
            var fieldsConfiguration = new FieldsModel();

            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Feature.ScribanToReact.json"))
            {
                string json = r.ReadToEnd();
                fieldsConfiguration = JsonSerializer.Deserialize<FieldsModel>(json);
            }

            var replacementStatus = AddComponentFieldsToReactTemplate(ref modifiedReactTemplate, fieldsConfiguration, propertiesDictionary);

            if (replacementStatus)
            {
                replacementStatus = AddComponentNameToReactTemplate(ref modifiedReactTemplate, componentName);
            }
            if (replacementStatus)
            {
                replacementStatus = AddComponentMarkupToReactTemplate(ref modifiedReactTemplate, scribanContent, fieldsConfiguration, propertiesDictionary);
            }

            return replacementStatus;
        }

        private static bool AddComponentFieldsToReactTemplate(ref string reactTemplate, FieldsModel fieldsConfiguration, Dictionary<string, string> propertiesDictionary)
        {
            var componentFieldsToken = "[[componentFields]]";
            string componentFieldsReplacement = string.Empty;

            foreach (var record in propertiesDictionary)
            {
                var selectedField = fieldsConfiguration.Fields.Where(x => x.Name == record.Value).FirstOrDefault();
                var componentField = $"{selectedField.Name}: {selectedField.Field}";

                componentFieldsReplacement += componentField + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(componentFieldsReplacement))
            {
                reactTemplate = reactTemplate.Replace(componentFieldsToken, componentFieldsReplacement);

                return true;
            }

            return false;
        }

        private static bool AddComponentNameToReactTemplate(ref string reactTemplate, string componentName)
        {
            var componentNameToken = "[[componentName]]";

            if (reactTemplate.Contains(componentNameToken))
            {
                reactTemplate = reactTemplate.Replace(componentNameToken, componentName);
                return true;
            }

            return false;
        }


        private static bool AddComponentMarkupToReactTemplate(ref string reactTemplate, string scribanContent, FieldsModel fieldsConfiguration, Dictionary<string, string> propertiesDictionary)
        {
            var componentMarkupToken = "[[componentMarkup]]";
            string componentMarkupReplacement = scribanContent;

            foreach (var record in propertiesDictionary)
            {
                var selectedField = fieldsConfiguration.Fields.Where(x => x.Name == record.Value).FirstOrDefault();
                var componentMarkup = $"<{selectedField.Component} field={{props.fields.{selectedField.Name}}} />";

                componentMarkupReplacement = componentMarkupReplacement.Replace(record.Key, componentMarkup);
            }

            if (componentMarkupReplacement != scribanContent)
            {
                reactTemplate = reactTemplate.Replace(componentMarkupToken, componentMarkupReplacement);

                return true;
            }

            return false;
        }

        private static string FindFieldNameFromScriban(string scribanFieldReference)
        {
            // {{i_item.Copy}}
            if (scribanFieldReference.Contains("sc_field"))
            {
                var fieldName = Regex.Replace(scribanFieldReference, @"\{\{.*i_item\s*'", "");
                fieldName = Regex.Replace(fieldName, @"'\s*\}\}", "");

                return fieldName;
            }

            // {{ sc_field i_item 'PromoLink' }}
            if (scribanFieldReference.Contains("i_item"))
            {
                var fieldName = Regex.Replace(scribanFieldReference, @"\{\{\s*i_item\.", "");
                fieldName = Regex.Replace(fieldName, @"\s*\}\}", "");

                return fieldName;
            }

            return null;
        }
    }
}