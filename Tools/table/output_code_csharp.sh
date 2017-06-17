WORKSPACE=$(cd `dirname $0`; pwd)
SOURCETABLEDIR=$WORKSPACE/../../../PaiLogic_Res/Tables/Sources/
PROJECTTABLEDIR=$WORKSPACE/../../UnityProject/PaiLogic/Assets/Scripts/Game/Tables/

cd $WORKSPACE
./outputcode -i $SOURCETABLEDIR -o $PROJECTTABLEDIR