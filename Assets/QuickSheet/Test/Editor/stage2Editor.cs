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
[CustomEditor(typeof(stage2))]
public class stage2Editor : BaseGoogleEditor<stage2>
{	    
    public override bool Load()
    {        
        stage2 targetData = target as stage2;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<stage2Data>(targetData.WorksheetName) ?? db.CreateTable<stage2Data>(targetData.WorksheetName);
        
        List<stage2Data> myDataList = new List<stage2Data>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            stage2Data data = new stage2Data();
            
            data = Cloner.DeepCopy<stage2Data>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
