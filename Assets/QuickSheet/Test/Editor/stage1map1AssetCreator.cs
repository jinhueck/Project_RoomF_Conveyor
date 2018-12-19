using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/stage1map1")]
    public static void Createstage1map1AssetFile()
    {
        stage1map1 asset = CustomAssetUtility.CreateAsset<stage1map1>();
        asset.SheetName = "Project_Conveyor";
        asset.WorksheetName = "stage1map1";
        EditorUtility.SetDirty(asset);        
    }
    
}