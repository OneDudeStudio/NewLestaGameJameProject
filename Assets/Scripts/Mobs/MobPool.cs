using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MobPool : MonoBehaviour
{
    [SerializeField] private List<Mob> _mobs;

    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<PathTrajectory> _trajectories;
    
    private const int _coinsMobCooldownInMilliseconds = 10000;

    private const int _minerMobCooldownInSeconds = 45;

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

        for (var i = _spawnPoints.Count; i < _mobs.Count; i++)
        {
            var spawnPosition = GetSpawnPosition(_mobs[i]);
            SpawnMob(_mobs[i], spawnPosition);
        }
    }

    private async void WaitAndRespawnMob(Mob mob)
    {
        mob.gameObject.SetActive(false);
        
        if (mob is MinerMob)
            await Task.Delay(_minerMobCooldownInSeconds * 1000);
        else
            await Task.Delay(_coinsMobCooldownInMilliseconds);

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
        if (mob is MinerMob)
        {
            mob.setTrajectory(_trajectories);
            return;
        }
        
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
        var randomPointIndex = mob is MinerMob
            ? Random.Range(0, _spawnPoints.Count)
            : mob.HouseNumber;
        
        return _spawnPoints[randomPointIndex].position;
    }
}