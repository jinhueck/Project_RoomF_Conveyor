using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour {

    public int map;
    public static SelectMap instance;
    public int startnum;
    public int lastnum;
    public int mapX;
    public int mapY;

    public void Start () {

        if (instance == null)
            instance = this;
	}
    
    public void MakeStart(int start)
    {
        startnum = start; 
    }

    public void MakeLast(int last)
    {
        lastnum = last;
    }

    public void ReturnX(int numx)
    {
        mapX = numx;
    }

    public void ReturnY(int numy)
    {
        mapY = numy;
        SceneManager.LoadScene("CJH1");
    }
}
