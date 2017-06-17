WORKSPACE=$(cd `dirname $0`; pwd)
SOURCETABLEDIR=$WORKSPACE/../../../PaiLogic_Res/Tables/Sources/
TABLERESDIR=$WORKSPACE/../../UnityProject/PaiLogic/Assets/StreamingAssets/config

cd $WORKSPACE
./convertxlsx -i $SOURCETABLEDIR -o $TABLERESDIR
