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
    public Vector3 BeforeSlidePos;
    public Vector3 AfterSlidePos;
    public int layermask_Conveyer;
    public GameObject Map;
    public bool CheckRotate;

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
        else if(Input.GetMouseButtonDown(0) && !Physics.Raycast(ray, out hit, Mathf.Infinity, layermask_Conveyer))
        {
            BeforeSlidePos = Input.mousePosition;
            Debug.Log("마우스 클릭");
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
            else if (BeforeSlidePos != Vector3.zero)
            {
                
                Debug.Log("BeforeSlidePos 들어옴");
                AfterSlidePos = Input.mousePosition;
                float distancex = Mathf.Abs(BeforeSlidePos.x - AfterSlidePos.x);
                float distancey = Mathf.Abs(BeforeSlidePos.y - AfterSlidePos.y);
                if (BeforeSlidePos.y > Screen.height / 2)
                {
                    if (distancex > distancey)
                    {
                        if (BeforeSlidePos.x > AfterSlidePos.x)
                        {
                            MoveMapRight();
                        }
                        else if (BeforeSlidePos.x < AfterSlidePos.x)
                        {
                            MoveMapLeft();
                        }
                    }
                    else if (distancey > distancex)
                    {
                        if (BeforeSlidePos.x > Screen.width / 2)//오른쪽
                        {   
                            if (BeforeSlidePos.y > AfterSlidePos.y)//오른쪽위
                            {
                                MoveMapLeft();
                                Debug.Log("오른쪽 위에서 오른쪽 아래로");
                            }
                        }
                        else if(BeforeSlidePos.x < Screen.width / 2)//왼쪽
                        {
                            if (BeforeSlidePos.y > AfterSlidePos.y)//왼쪽위
                            {
                                MoveMapRight();
                                Debug.Log("왼쪽 위에서 왼쪽 아래로");
                            }
                        }
                    }
                }
                else if(BeforeSlidePos.y < Screen.height/2)
                {
                    if (distancex > distancey)
                    {
                        if (BeforeSlidePos.x > AfterSlidePos.x)
                        {
                            MoveMapLeft();
                        }
                        else if (BeforeSlidePos.x < AfterSlidePos.x)
                        {
                            MoveMapRight();
                        }
                    }
                    else if (distancey > distancex)
                    {
                        if (BeforeSlidePos.x < Screen.width / 2)
                        {
                            if (BeforeSlidePos.y < AfterSlidePos.y)//왼쪽 아래
                            {
                                MoveMapLeft();
                                Debug.Log("왼쪽 아래에서 왼쪽 위로");
                            }
                        }
                        else if(BeforeSlidePos.x > Screen.width / 2)
                        {
                            if (BeforeSlidePos.y < AfterSlidePos.y)
                            {
                                MoveMapRight();
                                Debug.Log("오른쪽 아래에서 오른쪽 위로");
                            }
                        }
                    }
                }
                BeforeSlidePos = Vector3.zero;
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
    Coroutine cor;
    public void MoveMapLeft()
    {
        setPos += new Vector3(0, 90, 0);
        MapPos = Map.transform.rotation;
        if (cor != null)
            StopCoroutine(cor);
        cor = StartCoroutine("StartMoveRight");
    }

    public void MoveMapRight()
    {
        setPos += new Vector3(0, -90, 0);
        MapPos = Map.transform.rotation;
        if (cor != null)
            StopCoroutine(cor);
        cor = StartCoroutine("StartMoveRight");
    }

    public Vector3 setPos = Vector3.zero;
    Quaternion MapPos;



    IEnumerator StartMoveRight()
    {

        bool moving = true;

        float test = 0f;

        while (test < 3)
        {
            //Debug.Log("코루틴 도는중");
            test += Time.deltaTime;
            Map.transform.rotation = Quaternion.Slerp(Map.transform.rotation, Quaternion.Euler(setPos), test/3);
            float num = setPos.y;
            float num2 = Map.transform.rotation.y;

            if (num < 0)
                num += 360;
            if (num2 < 0)
                num2 += 360;
            float total = Mathf.Abs(num - num2);
            //Debug.Log(" num : " + num + " num2 : " + num2 + "        " + total);
            if (total < 0.05f)
            {
                moving = false;
            }
            yield return null;
        }
        yield return null;
    }
}