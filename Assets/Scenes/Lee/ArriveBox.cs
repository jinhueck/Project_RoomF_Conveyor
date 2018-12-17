using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArriveBox : MonoBehaviour {

    public int checkstar;
    public Image[] star;

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag=="Box")
        {
            Collider parent = other.transform.parent.GetComponent<Collider>();
            checkstar++;
            InGameManger.instance.totalbox++;
            Destroy(other);
            parent.enabled = false;
        }
    }

   public void StageStar()
    {        
       switch(checkstar)
        {
            case 0:
                star[3].gameObject.SetActive(true);
                break;
            case 1:
                star[0].gameObject.SetActive(true);
                break;
            case 2:
                star[0].gameObject.SetActive(true);
                break;
            case 3:
                star[1].gameObject.SetActive(true);
                break;
            case 4:
                star[1].gameObject.SetActive(true);
                break;
            case 5:
                star[2].gameObject.SetActive(true);
                break;
        }
    }
}

