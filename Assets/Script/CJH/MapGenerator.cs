using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public Transform tilePrefab;
    public Vector2 mapSize;
    public GameObject Map;
    public GameObject Tile1;
    public GameObject Tile2;
    public GameObject Tile3;
    public GameObject Tile4;
    public GameObject Tile5;
    public GameObject Tile6;
    public GameObject Tile7;
    public GameObject Tile8;

    private num1 conveyorInfo;


    private int[,] array;
    private int size;


    [Range(0, 1)]
    public float outlinePercent;

    private void Start()
    {
        array = new int[5, size];
        size = (int)(mapSize.x * mapSize.y);
        conveyorInfo = Resources.Load<num1>("CJH/New num1");
        GetConveyor();
        GeneratorMap();
        SetUpConveyor();
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
                //array[Floor, Childnum] = 1;
                SelectConveyor(array[Floor, Childnum], Childnum, Floor + 1);
                //Debug.Log("array" + i + "," + j + " = " + test);
            }
        }
    }

    public void GetConveyor()
    {
        
        Debug.Log("컨베이어 인포 사이즈" + conveyorInfo.dataArray.Length);
        for(int i = 0; i< 5; i++)
        {
            for(int j = 0; j< conveyorInfo.dataArray.Length; j++)
            {
                if(j == 0)
                {
                    array[i, j] = conveyorInfo.dataArray[i].Floor0tile[0];
                }
                
            }
        }
    }

    public void SelectConveyor(int Connum, int Setupnum, int Height)
    {
        Vector3 TilePos = GameObject.Find("MapManager").transform.GetChild(Setupnum).transform.position;
        switch (Connum)
        {
            case 0:
                break;
            case 1:
                GameObject obj1 = Instantiate(Tile1, new Vector3(0f, 0f, 0f), Quaternion.identity);
                obj1.transform.position = new Vector3(TilePos.x, TilePos.y + Height, TilePos.z);
                break;
            case 2:
                GameObject obj2 = Instantiate(Tile2, new Vector3(0f, 0f, 0f), Quaternion.identity);
                obj2.transform.position = new Vector3(TilePos.x, TilePos.y + Height, TilePos.z);
                break;
            case 3:
                GameObject obj3 = Instantiate(Tile3, new Vector3(0f, 0f, 0f), Quaternion.identity);
                obj3.transform.position = new Vector3(TilePos.x, TilePos.y + Height, TilePos.z);
                break;
            case 4:
                GameObject obj4 = Instantiate(Tile4, new Vector3(0f, 0f, 0f), Quaternion.identity);
                obj4.transform.position = new Vector3(TilePos.x, TilePos.y + Height, TilePos.z);
                break;
            case 5:
                GameObject obj5 = Instantiate(Tile5, new Vector3(0f, 0f, 0f), Quaternion.identity);
                obj5.transform.position = new Vector3(TilePos.x, TilePos.y + Height, TilePos.z);
                break;
            case 6:
                GameObject obj6 = Instantiate(Tile6, new Vector3(0f, 0f, 0f), Quaternion.identity);
                obj6.transform.position = new Vector3(TilePos.x, TilePos.y + Height, TilePos.z);
                break;
            case 7:
                GameObject obj7 = Instantiate(Tile7, new Vector3(0f, 0f, 0f), Quaternion.identity);
                obj7.transform.position = new Vector3(TilePos.x, TilePos.y + Height, TilePos.z);
                break;
            case 8:
                GameObject obj8 = Instantiate(Tile8, new Vector3(0f, 0f, 0f), Quaternion.identity);
                obj8.transform.position = new Vector3(TilePos.x, TilePos.y + Height, TilePos.z);
                break;

            default:
                break;
        }
    }
}
