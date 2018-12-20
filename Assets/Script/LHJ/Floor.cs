using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {       
        if (other.tag=="Conveyor")
        {
            return;
        }

            GameObject parent = other.transform.parent.gameObject;
            InGameManger.instance.boxcount++;
            other.GetComponent<Collider>().enabled = false;
            Destroy(parent, 1f);
    }
}
