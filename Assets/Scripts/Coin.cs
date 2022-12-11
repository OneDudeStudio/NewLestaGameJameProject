using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _cost = 1;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private Transform _coinBody;

    private void Start()
    {
        _rotSpeed += Random.Range(-0.5f, 0.5f);
    }

    private void FixedUpdate()
    {
        _coinBody.RotateAround(_coinBody.position,Vector3.up,_rotSpeed );
    }

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