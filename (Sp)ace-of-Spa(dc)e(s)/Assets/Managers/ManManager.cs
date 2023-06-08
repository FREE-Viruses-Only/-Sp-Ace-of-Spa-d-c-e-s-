using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ManManager : MonoBehaviour
{
    public static ManManager Instance;

    public List<ScriptableUnit> units;

    public List<BaseUnit> things;

    public List<BaseMEAT> patrons;

    public List<BaseMind> machines;

    public BaseMEAT SelectedMan;

    public int wunko = 0;

   //Random rnd = new Random();

    void Awake()
    {
        Instance = this;

        units = Resources.LoadAll<ScriptableUnit>("Units").ToList();

        things = Resources.LoadAll<BaseUnit>("Things").ToList();

        Debug.Log($"How many thibngs are in things?? \n The TRUTH ::: {things.Count}");

    }

    public List<BaseMEAT> GetPatrons()
    {
        return patrons;
    }

    public void SpawnMan()
    {
        var meatCount = 1;

        for (int i = 0; i < meatCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseMEAT>(Faction.MEAT);
            var spawnedMEAT = Instantiate(randomPrefab);
            var randomSpawnTile = GridBugMang.Instance.GetManSpawnTile();
            spawnedMEAT.tetraNeed = Random.Range(0,40);
            spawnedMEAT.ballerNeed = Random.Range(0,40);
            spawnedMEAT.exitNeed = Random.Range(0,10);
            spawnedMEAT.moners = Random.Range(1,30);
            spawnedMEAT.dexMod = Random.Range(1, 5);
            spawnedMEAT.gumpMod = Random.Range(1, 5);


            spawnedMEAT.transform.position = randomSpawnTile;

            spawnedMEAT.Home = new Vector2(spawnedMEAT.transform.position.x, spawnedMEAT.transform.position.y);

            spawnedMEAT.IsReal = false;

            string name = spawnedMEAT.UnitName;

            spawnedMEAT.UnitName = $"{name} {wunko}";

            wunko++;

            patrons.Add(spawnedMEAT);
        }

        foreach (BaseMEAT guy in patrons)
        {
            guy.IsReal = false;
        }

        GameManager.Instance.ChangeState(GameState.SpawnMind);
    }

    public void SpawnMind()
    {
        var mindCount = 3;

        for (int i = 0; i < mindCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseMind>(Faction.MIND);
            var spawnedMind = Instantiate(randomPrefab);
            var randomSpawnTile = GridBugMang.Instance.GetMindSpawnTile();

            randomSpawnTile.SetUnit(spawnedMind);

            machines.Add(spawnedMind);

        }

        things.AddRange(patrons);

        Debug.Log($"How many thibngs are in things?? \n The TRUTH ::: {things.Count}");

        things.AddRange(machines);

        Debug.Log($"How many thibngs are in things?? \n The TRUTH ::: {things.Count}");

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
        BaseMEAT ThisGuy = patrons[Random.Range(0, patrons.Count)];

        if (ThisGuy.IsReal == false)
        {

            GridBugMang.Instance.Entrance().SetUnit(ThisGuy);

            
            
        }

 //       var spawnedMEAT = Instantiate(randomPrefab);

    }
}
