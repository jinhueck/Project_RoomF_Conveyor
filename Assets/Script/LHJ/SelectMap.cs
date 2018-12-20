using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour {

    public int map;
    SelectMap instance;

    void Start () {

        if (instance == null)
            instance = this;
	}
	

    public void MapNum(int num)
    {
       map=num;
    }
}
