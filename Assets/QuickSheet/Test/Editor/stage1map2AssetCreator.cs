using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/stage1map2")]
    public static void Createstage1map2AssetFile()
    {
        stage1map2 asset = CustomAssetUtility.CreateAsset<stage1map2>();
        asset.SheetName = "Project_Conveyor";
        asset.WorksheetName = "stage1map2";
        EditorUtility.SetDirty(asset);        
    }
    
}