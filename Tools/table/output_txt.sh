WORKSPACE=$(cd `dirname $0`; pwd)
SOURCETABLEDIR=$WORKSPACE/../../Tables/
TABLERESDIR=$WORKSPACE/../../UnityProject/QarthDemo/Assets/StreamingAssets/config

cd $WORKSPACE
./convertxlsx -i $SOURCETABLEDIR -o $TABLERESDIR
