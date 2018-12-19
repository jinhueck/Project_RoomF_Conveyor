using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public Transform tilePrefab;
    private Vector2 mapSize;
    public GameObject Map;
    public GameObject Tile1;
    public GameObject Tile2;
    public GameObject Tile3;
    public GameObject Tile4;
    public GameObject Tile5;
    public GameObject Tile6;
    public GameObject Tile7;
    public GameObject Tile8;
    public GameObject Tile9;

    private stage1map1 conveyorInfo;
    //private stage1map2 conveyorInfo;

    public int Mapnum;//맵의 번호

    private int[,] array; // 배열
    private int size; // 배열의 크기


    [Range(0, 1)]
    public float outlinePercent;

    private void Start()
    {
        SetMapInfo();
        GetConveyor();
        GeneratorMap();
        SetUpConveyor();
    }

    public void SetMapInfo()
    {
        conveyorInfo = Resources.Load<stage1map1>("CJH/New stage"+1+"map"+Mapnum);
        mapSize.x = conveyorInfo.dataArray[0].Mapsize[0];
        mapSize.y = conveyorInfo.dataArray[1].Mapsize[0];
        size = (int)(mapSize.x * mapSize.y);
        array = new int[5, size];
    }

    public int LoadMapNum()
    {
        return Mapnum;
    }

    public void GeneratorMap()
    {
        /*
        string holderName = "Generated Map";
        if(transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }
        

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;
        */

        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                Vector3 tilePosition = (new Vector3(mapSize.x / 2, 0, mapSize.y / 2) + new Vector3(x - mapSize.x, 0, y - mapSize.y)) * tilePrefab.transform.localScale.x;
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.identity) as Transform;
                newTile.parent = Map.transform;
            }
        }
    }

    public void SetUpConveyor()
    {
        //int test = 0;
        for (int Floor = 0; Floor < 5; Floor++)
        {
            for (int Childnum = 0; Childnum < size; Childnum++)
            {
                Debug.Log("array 정보 Floor = " + Floor+ "Childnum = " + Childnum + " ="+array[Floor, Childnum]);
                //array[Floor, Childnum] = 1;
                SelectConveyor(array[Floor, Childnum], Childnum, Floor + 1);
                //Debug.Log("array" + i + "," + j + " = " + test);
            }
        }
    }

    public void GetConveyor()
    {   
        Debug.Log("컨베이어 인포 사이즈" + conveyorInfo.dataArray.Length);
        //Debug.Log("Floor0tile 0,0값 " + conveyorInfo.dataArray[0].Floor0tile[0]);
        for (int i = 0; i< 5; i++)
        {
            for(int j = 0; j< conveyorInfo.dataArray.Length; j++)
            {
                //array[i, j] = conveyorInfo.dataArray[j].Floor0tile[0];
                if(i == 0)
                {
                    array[i, j] = conveyorInfo.dataArray[j].Floor0tile[0];
                }
                else if (i == 1)
                {
                    array[i, j] = conveyorInfo.dataArray[j].Floor1tile[0];
                }
                else if (i == 2)
                {
                    array[i, j] = conveyorInfo.dataArray[j].Floor2tile[0];
                }
                else if (i == 3)
                {
                    array[i, j] = conveyorInfo.dataArray[j].Floor3tile[0];
                }
                else if (i == 4)
                {
                    array[i, j] = conveyorInfo.dataArray[j].Floor4tile[0];
                }
                Debug.Log("array 정보 Floor = " + i + "Childnum = " + j + " =" + array[i, j]);
            }
        }
    }

    public void SelectConveyor(int Connum, int Setupnum, int Height)
    {
        Vector3 TilePos = GameObject.Find("MapManager").transform.GetChild(Setupnum).transform.position;
        Vector3 pos = new Vector3(TilePos.x, TilePos.y + Height, TilePos.z); 
        switch (Connum)
        {
            case 0:
                break;
            case 1:
                GameObject obj1 = Instantiate(Tile1, pos, Tile1.transform.rotation);
                break;
            case 2:
                GameObject obj2 = Instantiate(Tile2, pos, Tile2.transform.rotation);
                break;
            case 3:
                GameObject obj3 = Instantiate(Tile3, pos, Tile3.transform.rotation);
                break;
            case 4:
                GameObject obj4 = Instantiate(Tile4, pos, Tile4.transform.rotation);
                break;
            case 5:
                GameObject obj5 = Instantiate(Tile5, pos, Tile5.transform.rotation);
                break;
            case 6:
                GameObject obj6 = Instantiate(Tile6, pos, Tile6.transform.rotation);
                break;
            case 7:
                GameObject obj7 = Instantiate(Tile7, pos, Tile7.transform.rotation);
                break;
            case 8:
                GameObject obj8 = Instantiate(Tile8, pos, Tile8.transform.rotation);
                break;
            case 9:
                GameObject obj9 = Instantiate(Tile9, pos, Tile9.transform.rotation);
                break;

            default:
                break;
        }
    }
}
