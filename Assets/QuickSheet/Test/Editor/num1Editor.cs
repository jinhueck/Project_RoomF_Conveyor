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
[CustomEditor(typeof(num1))]
public class num1Editor : BaseGoogleEditor<num1>
{	    
    public override bool Load()
    {        
        num1 targetData = target as num1;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<num1Data>(targetData.WorksheetName) ?? db.CreateTable<num1Data>(targetData.WorksheetName);
        
        List<num1Data> myDataList = new List<num1Data>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            num1Data data = new num1Data();
            
            data = Cloner.DeepCopy<num1Data>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
