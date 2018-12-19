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
[CustomEditor(typeof(stage1map1))]
public class stage1map1Editor : BaseGoogleEditor<stage1map1>
{	    
    public override bool Load()
    {        
        stage1map1 targetData = target as stage1map1;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<stage1map1Data>(targetData.WorksheetName) ?? db.CreateTable<stage1map1Data>(targetData.WorksheetName);
        
        List<stage1map1Data> myDataList = new List<stage1map1Data>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            stage1map1Data data = new stage1map1Data();
            
            data = Cloner.DeepCopy<stage1map1Data>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
