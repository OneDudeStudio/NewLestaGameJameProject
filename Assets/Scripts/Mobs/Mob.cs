using System;
using UnityEngine;

[RequireComponent(typeof(MobMovement))]
public abstract class Mob : MonoBehaviour
{
    [SerializeField] private float _health;

    private MobMovement _mobMovement;

    protected bool _canApplyDamage = true;

    public event Action<Mob> Died;

    private void Awake()
    {
        _mobMovement = GetComponent<MobMovement>();
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
        Died?.Invoke(this);
        DropLoot();
        _canApplyDamage = false;
        //
        gameObject.SetActive(false);
    }

    public void StartMovement()
    {
        _mobMovement.Restart();
    }
    protected abstract void DropLoot();
}