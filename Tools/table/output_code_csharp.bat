SET WORKSPACE=%~dp0
SET SOURCETABLEDIR=%~dp0/../../../PaiLogic_Res/Tables/Sources/
SET PROJECTTABLEDIR=%~dp0/../../UnityProject/PaiLogic/Assets/Scripts/Game/Tables/

cd %WORKSPACE%
%~dp0/outputcode -i %SOURCETABLEDIR% -o %PROJECTTABLEDIR%

pause