; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "IMAC"
#define MyAppVersion "1.0"
#define MyAppPublisher "World Sat do Brasil"
#define MyAppURL "https://www.worldsatdobrasil.com.br/"
#define MyAppExeName "IMAC.exe"
#define MyAppAssocName "World Sat File Type"
#define MyAppAssocExt ".wsb"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{9B586196-1F57-4A02-9C6F-259FF7AFC1DC}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
ChangesAssociations=yes
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=E:\Rodrigo\OneDrive\Documentos\Game_Dev\VisualStudio\IMAC\Output IMAC
OutputBaseFilename=Instalador IMAC
SetupIconFile=E:\Rodrigo\OneDrive\Documentos\Game_Dev\VisualStudio\IMAC\GPS_Icon_256x256.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "brazilianportuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "E:\Rodrigo\OneDrive\Documentos\Game_Dev\VisualStudio\IMAC\IMAC\bin\Release\net6.0-windows\publish\win-x64\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "IMAC\bin\Release\net6.0-windows\publish\win-x64\runtimes\*"; DestDir: "{app}\runtimes"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "E:\Rodrigo\OneDrive\Documentos\Game_Dev\VisualStudio\IMAC\IMAC\bin\Release\net6.0-windows\publish\win-x64\IMAC.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\Rodrigo\OneDrive\Documentos\Game_Dev\VisualStudio\IMAC\IMAC\bin\Release\net6.0-windows\publish\win-x64\WebView2Loader.dll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files
Source: "GPS_Icon_256x256.ico"; DestDir: "{app}"
Source: "GPS_Icon_128x128.png"; DestDir: "{app}"
Source: "SetParam.bat"; DestDir: "{app}"

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".myp"; ValueData: ""

[Run]
Filename: "{app}\{#MyAppExeName}"; Flags: nowait postinstall skipifsilent; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"
Filename: "{app}\SetParam.bat"

[InstallDelete]
Type: files; Name: "{app}\IMAC.exe"
Type: files; Name: "{app}\IMAC.runtimeconfig.json"
Type: files; Name: "{app}\unins000.exe"
Type: files; Name: "{app}\unins000.dat"
Type: files; Name: "{app}\IMAC.dll"
Type: files; Name: "{app}\windowsdesktop-runtime-7.0.5-win-x64.exe"
Type: files; Name: "{app}\windowsdesktop-runtime-6.0.19-win-x64.exe"

[Icons]
Name: "{group}\IMAC"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\GPS_Icon_256x256.ico"; IconIndex: 0

[UninstallDelete]
Type: files; Name: "{app}\*"
