using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBox : MonoBehaviour {

    public static MakeBox instance;

    public GameObject Box;
    public Material[] BoxColor;
    public float starttime;
    public float repeattime;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start ()
    {
        Make("red", this.transform.position, 2f,10,true);
       // Make("green", this.transform.position, 4f,10,false);
    }


    public void Make(string color, Vector3 pos, float time,int count,bool broke)
    {
        for (int i = 1; i <= count; i++)
        {
            StartCoroutine(MakeTime(color, pos, time*i, broke));
        }
    }

    IEnumerator MakeTime(string color, Vector3 pos, float time,bool broke)
    {
        yield return new WaitForSeconds(time);
        GameObject obj = Instantiate(Box, pos, this.transform.rotation);

        if (broke == true)
        {
            obj.AddComponent<FragileBox>();
            obj.name = "BrokenBox";
        }

        switch (color)
        {
            case "red":
                obj.GetComponent<MeshRenderer>().material = BoxColor[0];
                obj.transform.GetChild(0).tag = "RedBox";
                break;
            case "green":
                obj.GetComponent<MeshRenderer>().material = BoxColor[1];
                obj.transform.GetChild(0).tag = "GreenBox";
                break;
            default:
                Debug.Log("Error Color");
                break;
        }
    }
}
