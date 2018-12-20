using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArriveBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Untagged")
            return;
        if (other.tag == this.tag)
        {
            InGameManger.instance.checkstar++;
        }

        GameObject parent = other.transform.parent.gameObject;
        InGameManger.instance.boxcount++;
        other.GetComponent<Collider>().enabled = false;
        Destroy(parent);

    }
}

