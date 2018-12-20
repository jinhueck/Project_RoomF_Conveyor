using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileBox : MonoBehaviour
{ 

    Vector3 Exit;
    Vector3 Enter;
    int i;

    void Start()
    {
        i = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        if (i == 0)
        {
            Exit.y = this.transform.position.y;
            i++;
        }
    }

    private void OnTriggerEnter(Collider other)
    { 
        Enter.y = this.transform.position.y;
        i = 0;
        if (Exit.y - Enter.y > 0.8)
        {
            Debug.Log("계산 완료!" + Exit.y + "   " + Enter.y + " =" + (Exit.y - Enter.y));
            InGameManger.instance.boxcount++;
            Destroy(this.gameObject,1f);
        }
    }
}
