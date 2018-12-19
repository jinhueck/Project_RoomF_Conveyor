using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using GDataDB;
using GDataDB.Linq;

using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(stage1map2))]
public class stage1map2Editor : BaseGoogleEditor<stage1map2>
{	    
    public override bool Load()
    {        
        stage1map2 targetData = target as stage1map2;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<stage1map2Data>(targetData.WorksheetName) ?? db.CreateTable<stage1map2Data>(targetData.WorksheetName);
        
        List<stage1map2Data> myDataList = new List<stage1map2Data>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            stage1map2Data data = new stage1map2Data();
            
            data = Cloner.DeepCopy<stage1map2Data>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
