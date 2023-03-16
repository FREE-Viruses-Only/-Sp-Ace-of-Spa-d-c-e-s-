using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBugBrainBarn : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform cam;

    private Dictionary<Vector2, Tile> squiles;


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

                squiles[new Vector2(x,y)] = spawnedTile;
            }
        }
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);

        GameManager.Instance.ChangeState(GameState.SpawnMan);
    }

    public Tile GetTileAt(Vector2, pos)
    {
        if (squiles.TryGetValue(pos, out var tile))
        {  return tile; }
        return null;
    }

}
