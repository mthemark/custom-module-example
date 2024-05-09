#CreateDecisionsModule.ps1
#
#get CreateDecisionsModule tool
#dotnet tool update --global CreateDecisionsModule-GlobalTool
#
#set variables and update version const in module interface
$version = "1.0"
$projectName = "ConflictingReferencesExample"
#
$publishPath = '.\publish'
$modulesPath = '.\modules'
$moduleName = ("$projectName"+"v"+"$version")
$moduleInterfacePath = ".\Models\IDecisionsModule.cs"
$idm = Get-Content "$moduleInterfacePath" -Raw
$idm = ($idm -replace 'public const string Version = "\d+.\d+";', "public const string Version = ""$version"";").Trim()
Set-Content "$moduleInterfacePath" -Value $idm
#
#clean publish versioned module
Remove-Item ./publish -Force
dotnet publish .\$projectName.csproj /p:Version=$version -f net7.0 --runtime win-x64 --self-contained false --output "$publishPath" -c Debug
#
#create modules and CreateDecisionsModule config file
If(!(Test-Path -Path "$modulesPath"))
{
    New-Item -ItemType Directory -Path $modulesPath
}
$config = Get-Content -Raw CreateDecisionsModule.json | ConvertFrom-Json
$config.Resources.CoreServicesDlls = @("$publishPath\$projectName.dll")
$config.Version = $version
$config.Description = $moduleName
$json = ConvertTo-Json $config
Set-Content -Path "$modulesPath\$moduleName.json" -Value $json
#
#run CreateDecisionsModule
CreateDecisionsModule -buildmodule $moduleName -output "$modulesPath" -buildfile "$modulesPath\$moduleName.json"
