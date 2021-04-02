;Compile32 /cc I:\Install\setup_tmp.iss <-自动编译文件
#define IncludeFramework true
#define IsExternal ""
#define SourceFileDir "<%SourceFileDir%>"
#define InstallFileDir "<%InstallFileDir%>"

[setup]
;应用程序名称
AppName=<%AppName%>
;repeat name of application. (otherwise you get
;multiple entries in add/remove programs)
AppVerName=<%AppVerName%>
;app publisher name
AppPublisher=EasyFound Co.,Ltd
;app publisher website URL
AppPublisherURL=http://www.easyfound.cn
;app publisher support URL
AppSupportURL=http://www.easyfound.cn
;app publisher updates URL
AppUpdatesURL=http://www.easyfound.cn
;default directory {pf} is a constant for
;program files. See INNO help for all constants
DefaultDirName={pf}\<%AppVerName%>
;default group name in the programs
; 开始菜单目录文字
DefaultGroupName=<%DefaultGroupName%>
; 是否让用户安装
DisableProgramGroupPage=yes
;Boolean to warn if directory user picks
;already exists
DirExistsWarning=no
;directory where uninstaller exe will be
;this will be where our app is
;the constant we use is {app}
UninstallFilesDir={app}
;执照文件;LicenseFile={#SourceFileDir}\eula.txt
;安装前文件;InfoBeforeFile={#SourceFileDir}\introduction.txt;安装后文件;InfoAfterFile={#SourceFileDir}\end.txt
;安装左侧logo
;WizardImageFile={#SourceFileDir}installlogo.bmp
;卸载ico
;I use whatever my apps icon is
UninstallDisplayIcon={app}\ExamSys.exe
;Version number of your installer (not your app)
VersionInfoVersion=1.0.0.0
;If IncludeFramework, append _FW to end of compiled setup;
;without the framework included
#if IncludeFramework
  OutputBaseFilename=<%OutputBaseFilenameFW%>
#else
  OutputBaseFilename=<%OutputBaseFilename%>
#endif
;Directory where setup.exe will be compiled to
OutputDir={#InstallFileDir}

[files]
Source: {#SourceFileDir}\ExamSys.exe;      DestDir: {app}; Flags: ignoreversion {#IsExternal}
source: {#SourceFileDir}\*;    DestDir: {app}; Flags: recursesubdirs {#IsExternal}

#if IncludeFramework
  Source: {#SourceFileDir}\dotnetfx.exe; DestDir: {tmp}; Flags: ignoreversion {#IsExternal} ; Check: NeedsFramework
#endif

[icons]
Name: {group}\<%GroupName%>;        Filename: {app}\ExamSys.exe; WorkingDir: {app}
Name: {group}\卸载 <%GroupName%>; Filename: {uninstallexe};  WorkingDir: {app}
Name: {userdesktop}\<%GroupName%>;  Filename: {app}\ExamSys.exe; WorkingDir: {app}

[Run]
#if IncludeFramework
  Filename: {tmp}\dotnetfx.exe; Parameters: "/q:a /c:""install /l /q"""; WorkingDir: {tmp}; Flags: skipifdoesntexist; StatusMsg: "Installing .NET Framework if needed"
#endif
Filename: {win}\Microsoft.NET\Framework\v2.0.50727\CasPol.exe; Parameters: "-q -machine -remgroup ""ExamSys"""; WorkingDir: {tmp}; Flags: skipifdoesntexist runhidden; StatusMsg: "Setting Program Access Permissions..."
Filename: {win}\Microsoft.NET\Framework\v2.0.50727\CasPol.exe; Parameters: "-q -machine -addgroup 1.2 -url ""file://{app}/*"" FullTrust -name ""ExamSys"""; WorkingDir: {tmp}; Flags: skipifdoesntexist runhidden; StatusMsg: "Setting Program Access Permissions..."

[UninstallRun]
Filename: {win}\Microsoft.NET\Framework\v2.0.50727\CasPol.exe; Parameters: "-q -machine -remgroup ""ExamSys"""; Flags: skipifdoesntexist runhidden;
[code]
// Indicates whether .NET Framework 2.0 is installed.
function IsDotNET20Detected(): boolean;
var
    success: boolean;
    install: cardinal;
begin
    success := RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v2.0.50727', 'Install', install);
    Result := success and (install = 1);
end;

//RETURNS OPPOSITE OF IsDotNet20Detected FUNCTION
//Remember this method from the Files section above
function NeedsFramework(): Boolean;
begin
  Result := (IsDotNET20Detected = false);
end;

//CHECKS TO SEE IF CLIENT MACHINE IS WINDOWS 95
function IsWin95 : boolean;
begin
  Result := (InstallOnThisVersion('4.0,0', '4.1.1998,0') = irInstall);
end;

//CHECKS TO SEE IF CLIENT MACHINE IS WINDOWS NT4
function IsWinNT : boolean;
begin
  Result := (InstallOnThisVersion('0,4.0.1381', '0,4.0.1381') = irInstall);
end;

//GETS VERSION OF IE INSTALLED ON CLIENT MACHINE
function GetIEVersion : String;
var
  IE_VER: String;
begin
  {First check if Internet Explorer is installed}
  if RegQueryStringValue(HKLM,'SOFTWARE\Microsoft\Internet Explorer','Version',IE_VER) then
      Result := IE_VER
else
    {No Internet Explorer at all}
    result := '';
end;

//GETS THE VERSION OF WINDOWS INSTALLER DLL
function GetMSIVersion(): String;
begin
    GetVersionNumbersString(GetSystemDir+'\msi.dll', Result);
end;

//LAUNCH DEFAULT BROWSER TO WINDOWS UPDATE WEBSITE
procedure GoToWindowsUpdate;
var
  ErrorCode: Integer;
begin
  if (MsgBox('Would you like to go to the Windows Update site now?' + chr(13) + chr(13) + '(Requires Internet Connection)'
            , mbConfirmation, MB_YESNO) = IDYES) then
      ShellExec('open', 'http://windowsupdate.microsoft.com','', '', SW_SHOW, ewNoWait, ErrorCode);
end;

//IF SETUP FINISHES WITH EXIT CODE OF 0, MEANING ALL WENT WELL
//THEN CHECK FOR THE PRESENCE OF THE REGISTRY FLAG TO INDICATE THE
//.NET FRAMEWORK WAS INSTALLED CORRECTLY
//IT CAN FAIL WHEN CUST DOESN'T HAVE CORRECT WINDOWS INSTALLER VERSION
function GetCustomSetupExitCode(): Integer;
begin
  if (IsDotNET20Detected = false) then
    begin
      MsgBox('.NET Framework was NOT installed successfully!',mbError, MB_OK);
      result := -1
    end
end;

function InitializeSetup: Boolean;
var
  Version: TWindowsVersion;
  IE_VER: String;
  MSI_VER: String;
  NL: Char;
  NL2: String;
begin

  NL := Chr(13);
  NL2 := NL + NL;

  // Get Version of Windows from API Call
  GetWindowsVersionEx(Version);

  // On Windows 2000, check for SP3

  if Version.NTPlatform and
     (Version.Major = 5) and
     (Version.Minor = 0) and
     (Version.ServicePackMajor < 3) then
  begin
    SuppressibleMsgBox('When running on Windows 2000, Service Pack 3 is required.' + NL +
                       'Visit' + NL2 +
                       ' *** http://windowsupdate.microsoft.com ***' + NL2 +
                       'to get the needed Windows Updates,' + NL +
                       'and then reinstall this program',
                        mbCriticalError, MB_OK, MB_OK);
    GoToWindowsUpdate;
    Result := False;
    Exit;
  end;

  // On Windows XP, check for SP2
  if Version.NTPlatform and
     (Version.Major = 5) and
     (Version.Minor = 1) and
     (Version.ServicePackMajor < 2) then
  begin
    SuppressibleMsgBox('When running on Windows XP, Service Pack 2 is required.' + NL +
                       'Visit' + NL2 + ' *** http://windowsupdate.microsoft.com ***' + NL2 +
                       'to get the needed Windows Updates,' + NL +
                       'and then reinstall this program',
                       mbCriticalError, MB_OK, MB_OK);
    GoToWindowsUpdate;
    Result := False;
    Exit;
  end;

  //IF WINDOWS 95 OR NT DON'T INSTALL
  if (IsWin95) or (IsWinNT) then
  begin
    SuppressibleMsgBox('This program can not run on Windows 95 or Windows NT.',
      mbCriticalError, MB_OK, MB_OK);
    Result := False;
    Exit;
  end;

  //CHECK MSI VER, NEEDS TO BE 3.0 ON ALL SUPPORTED SYSTEM EXCEPT 95/ME, WHICH NEEDS 2.0)
  MSI_VER := GetMSIVersion
  if ((Version.NTPlatform) and (MSI_VER < '3')) or ((Not Version.NTPlatform) and (MSI_VER < '2')) then
    begin
      SuppressibleMsgBox('You do not have all the required Windows Updates to install this program.' + NL +
                         'Visit *** http://windowsupdate.microsoft.com *** to get the needed Windows Updates,' + NL +
                         'and then reinstall this program',
                         mbCriticalError, MB_OK, MB_OK);
      GoToWindowsUpdate;
      Result := False;
      Exit;
  end;

  //CHECK THE IE VERSION (NEEDS TO BE 5.01+)
  IE_VER := GetIEVersion;
  if IE_VER < '5.01' then
    begin
      if IE_VER = '' then
        begin
          MsgBox('Microsoft Internet Explorer 5.01 or higher is required to run this program.' + NL2 +
                 'You do not currently have Microsoft Internet Explorer installed, or it is not working correctly.' + NL +
                 'Obtain a newer version at www.microsoft.com and then run setup again.', mbInformation, MB_OK);
        end
      else
        begin
          MsgBox('Microsoft Internet Explorer 5.01 or higher is required to run this program.' + NL2 +
                 'You are using version ' + IE_VER + '.' + NL2 +
                 'Obtain a newer version at www.microsoft.com and then run setup again.', mbInformation, MB_OK);
        end

      GoToWindowsUpdate;
      result := false;
      exit;
  end;

  //MAKE SURE USER HAS ADMIN RIGHTS BEFORE INSTALLING
  if IsAdminLoggedOn then
    begin
      result := true
        exit;
    end
  else
    begin
      MsgBox('You must have admin rights to perform this installation.' + NL +
             'Please log on with an account that has administrative rights,' + NL +
            'and run this installation again.', mbInformation, MB_OK);
        result := false;
    end
  end;
end.
