using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/num1")]
    public static void Createnum1AssetFile()
    {
        num1 asset = CustomAssetUtility.CreateAsset<num1>();
        asset.SheetName = "Project_Conveyor";
        asset.WorksheetName = "num1";
        EditorUtility.SetDirty(asset);        
    }
    
}