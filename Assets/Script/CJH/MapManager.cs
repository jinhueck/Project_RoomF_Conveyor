using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    public static MapManager instance;

    public stage1 conveyorInfo;
    public int Mapnum;//맵의 번호
    public Vector2 mapSize;
    public int size; // 배열의 크기
    public int[,] array; // 배열


    public GameObject Tile1;
    public GameObject Tile2;
    public GameObject Tile3;
    public GameObject Tile4;
    public GameObject Tile5;
    public GameObject Tile9;

    

    private int ArrayJ;

    public int arraynum;



     void Start ()
    {
        if (instance == null)
            instance = this;
        SetMapInfo();
        LoadMapNum();
        MapGenerator.instance.GeneratorMap();
        GetConveyor();
        MapGenerator.instance.SetUpConveyor();
    }

    public void SetMapInfo()
    {
        conveyorInfo = Resources.Load<stage1>("CJH/New stage1");
        mapSize.x = conveyorInfo.dataArray[0].Mapsize[0];
        mapSize.y = conveyorInfo.dataArray[1].Mapsize[0];
        size = (int)(mapSize.x * mapSize.y);
        array = new int[5, size];
    }

    public int LoadMapNum()
    {
        ArrNum(Mapnum, size);
        return Mapnum;
    }

    public int ArrNum(int num,int a)
    {
        arraynum = num * a;
        return arraynum;
    }

    public void GetConveyor()
    {
        for (int i = 0; i < 5; i++)
        {
            ArrayJ = 0;
            for (int j = arraynum-9; j < arraynum; j++)
            {     
                if (i == 0)
                {
                    array[i, ArrayJ] = conveyorInfo.dataArray[j].Floor0tile[0];
                }
                else if (i == 1)
                {
                    array[i, ArrayJ] = conveyorInfo.dataArray[j].Floor1tile[0];
                }
                else if (i == 2)
                {
                    array[i, ArrayJ] = conveyorInfo.dataArray[j].Floor2tile[0];
                }
                else if (i == 3)
                {
                    array[i, ArrayJ] = conveyorInfo.dataArray[j].Floor3tile[0];
                }
                else if (i == 4)
                {
                    array[i, ArrayJ] = conveyorInfo.dataArray[j].Floor4tile[0];
                }
                ArrayJ++;
            }
        }
    }

    public void SelectConveyor(int Connum, int Setupnum, int Height)
    {
        Vector3 TilePos = GameObject.Find("Map").transform.GetChild(Setupnum).transform.position;
        Vector3 pos = new Vector3(TilePos.x, TilePos.y + Height, TilePos.z);
        int front = Connum / 100;
        int middle = Connum % 100 / 10;
        int back = Connum % 10;
        GameObject NewOBJ = null;

        switch (front)
        {
            case 1:
                NewOBJ = Instantiate(Tile1, pos, Tile1.transform.rotation);
                break;
            case 2:
                NewOBJ = Instantiate(Tile2, pos, Tile2.transform.rotation);
                break;
            case 3:
                NewOBJ = Instantiate(Tile3, pos, Tile3.transform.rotation);
                break;
            case 4:
                NewOBJ = Instantiate(Tile4, pos, Tile4.transform.rotation);
                break;
            case 5:
                NewOBJ = Instantiate(Tile5, pos, Tile5.transform.rotation);
                break;
            case 9:
                NewOBJ = Instantiate(Tile9, pos, Tile9.transform.rotation);
                break;
        }

        switch (middle)
        {   
            case 2:
                NewOBJ.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                break;
            case 3:
                NewOBJ.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                break;
            case 4:
                NewOBJ.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                break;
        }

        if (back == 1)
        {
            if (NewOBJ.transform.GetChild(0).tag == "Conveyor")
            {
                NewOBJ.transform.GetChild(0).tag = "nonClick";
            }

            if (NewOBJ.transform.GetChild(0).tag == "Conveyor_Stair")
            {
                NewOBJ.transform.GetChild(0).tag = "nonClick_Stair";
            }
        }
    }
}
