using System;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private List<Mob> _mobsInAttackRange = new List<Mob>();

    [SerializeField] private Collider _attackCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Mob mob))
        {
            mob.ApplyDamage();
            Debug.LogError("ATTACKED");
            //_mobsInAttackRange.Add(mob);
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Mob mob))
        {
            _mobsInAttackRange.Remove(mob);
        }
    }

    public void TryAttack()
    {
        EnableCollider();
        Invoke(nameof(DisableCollider),0.5f);
        
        //if (_mobsInAttackRange.Count == 0)
        //    return;
        //foreach (Mob mob in _mobsInAttackRange)
        //{
        //    Debug.Log("Attack");
        //    mob.ApplyDamage();
        //}
    }

    public void EnableCollider()
    {
        _attackCollider.enabled =true;
    }

    public void DisableCollider()
    {
        _attackCollider.enabled =false;
    }
}