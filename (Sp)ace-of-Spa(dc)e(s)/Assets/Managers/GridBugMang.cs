using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridBugMang : MonoBehaviour
{
    public static GridBugMang Instance;

    [SerializeField] public int width, height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Tile _tileEntrance;
    [SerializeField] private Tile _tileExit;
    [SerializeField] private Transform cam;

    public Dictionary<Vector2, Tile> tiles;
    public List<Tile> tyles;

    void Awake()
    {
        Instance = this;
    }

    public void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                //                var isOffset = ((x + y) % 2 == 1);
                //                spawnedTile.Init(isOffset);

                spawnedTile.Init(x, y);
                
                tiles[new Vector2(x, y)] = spawnedTile;
                tyles.Add(spawnedTile);

            }
        }
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);

        var entrance = Instantiate(_tileEntrance, new Vector3(-1, height - 1), Quaternion.identity);
        entrance.name = "Entrance";
        entrance.Init(-1, height - 1);
        tiles[new Vector2(-1, height - 1)] = entrance;

        var exit = Instantiate(_tileExit, new Vector3(width, 0), Quaternion.identity);
        exit.name = "Exit";
        exit.Init(width, 0);
        tiles[new Vector2(width, 0)] = exit;

        GameManager.Instance.ChangeState(GameState.SpawnMan);
    }

    public Tile GetManSpawnTile()
    {
        return tiles.Where(t => t.Key.x < width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
        

    }

    public Tile GetMindSpawnTile()
    {
        return tiles.Where(t => t.Key.x > width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }
        return null;
    } 

    public void Reset()
    {
        foreach (Tile tile in tyles)
        {
            tile.quality = 0;
        }
    }

}
