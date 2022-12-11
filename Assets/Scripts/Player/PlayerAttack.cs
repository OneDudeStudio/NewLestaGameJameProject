using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private AttackCollider _attackCollider;
    [SerializeField] private float _attackCoolDown;
    [SerializeField] private float _timeFromLastAttack;
    

    private void Update()
    {
        _timeFromLastAttack += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_timeFromLastAttack >= _attackCoolDown)
            {
                Attack();
                Debug.Log("ATTACK");
                _timeFromLastAttack = 0;
            }
            
        }
    }
    public void Attack()
    {
        //anim
        _attackCollider.TryAttack();
    }
}