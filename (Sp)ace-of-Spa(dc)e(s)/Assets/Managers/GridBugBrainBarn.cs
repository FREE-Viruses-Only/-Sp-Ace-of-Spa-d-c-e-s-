using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBugBrainBarn : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform cam;

    void Start()
    {   

        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

//                var isOffset = ((x + y) % 2 == 1);
//                spawnedTile.Init(isOffset);
            }
        }
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);

    }

}
