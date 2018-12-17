﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public Transform tilePrefab;
    public Vector2 mapSize;

    [Range(0,1)]
    public float outlinePercent;

    private void Start()
    {
        GeneratorMap();
    }

    public void GeneratorMap()
    {
        string holderName = "Generated Map";
        if(transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        for(int x = 0; x < mapSize.x; x++)
        {
            for(int y=0; y < mapSize.y; y++)
            {
                Vector3 tilePosition = (new Vector3(mapSize.x / 2, 0 , mapSize.y/2) + new Vector3(x - mapSize.x, 0, y - mapSize.y)) * tilePrefab.transform.localScale.x;
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.identity) as Transform;
                newTile.parent = mapHolder;
            }
        }
    }
}