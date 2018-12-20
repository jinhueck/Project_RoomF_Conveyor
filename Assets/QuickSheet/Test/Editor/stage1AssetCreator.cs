using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/stage1")]
    public static void Createstage1AssetFile()
    {
        stage1 asset = CustomAssetUtility.CreateAsset<stage1>();
        asset.SheetName = "Project_Conveyor";
        asset.WorksheetName = "stage1";
        EditorUtility.SetDirty(asset);        
    }
    
}