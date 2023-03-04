![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")
# Sitecore Hackathon 2023

- MUST READ: **[Submission requirements](SUBMISSION_REQUIREMENTS.md)**
- [Entry form template](ENTRYFORM.md)
  
# Hackathon Submission Entry form

> __Important__  
> 
> Copy and paste the content of this file into README.md or face automatic __disqualification__  
> All headlines and subheadlines shall be retained if not noted otherwise.  
> Fill in text in each section as instructed and then delete the existing text, including this blockquote.

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

## Team name
Soar With Sitecore

## Category
Best Migration Module to move from XP (traditional) to XM Cloud/Content Hub One/Headless CMS

## Description
The purpose of the "Scriban To React" module is to make the migration from XP to Headless easier.
This module will allow the end user to select a scriban rendering of their choice and have it 
automatically convereted to a TypeScript (tsx) file.  

⟹ Write a clear description of your hackathon entry.  

  - Module Purpose
  - What problem was solved (if any)
    - How does this module solve it

_You can alternately paste a [link here](#docs) to a document within this repo containing the description._

## Video link
⟹ Provide a video highlighing your Hackathon module submission and provide a link to the video. You can use any video hosting, file share or even upload the video to this repository. _Just remember to update the link below_

⟹ [Replace this Video link](#video-link)



## Pre-requisites and Dependencies

⟹ Does your module rely on other Sitecore modules or frameworks?

- List any dependencies
- Or other modules that must be installed
- Or services that must be enabled/configured

_Remove this subsection if your entry does not have any prerequisites other than Sitecore_

## Installation instructions
⟹ Write a short clear step-wise instruction on how to install your module.  

> _A simple well-described installation process is required to win the Hackathon._  
> Feel free to use any of the following tools/formats as part of the installation:
> - Sitecore Package files
> - Docker image builds
> - Sitecore CLI
> - msbuild
> - npm / yarn
> 
> _Do not use_
> - TDS
> - Unicorn
 
for example:

1. Use the Sitecore Installation wizard to install the [package](#link-to-package)
2. ...
3. profit

### Configuration
⟹ If there are any custom configuration that has to be set manually then remember to add all details here.

_Remove this subsection if your entry does not require any configuration that is not fully covered in the installation instructions already_

## Usage instructions

1. Select any item within an SXA Site node in the Content Tree.
![Content Tree](docs/images/fig1-content-tree.PNG?raw=true "Content Tree")

2. Right click and select Scripts > Export Scriban Template.
![Content Tree](docs/images/fig2-run-script.PNG?raw=true "Content Tree")

3. A modal will pop up, prompting for a selection of a Scriban Template from the Rendering Variants folder within that context site.
![Content Tree](docs/images/fig3-export-modal.PNG?raw=true "Content Tree")

4. Navigate to the Scriban Template to Export and click OK.
![Content Tree](docs/images/fig4-export-modal-2.PNG?raw=true "Content Tree")

5. If the selected item is not a Scriban Template, an "Invalid Selection..." message will be shown and the prompt will ask to make another selection.
![Content Tree](docs/images/fig5-invalid-selection.PNG?raw=true "Content Tree")

6. When the eport is complete a Success message will be shown and the output React .tsx file will be downloaded.
![Content Tree](docs/images/fig6-success.PNG?raw=true "Content Tree")

## Comments
If you'd like to make additional comments that is important for your module entry.

