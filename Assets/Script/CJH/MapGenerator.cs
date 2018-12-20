using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator instance;

    public Transform tilePrefab;
    public GameObject Map;
    //private stage1map2 conveyorInfo;


    [Range(0, 1)]
    public float outlinePercent;
    
    private void Start()
    {
        if (instance == null)
            instance = this;
        //MapManager.instance.SetMapInfo();
        //MapManager.instance.LoadMapNum();
        //GeneratorMap();
        //MapManager.instance.GetConveyor();
        //SetUpConveyor();
    }


    public void GeneratorMap()
    {
        MapManager.instance.SetMapInfo();
        for (int x = 0; x < MapManager.instance.mapSize.x; x++)
        {
            for (int y = 0; y < MapManager.instance.mapSize.y; y++)
            {
                Vector3 tilePosition = (new Vector3(MapManager.instance.mapSize.x / 2, 0, MapManager.instance.mapSize.y / 2) 
                    + new Vector3(x - MapManager.instance.mapSize.x, 0, y - MapManager.instance.mapSize.y)) * tilePrefab.transform.localScale.x;
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
            for (int Childnum = 0; Childnum < MapManager.instance.size; Childnum++)
            {
                Debug.Log("array 정보 Floor = " + Floor+ "Childnum = " + Childnum + " ="+ MapManager.instance.array[Floor, Childnum]);
                //array[Floor, Childnum] = 1;
                MapManager.instance.SelectConveyor(MapManager.instance.array[Floor, Childnum], Childnum, Floor + 1);
                //Debug.Log("array" + i + "," + j + " = " + test);
            }
        }
    }

   
}
