using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/stage2")]
    public static void Createstage2AssetFile()
    {
        stage2 asset = CustomAssetUtility.CreateAsset<stage2>();
        asset.SheetName = "Project_Conveyor";
        asset.WorksheetName = "stage2";
        EditorUtility.SetDirty(asset);        
    }
    
}