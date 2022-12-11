using UnityEngine;

public class Coin : Rotator
{
    [SerializeField] private int _cost = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Wallet wallet))
        {
            wallet.AddMoney(_cost);
            //particles
            Destroy(gameObject);
        }
    }
}