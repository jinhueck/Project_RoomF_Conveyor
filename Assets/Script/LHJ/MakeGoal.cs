using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGoal : MonoBehaviour 
{

    public GameObject Goals;

	void Start ()
    {
        SetGoal("red",new Vector3(3.5f,0,-4.5f));
    }


    void SetGoal(string color,Vector3 pos)
    {
        GameObject goal = Instantiate(Goals, pos, this.transform.rotation);
        
        switch(color)
        {
            case "red":
                goal.tag = "RedBox";
                break;
            case "green":
                goal.tag = "GreenBox";
                break;

        }
    }



}
