SET WORKSPACE=%~dp0
SET SOURCETABLEDIR=%~dp0/../../../PaiLogic_Res/Tables/Sources/
SET TABLERESDIR=%~dp0/../../UnityProject/PaiLogic/Assets/StreamingAssets/config/

cd %WORKSPACE%
%~dp0/convertxlsx.exe -i %SOURCETABLEDIR% -o %TABLERESDIR%

pause