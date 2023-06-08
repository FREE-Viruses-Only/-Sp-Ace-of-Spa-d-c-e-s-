using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnerMan : MonoBehaviour
{
    public static PawnerMan Instance;

    public bool pawnerTime;

    public BaseUnit pawnThis;

    [SerializeField] private BaseMEAT thisFuckinGuy;
    [SerializeField] private BaseMind BallerPawner;
    [SerializeField] private BaseMind TetraPawner;
    [SerializeField] private BaseMind WallPawner;

    void Awake()
    {
        Instance = this;
    }

    public void spawnMenMan()
    {
        int wunko = ManManager.Instance.wunko;

        var randomPrefab = thisFuckinGuy;
        var spawnedMEAT = Instantiate(randomPrefab);
        var randomSpawnTile = GridBugMang.Instance.GetManSpawnTile();
        spawnedMEAT.tetraNeed = Random.Range(0, 15);
        spawnedMEAT.ballerNeed = Random.Range(0, 15);
        spawnedMEAT.exitNeed = Random.Range(0, 1000);
        spawnedMEAT.moners = Random.Range(1, 20);
        spawnedMEAT.dexMod = Random.Range(1, 5);
        spawnedMEAT.gumpMod = Random.Range(1, 5);



        spawnedMEAT.transform.position = randomSpawnTile;

        spawnedMEAT.Home = new Vector2(spawnedMEAT.transform.position.x, spawnedMEAT.transform.position.y);

        spawnedMEAT.IsReal = false;

        string name = spawnedMEAT.UnitName;

        spawnedMEAT.UnitName = $"{name} {wunko}";

        wunko++;

        ManManager.Instance.patrons.Add(spawnedMEAT);
        ManManager.Instance.things.Add(spawnedMEAT);
    }

    public void spawnMenBaller()
    {
        MindPawner(BallerPawner);
    }

    public void spawnMenTetrahedron()
    {
        MindPawner(TetraPawner);
    }

    public void spawnMenWall()
    {
        MindPawner(WallPawner);
    }

    public void MindPawner(BaseMind pawn)
    {
        pawnerTime = true;


        var randomPrefab = pawn;
        var spawnedMind = Instantiate(randomPrefab);
        //   var randomSpawnTile = GridBugMang.Instance.GetMindSpawnTile();

        // randomSpawnTile.SetUnit(spawnedMind);

        pawnThis = spawnedMind;

        ManManager.Instance.machines.Add(spawnedMind);
        ManManager.Instance.things.Add(spawnedMind);
    }

}
