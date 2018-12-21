using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour {

    public int map;
    public static SelectMap instance;

    public void Start () {

        if (instance == null)
            instance = this;
	}
	

    public void MapNum(int num)
    {
       map=num;
        SceneManager.LoadScene("CJH1");
    }

    public int returnMapNum()
    {
        return map;
    }
}
