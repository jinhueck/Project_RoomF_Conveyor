using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {       
        
        if (other.tag=="Box")
        {
            GameObject parent = other.transform.parent.gameObject;
            InGameManger.instance.totalbox++;
            other.GetComponent<Collider>().enabled = false;
            Destroy(parent, 1f);
        }
    }
}
