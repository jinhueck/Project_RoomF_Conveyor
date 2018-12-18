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



    [Range(0, 1)]
    public float outlinePercent;

    private void Start()
    {
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
        int size = (int)(mapSize.x * mapSize.y);
        int[,] array = new int[5, size];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < size; j++)
            {
                array[i, j] = 1;
                if (array[i, j] == 1)
                {
                    SelectConveyor(1, j, i + 1);
                }
                //Debug.Log("array" + i + "," + j + " = " + test);
            }
        }
    }

    public void SelectConveyor(int Connum, int Setupnum, int Height)
    {
        Vector3 TilePos = GameObject.Find("MapManager").transform.GetChild(Setupnum).transform.position;
        switch (Connum)
        {
            case 1:
                GameObject obj1 = Instantiate(Tile1, new Vector3(0f, 0f, 0f), Quaternion.identity);
                obj1.transform.position = new Vector3(TilePos.x, TilePos.y + Height, TilePos.z);
                break;

        }
    }
}
