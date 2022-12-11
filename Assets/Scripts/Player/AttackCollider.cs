using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private List<Mob> _mobsInAttackRange = new List<Mob>();


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Mob mob))
        {
            _mobsInAttackRange.Add(mob);
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
        if (_mobsInAttackRange.Count == 0)
            return;
        foreach (Mob mob in _mobsInAttackRange)
        {
            mob.ApplyDamage();
        }
    }
}
