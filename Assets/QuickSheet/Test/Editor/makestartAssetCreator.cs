using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/makestart")]
    public static void CreatemakestartAssetFile()
    {
        makestart asset = CustomAssetUtility.CreateAsset<makestart>();
        asset.SheetName = "Project_Conveyor";
        asset.WorksheetName = "makestart";
        EditorUtility.SetDirty(asset);        
    }
    
}