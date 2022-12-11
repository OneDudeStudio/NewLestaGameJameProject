using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class MobPool : MonoBehaviour
{
    [SerializeField] private List<Mob> _mobs;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<PathTrajectory> _trajectories;
    
    private const int _cooldownInMilliseconds = 1000;
    private float _lastSpawnTime;

    private void Start()
    {
        foreach (var mob in _mobs)
        {
            mob.Died += WaitAndRespawnMob;
        }
        
        SpawnMobs();
    }

    private void SpawnMobs()
    {
        for (var i = 0; i < _spawnPoints.Count; i++)
        {
            _mobs[i].HouseNumber = i;
            SpawnMob(_mobs[i], _spawnPoints[i].position);
        }
    }

    private async void WaitAndRespawnMob(Mob mob)
    {
        mob.gameObject.SetActive(false);
        await Task.Delay(_cooldownInMilliseconds);

        var spawnPosition = GetSpawnPosition(mob);
        SpawnMob(mob, spawnPosition);
    }

    private void SpawnMob(Mob mob, Vector3 position)
    {
        mob.transform.position = position;
        mob.gameObject.SetActive(true);
        
        SetMobTrajectory(mob);
        
        mob.StartMovement();
    }

    private void SetMobTrajectory(Mob mob)
    {
        var trajectoryNumbers = mob.GetTrajectoryNumbers();
        var trajectories = new List<PathTrajectory>();

        foreach (var trajectoryNumber in trajectoryNumbers)
        {
            trajectories.Add(_trajectories[trajectoryNumber]);
        }
            
        mob.setTrajectory(trajectories);
    }
    
    private Vector3 GetSpawnPosition(Mob mob)
    {
        var randomPointIndex = mob.HouseNumber;
        return _spawnPoints[randomPointIndex].position;
    }
}
