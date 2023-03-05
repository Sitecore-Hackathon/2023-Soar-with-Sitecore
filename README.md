![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")
# Sitecore Hackathon 2023

## Team name
Soar With Sitecore

## Category
Best Migration Module to move from XP (traditional) to XM Cloud/Content Hub One/Headless CMS

## Description
The purpose of the "Scriban To React" module is to make the migration from XP to Headless easier.
This module will allow the end user to select a Rendering Variant's Scriban Template and have it 
automatically convereted to a TypeScript (tsx) file.  

## Video link
⟹ Provide a video highlighing your Hackathon module submission and provide a link to the video. You can use any video hosting, file share or even upload the video to this repository. _Just remember to update the link below_

⟹ [Replace this Video link](#video-link)

## Pre-requisites and Dependencies

- Sitecore XP
- SXA

## Installation instructions

In a Sitecore XP Instance
- Install the SXA module
- Using the package installation wizard, install the [Scriban Export module package](#sitecore_packages\2023 Hackathon - Headless Content-1.0.zip)
- Using the package installation wizard, install the [Demo site package](#sitecore_packages\Hackathon-Content-Package-1.0.zip)


## Usage instructions

1. Select any item within an SXA Site node in the Content Tree.   
![Content Tree](docs/images/fig1-content-tree.PNG?raw=true "Content Tree")

2. Right click and select Scripts > Export Scriban Template.    
![Run Script](docs/images/fig2-run-script.PNG?raw=true "Run Script")

3. A modal will pop up, prompting for a selection of a Scriban Template from the Rendering Variants folder within that context site.   
![Export Modal Screen 1](docs/images/fig3-export-modal.PNG?raw=true "Export Modal Screen 1")

4. Navigate to the Scriban Template to Export and click OK.   
![Export Modal Screen 2](docs/images/fig4-export-modal-2.PNG?raw=true "Export Modal Screen 2")

5. If the selected item is not a Scriban Template, an "Invalid Selection..." message will be shown and the prompt will ask to make another selection.   
![Invalid Selection Screen](docs/images/fig5-invalid-selection.PNG?raw=true "Invalid Selection Screen")

6. When the export is complete a Success message will be shown and the output React .tsx file will be downloaded.   
![Success Message](docs/images/fig6-success.PNG?raw=true "Success Message")

## Comments
Limitations: This export currently only translates simple examples of Scriban templates into React but could be extended to cover a larger set of fields and perhaps even decision statements. In it's current state it will translate Scriban field accessors that utilize .property notation {{ i_item.Title }} or sc_field functions {{ sc_field i_item "Image" }} and simple templates wihtout decision logic or other embedded functions.

### Contents of Demo site package
Root nodes:
- /sitecore/content/Hackathon
- /sitecore/Forms/Hackathon
- /sitecore/media library/Project/Hackathon
- /sitecore/templates/Project/Hackathon

### Contents of Scriban Export module package
- Feature.ScribanExport.dll
- System.Text.Json.dll
- Feature.ScribanToReact.json
- /React Templates/tsx - template.txt
- SPE.config
- items
- - /sitecore/system/Modules/PowerShell/Script Library/SXA/SXA - Scaffolding/Content Editor/Context Menu/Export Scriban Template