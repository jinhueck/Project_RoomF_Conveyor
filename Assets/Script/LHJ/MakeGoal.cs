using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGoal : MonoBehaviour 
{

    public GameObject Goals;
    public makegoal set;

    int[] color;
    float[] x;
    float[] y;
    float[] z;
    int[] rotate;
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
        for(int i=0;i<1;i++)
        {
            rotate[i] = set.dataArray[i].Rotate[0];
            x[i] = (float)set.dataArray[i].X[0];
            y[i] = (float)set.dataArray[i].Y[0];
            z[i] = (float)set.dataArray[i].Z[0];
            color[i] = set.dataArray[i].Color[0];
            SetGoal(i);
        }
    }

    void reset()
    {
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

        switch (color[j])
        {
            case 1:
                goal.tag = "RedBox";
                break;
            case 2:
                goal.tag = "GreenBox";
                break;

        }

        switch (rotate[j])
        {
            case 1:
                
                break;
            case 2:
                
                break;
            case 3:

                break;
            case 4:

                break;
        }
    }



}
