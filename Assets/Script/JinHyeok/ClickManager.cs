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
    public Vector3 prevPos;
    public int layermask_Conveyer;

    int Glayermask;

    void Start()
    {
        layermask_Conveyer = (1 << LayerMask.NameToLayer("Conveyor") | 1 << LayerMask.NameToLayer("Ground"));
        Glayermask = (1 << LayerMask.NameToLayer("Ground"));
    }

    // Update is called once per frame
    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.red);
        //Conveyer = hit.transform.gameObject;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, Mathf.Infinity, layermask_Conveyer) && (hit.transform.tag == "Conveyor" || hit.transform.tag == "Conveyor_Stair"))
        {
            prevPos = hit.transform.parent.position;
            RaycastHit hit_Conveyer;
            if (!Physics.Raycast(hit.transform.parent.position, hit.transform.up, out hit_Conveyer, Mathf.Infinity, layermask_Conveyer))
            {
                Conveyer = hit.transform.gameObject;
                Conveyer.transform.GetChild(0).gameObject.SetActive(false);
            }

        }
        if (Conveyer != null)
        {
            Drag();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (Conveyer != null)
            {
                RaycastHit hit_Conveyer;
                if (ground != null)
                {
                    Vector3 ground_Pos = ground.transform.position;
                    Vector3 up_Pos = new Vector3(ground_Pos.x, Conveyer.transform.position.y - 0.1f, ground_Pos.z);
                    if (Physics.Raycast(up_Pos, Conveyer.transform.up * -1, out hit_Conveyer, Mathf.Infinity, layermask_Conveyer))
                    {
                        Vector3 pos_Conveyer;
                        if (hit_Conveyer.transform.tag == "Conveyor" || hit_Conveyer.transform.tag == "nonClick")
                        {
                            pos_Conveyer = hit_Conveyer.transform.parent.position;
                        }
                        else if (hit_Conveyer.transform.tag == "Conveyor_Stair" || hit_Conveyer.transform.tag == "nonClick_Stair")
                        {
                            pos_Conveyer = hit_Conveyer.transform.parent.position + new Vector3(0, Conveyer.transform.localScale.y, 0);
                        }
                        else
                            pos_Conveyer = hit_Conveyer.transform.position;

                        ground.GetComponent<MeshRenderer>().material.color = Color.green;
                        if (hit_Conveyer.transform.parent.position.y >= Conveyer.transform.localScale.y * 5)
                        {
                            Conveyer.transform.parent.position = prevPos;
                        }

                        else
                            Conveyer.transform.parent.position = new Vector3(pos_Conveyer.x, pos_Conveyer.y + hit_Conveyer.transform.localScale.y, pos_Conveyer.z);
                        Conveyer.transform.GetChild(0).gameObject.SetActive(true);
                        Conveyer = null;
                    }

                }
            }

        }
    }
    public void Drag()
    {
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, Glayermask))
        {
            if (ground == null)
            {
                ground = hit.transform;
                ground.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else if (hit.transform != ground)
            {
                ground.GetComponent<MeshRenderer>().material.color = Color.green;
                ground = hit.transform;
                ground.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            Vector3 objPosition = new Vector3(hit.point.x, hit.point.y + Conveyer.transform.localScale.y * 5, hit.point.z);
            Conveyer.transform.parent.position = objPosition;
        }
    }

}