using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public Camera camera;
    private Ray ray;
    public RaycastHit hit;
    public GameObject Conveyer;

    int Glayermask;
    // Use this for initialization
    void Start()
    {
       //Glayermask = (1 << LayerMask.NameToLayer("Conveyor"));
       //ray = camera.ScreenPointToRay(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.red);
        //Conveyer = hit.transform.gameObject;
        if(Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit) && hit.transform.tag == "Conveyor")
        {
            Conveyer = hit.transform.gameObject;
            Debug.Log(Conveyer);
            Conveyer.transform.GetChild(0).gameObject.SetActive(false);
            Conveyer.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (Conveyer != null)
        {
            Drag();
        }
        if(Input.GetMouseButtonUp(0))
        {
            Conveyer.transform.GetChild(0).gameObject.SetActive(true);
            Conveyer.transform.GetChild(1).gameObject.SetActive(false);
            Conveyer = null;
        }
    }
    public void Drag()
    {
        Vector3 scrSpace = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Conveyer.transform.position = objPosition;
    }
    /*
    public void drag()
    {   
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, Glayermask))
        {
            //Skillrange.SetActive(true);
            Conveyer.transform.position = hit.point;
        }
    }
    */
    float distance = 10f;
    /*
    public void OnMouseDrag()
    {
        print("Drag!!");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        //Conveyer.transform.GetChild(0).gameObject.SetActive(false);
        //Conveyer.transform.GetChild(1).gameObject.SetActive(true);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Conveyer.transform.position = objPosition;
    }
    */
}
