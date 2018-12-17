using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public Camera camera;
    private Ray ray;
    public RaycastHit hit;
    public GameObject Conveyer;
    public Transform ground;
    public int layermask_Conveyer;

    int Glayermask;
    // Use this for initialization
    void Start()
    {
        //Glayermask = (1 << LayerMask.NameToLayer("Conveyor"));
        //ray = camera.ScreenPointToRay(Input.mousePosition);
        layermask_Conveyer = (1 << LayerMask.NameToLayer("Conveyor") | 1 << LayerMask.NameToLayer("Ground"));
        Glayermask = (1 << LayerMask.NameToLayer("Ground"));
    }

    // Update is called once per frame
    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.red);
        //Conveyer = hit.transform.gameObject;
        if(Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, Mathf.Infinity, layermask_Conveyer) && hit.transform.tag == "Conveyor")
        {
            RaycastHit hit_Conveyer;
            if(!Physics.Raycast(hit.transform.parent.position, hit.transform.up, out hit_Conveyer, Mathf.Infinity))
            {
                Conveyer = hit.transform.gameObject;
                Conveyer.transform.GetChild(0).gameObject.SetActive(false);
            }
            
        }
        if (Conveyer != null)
        {
            Drag();
        }
        if(Input.GetMouseButtonUp(0))
        {   
            if(Conveyer != null)
            {
                RaycastHit hit_Conveyer;
                Vector3 ground_Pos = ground.transform.position;
                Vector3 up_Pos = new Vector3(ground_Pos.x, Conveyer.transform.position.y, ground_Pos.z);
                if(Physics.Raycast(up_Pos, Conveyer.transform.up * -1, out hit_Conveyer, Mathf.Infinity, layermask_Conveyer))
                {
                    Vector3 pos_Conveyer;
                    if (hit_Conveyer.transform.tag == "Conveyor")
                    {
                        Conveyer.transform.GetChild(0).gameObject.SetActive(true);
                        pos_Conveyer = hit_Conveyer.transform.parent.position;
                    }
                    else
                    pos_Conveyer = hit_Conveyer.transform.position;
                    ground.GetComponent<MeshRenderer>().material.color = Color.green;
                    Conveyer.transform.parent.position = new Vector3(pos_Conveyer.x, pos_Conveyer.y + hit_Conveyer.transform.localScale.y, pos_Conveyer.z);
                    Conveyer = null;
                }
            }
            
        }
    }
    public void Drag()
    {
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, Glayermask))
        {
            if(ground == null)
            {
                ground = hit.transform;
                ground.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else if(hit.transform != ground)
            {
                ground.GetComponent<MeshRenderer>().material.color = Color.green;
                ground = hit.transform;
                ground.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            Vector3 objPosition = new Vector3(hit.point.x,hit.point.y + Conveyer.transform.localScale.y * 3, hit.point.z);
            Conveyer.transform.parent.position = objPosition;
        }
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
