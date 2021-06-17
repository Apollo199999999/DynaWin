
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "DynaWin"
#define MyAppVersion "1.0.2"
#define MyAppPublisher "ClickPhase"
#define MyAppURL "https://clickphase.weebly.com/dynawin.html"
#define MyAppExeName "DynaWin.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{EC36A1B5-7473-4F76-9D82-61DB6249B906}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
DisableWelcomePage=no
DisableDirPage=no
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName=C:\Program Files (x86)\DynaWin
DisableProgramGroupPage=yes
LicenseFile=C:\Users\fligh\source\repos\DynaWin\LICENSE.txt
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=C:\Users\fligh\source\repos\DynaWin
OutputBaseFilename=DynaWin_1.0.2_Setup
SetupIconFile=C:\Users\fligh\source\repos\DynaWin\DynaWin\bin\Debug\Resources\icon.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern
VersionInfoVersion = 1.0.2
UninstallDisplayIcon={app}\DynaWin.exe
UninstallDisplayName=DynaWin

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: "C:\Users\fligh\source\repos\DynaWin\DynaWin\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs


[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"

