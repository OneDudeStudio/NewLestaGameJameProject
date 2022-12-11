using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MobMovement))]
public abstract class Mob : MonoBehaviour
{
    [SerializeField] private float _health;

    [SerializeField] private int[] _trajectoryNumbers;
    public int HouseNumber { get; set; }
    
    [SerializeField] private GameObject _visualMale;
    [SerializeField] private GameObject _visualFemale;
    [SerializeField] protected AnimatorManager animatorMaleManager;
    [SerializeField] protected AnimatorManager animatorFemaleManager;
    protected AnimatorManager _actualAnimManager;
    
    private MobMovement _mobMovement;

    protected bool _canApplyDamage = true;
    
    public event Action<Mob> Died;

    private void Awake()
    {
        _mobMovement = GetComponent<MobMovement>();
        int num = Random.Range(0, 2);
        SetUpUnit(num == 0);
        
    }

    private void SetUpUnit(bool isFemale)
    {
        if (isFemale)
        {
            animatorFemaleManager.enabled = true;
            _visualFemale.SetActive(true);
            animatorFemaleManager.enabled = true;
            _visualFemale.SetActive(true);
            _actualAnimManager = animatorFemaleManager;
        }
        else
        {
            animatorMaleManager.enabled = true;
            _visualMale.SetActive(true);
            animatorFemaleManager.enabled = false;
            _visualFemale.SetActive(false);
            _actualAnimManager = animatorMaleManager;
        }
    }

    public void ApplyDamage()
    {
        if (!_canApplyDamage)
            return;
        _health--;

        if (_health <= 0)
        {  
            _mobMovement.Stop();
            Die();
        }
    }

    private void Die()
    {
        _actualAnimManager.SetDefeatAnimation();
        Died?.Invoke(this);
        DropLoot();
        _canApplyDamage = false;
        //
        Invoke(nameof(UnitRespawn),1f);
        
    }

    private void UnitRespawn()
    {
        gameObject.SetActive(false);
    }

    public void StartMovement()
    {
        _mobMovement.Restart();
    }
    protected abstract void DropLoot();

    public void setTrajectory(List<PathTrajectory> pathTrajectories)
    {
        var trajectoryIndex = Random.Range(0, pathTrajectories.Count);
        _mobMovement.SetTargetPoints(pathTrajectories[trajectoryIndex].GetTargetPoints());
    }

    public int[] GetTrajectoryNumbers() => _trajectoryNumbers;
}