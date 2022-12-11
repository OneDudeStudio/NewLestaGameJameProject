using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : Rotator
{
    [SerializeField] private int _cost = 1;
    [SerializeField] private Transform _coinBody;

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