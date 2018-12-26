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



    public void Make(int color, Transform pos, float time,int count,int broke)
    {
        for (int i = 1; i <= count; i++)
        {
            StartCoroutine(MakeTime(color,pos,time * i, broke));
        }
    }

    IEnumerator MakeTime(int color,Transform pos, float time,int broke)
    {
        yield return new WaitForSeconds(time);
        GameObject obj = Instantiate(Box, pos.position, this.transform.rotation);
        obj.transform.SetParent(GameObject.Find("Map").transform);


        if (broke == 1)
        {
            obj.AddComponent<FragileBox>();
            obj.name = "BrokenBox";
        }

        switch (color)
        {
            case 1:
                obj.GetComponent<MeshRenderer>().material = BoxColor[0];
                obj.transform.GetChild(0).tag = "RedBox";
                break;
            case 2:
                obj.GetComponent<MeshRenderer>().material = BoxColor[1];
                obj.transform.GetChild(0).tag = "GreenBox";
                break;
            default:
                Debug.Log("Error Color");
                break;
        }
        
    }
}
