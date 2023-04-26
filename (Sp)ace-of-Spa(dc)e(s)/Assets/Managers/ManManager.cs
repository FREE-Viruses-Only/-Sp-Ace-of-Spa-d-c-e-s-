using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ManManager : MonoBehaviour
{
    public static ManManager Instance;

    public List<ScriptableUnit> units;

    public List<BaseMEAT> patrons;

    public List<BaseMind> machines;

    public BaseMEAT SelectedMan;

   //Random rnd = new Random();

    void Awake()
    {
        Instance = this;

        units = Resources.LoadAll<ScriptableUnit>("Units").ToList();

    }

    public List<BaseMEAT> GetPatrons()
    {
        return patrons;
    }

    public void SpawnMan()
    {
        var meatCount = 5;

        for (int i = 0; i < meatCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseMEAT>(Faction.MEAT);
            var spawnedMEAT = Instantiate(randomPrefab);
            var randomSpawnTile = GridBugMang.Instance.GetManSpawnTile();
            spawnedMEAT.tetraNeed = Random.Range(0,50);
            spawnedMEAT.ballerNeed = Random.Range(0,50);
            spawnedMEAT.exitNeed = Random.Range(0,15);
            spawnedMEAT.moners = Random.Range(1,100);



            spawnedMEAT.transform.position = randomSpawnTile;

            patrons.Add(spawnedMEAT);
        }

        GameManager.Instance.ChangeState(GameState.SpawnMind);
    }

    public void SpawnMind()
    {
        var mindCount = 12;

        for (int i = 0; i < mindCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseMind>(Faction.MIND);
            var spawnedMind = Instantiate(randomPrefab);
            var randomSpawnTile = GridBugMang.Instance.GetMindSpawnTile();

            randomSpawnTile.SetUnit(spawnedMind);

            machines.Add(spawnedMind);

        }

        GameManager.Instance.ChangeState(GameState.Advertize);
    }

    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T)units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }

    public void SetSelectedMan (BaseMEAT meat)
    {
        SelectedMan = meat;
        Men.Instance.ShowSelectedHero(meat);
    }

    public void Enter()
    {
        var randomPrefab = GetRandomUnit<BaseMEAT>(Faction.MEAT);

        if (randomPrefab.ForReal = false)
        {
            var SpawnTile = GridBugMang.Instance.Entrance();

            SpawnTile.SetUnit(randomPrefab);

            randomPrefab.ForReal = true;
        }

 //       var spawnedMEAT = Instantiate(randomPrefab);

    }
}
