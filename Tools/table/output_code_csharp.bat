SET WORKSPACE=%~dp0
SET SOURCETABLEDIR=%~dp0/../../Tables/
SET PROJECTTABLEDIR=%~dp0/../../UnityProject/QarthDemo/Assets/Scripts/Game/Tables/

cd %WORKSPACE%
%~dp0/outputcode -i %SOURCETABLEDIR% -o %PROJECTTABLEDIR%

pause