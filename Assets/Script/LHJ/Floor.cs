using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
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
