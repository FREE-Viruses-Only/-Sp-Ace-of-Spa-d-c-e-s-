using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ManManager : MonoBehaviour
{
    public static ManManager Instance;

    private List<ScriptableUnit> units;
    public BaseMEAT SelectedMan;

    void Awake()
    {
        Instance = this;

        units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    public void SpawnMan()
    {
        var meatCount = 1;

        for (int i = 0; i < meatCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseMEAT>(Faction.MEAT);
            var spawnedMEAT = Instantiate(randomPrefab);
            var randomSpawnTile = GridBugMang.Instance.GetManSpawnTile();

            randomSpawnTile.SetUnit(spawnedMEAT);
        }

        GameManager.Instance.ChangeState(GameState.SpawnMind);
    }

    public void SpawnMind()
    {
        var mindCount = 1;

        for (int i = 0; i < mindCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseMind>(Faction.MIND);
            var spawnedMind = Instantiate(randomPrefab);
            var randomSpawnTile = GridBugMang.Instance.GetMindSpawnTile();

            randomSpawnTile.SetUnit(spawnedMind);
        }

        GameManager.Instance.ChangeState(GameState.GridCalculation);
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
}
