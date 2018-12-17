using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBox : MonoBehaviour {

    public static MakeBox instance;

    public GameObject[] Box;
    public float starttime;
    public float repeattime;
    int checkbox;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        SettingBox();

    }
    void Start ()
    {
        InvokeRepeating("Make", starttime, repeattime);
	}
	
	// Update is called once per frame
	void Update ()
    {
        CancleMake();
    }

    void SettingBox()
    {
        starttime = 3f;
        repeattime = 5f;
        checkbox = 0;

    }

    public void Make()
    {
        Instantiate(Box[0], this.transform.position, this.transform.rotation);
        checkbox++;
    }

    public void CancleMake()
    {
        if(checkbox==5)
        {
            CancelInvoke("Make");
        }
    }
}
