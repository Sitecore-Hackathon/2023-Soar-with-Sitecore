Import-Function Get-SiteItem

$sribanTemplate = "{8FCD3CFE-8B3B-423E-8176-6A7C72CB43FC}"

$rootNode = "/sitecore/content/"

$item = Get-Item .
$site =  Get-SiteItem $item

if ($site -ne $null) {
    $rootNode =$($site.ItemPath) + "/Presentation/Rendering Variants/"
}

$dialogProps = @{
    Parameters = @(
        @{ Name = "item"; Title="Scriban Template to export";Root="$($rootNode)"}
    )
    Title = "Export a Scriban Template"
    Description = "Choose a Scriban Template and export it to a React component for use in a Sitecore Headless site."
    Width = 500
    Height = 280
    OkButtonName = "OK"
    CancelButtonName = "Cancel"
}

$result = Read-Variable @dialogProps 

if($result -ne "ok") {
    Close-Window
    Exit
}

while ($item.TemplateID -ne $sribanTemplate) {
    
    $dialogProps = @{
        Parameters = @(
            @{ Name = "item"; Title="Scriban Template to export"; Root="$($rootNode)"}
        )
        Title = "Invalid Item - Choose a valid Scriban Template"
        Description = "Choose a Scriban Template and export it to a React component for use in a Sitecore Headless site."
        Width = 500
        Height = 280
        OkButtonName = "OK"
        CancelButtonName = "Cancel"
    }

    $result = Read-Variable @dialogProps 

    if($result -ne "ok") {
        Close-Window
        Exit
    }
}


$itemParentVariantDefinition = $item.Parent
$itemParentVariant = $itemParentVariantDefinition.Parent


$returnValue = [Feature.ScribanToReact.ScribanToReact]::CreateReactComponent($($itemParentVariant.Name), $item['Template'])

$returnValue | Out-Download -Name "$($itemParentVariant.Name)-$($itemParentVariantDefinition.Name).txt"