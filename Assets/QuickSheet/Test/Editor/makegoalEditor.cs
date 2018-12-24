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
[CustomEditor(typeof(makegoal))]
public class makegoalEditor : BaseGoogleEditor<makegoal>
{	    
    public override bool Load()
    {        
        makegoal targetData = target as makegoal;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<makegoalData>(targetData.WorksheetName) ?? db.CreateTable<makegoalData>(targetData.WorksheetName);
        
        List<makegoalData> myDataList = new List<makegoalData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            makegoalData data = new makegoalData();
            
            data = Cloner.DeepCopy<makegoalData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
