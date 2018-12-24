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
[CustomEditor(typeof(makestart))]
public class makestartEditor : BaseGoogleEditor<makestart>
{	    
    public override bool Load()
    {        
        makestart targetData = target as makestart;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<makestartData>(targetData.WorksheetName) ?? db.CreateTable<makestartData>(targetData.WorksheetName);
        
        List<makestartData> myDataList = new List<makestartData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            makestartData data = new makestartData();
            
            data = Cloner.DeepCopy<makestartData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
