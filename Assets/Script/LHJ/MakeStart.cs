using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*struct StartInfo
{
    int rotate;
    float x;
    float y;
    float z;
    int color;
    float time;
    int count;
    int broke;

    public void startinfo(int rotate, float x, float y, float z, int color, float time, int count, int broke)
    {
        this.rotate = rotate;
        this.x = x;
        this.y = y;
        this.z = z;
        this.color = color;
        this.time = time;
        this.count = count;
        this.broke = broke;
    }
};*/

public class MakeStart : MonoBehaviour
{
    public makestart set;
    public Transform map;

   public int startfor;
    public int lastfor;

    public GameObject startobj;
    GameObject obj;
    int[] rotate;
    float[] x;
    float[] y;
    float[] z;
    int[] color;
    float[] time;
    int[] count;
    int[] broke;
    int size;
    int arraynum;
    int[] stage;

    void Start ()
    {
        size = 1;
        set = Resources.Load<makestart>("Lee/New makestart");
        restet();
        SetQuick();      
        
    }

    void Update()
    {
        
    }




    public void SetQuick()
    {      
        Debug.Log("setquick");
        for (int i = startfor; i < lastfor; i++)
        {
            Debug.Log(i);
            Debug.Log("setquick / for");
     
                rotate[i] = set.dataArray[i].Num[0];
                x[i] = set.dataArray[i].X[0];
                y[i] = set.dataArray[i].Y[0];
                z[i] = set.dataArray[i].Z[0];
                color[i] = set.dataArray[i].Color[0];
                time[i] = set.dataArray[i].Time[0];
                count[i] = set.dataArray[i].Count[0];
                broke[i] = set.dataArray[i].Broke[0];
                Setstart(i);
                
        }
    }
  

    void restet()
    {
        size = SelectMap.instance.lastnum;
        startfor = SelectMap.instance.startnum;
        lastfor = SelectMap.instance.lastnum;
        rotate = new int[size];
        x= new float[size];
        y= new float[size];
        z= new float[size];
        color= new int[size];
        time= new float[size];
        count= new int[size];
        broke= new int[size];

        ArrNum(MapManager.instance.Mapnum, size);
    }

    public int ArrNum(int num, int a)
    {
        arraynum = num * a;
        return arraynum;
    }



    public void Setstart(int num)
    {
        int j = num;
        Vector3 Summon = new Vector3((3 * x[j]), y[j], (3*z[j]));
       
        obj =Instantiate(startobj, Summon, this.transform.rotation);
        obj.transform.GetChild(0).GetComponent<MakeBox>().Make(color[j],obj.transform, time[j], count[j], broke[j]);
        obj.transform.SetParent(map);


        switch (rotate[j])
        {
            case 1:
                
                break;
            case 2:

                obj.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                break;
            case 3:
                obj.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                break;
            case 4:
                obj.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                break;
        }
        
    }
}
