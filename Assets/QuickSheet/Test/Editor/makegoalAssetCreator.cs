using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/makegoal")]
    public static void CreatemakegoalAssetFile()
    {
        makegoal asset = CustomAssetUtility.CreateAsset<makegoal>();
        asset.SheetName = "Project_Conveyor";
        asset.WorksheetName = "makegoal";
        EditorUtility.SetDirty(asset);        
    }
    
}