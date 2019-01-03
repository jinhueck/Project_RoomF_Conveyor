using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGoal : MonoBehaviour 
{

    public GameObject Goals;
    public Transform map;
    public makegoal set;

    int[] color;
    float[] x;
    float[] y;
    float[] z;
    int[] rotate;
    int startfor;
    int lastfor;
    int size;
   void Start ()
    {

        set = Resources.Load<makegoal>("Lee/New makegoal");
        size = 1;
        reset();
        SetQuick();
    }

     void SetQuick()
      {
          for(int i= startfor; i< lastfor; i++)
          {
              rotate[i] = set.dataArray[i].Rotate[0];
              x[i] = set.dataArray[i].X[0];
              y[i] = set.dataArray[i].Y[0];
              z[i] = set.dataArray[i].Z[0];
              color[i] = set.dataArray[i].Color[0];
              SetGoal(i);
          }
      }

    void reset()
    {
        size = SelectMap.instance.lastnum;
        startfor = SelectMap.instance.startnum;
        lastfor = SelectMap.instance.lastnum;
        color = new int[size];
        x = new float[size];
        y= new float[size];
        z= new float[size];
        rotate = new int[size];
    }

    void SetGoal(int num)
    {
        int j = num;
        Vector3 Summon = new Vector3((3 * x[j]), y[j], (3 * z[j]));
        GameObject goal = Instantiate(Goals, Summon, this.transform.rotation);
        goal.transform.SetParent(map);

        switch (color[j])
        {
            case 1:
                goal.transform.GetChild(0).tag = "RedBox";
                break;
            case 2:
                goal.transform.GetChild(0).tag = "GreenBox";
                break;

        }

        switch (rotate[j])
        {
            case 1:
                
                break;
            case 2:
                goal.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                break;
            case 3:
                goal.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                break;
            case 4:
                goal.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                break;
        }
    }



}
