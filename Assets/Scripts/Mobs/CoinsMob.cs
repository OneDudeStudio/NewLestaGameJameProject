using UnityEngine;
public class CoinsMob : Mob
{
    [SerializeField] private int _minCoins;
    [SerializeField] private int _maxCoins;
    [SerializeField] private GameObject _coinPrefab;
    private void Start()
    {
        _actualAnimManager.SetWalkAnimation();
    }

    protected override void DropLoot()
    {
        int coinsNum = Random.Range(_minCoins, _maxCoins + 1);
        
        for(int i=0; i< coinsNum; i++)
        {
            Instantiate(_coinPrefab, transform.position + new Vector3(Random.Range(-.7f, .7f), 0, Random.Range(-.7f, .7f)), Quaternion.identity);
        }
    }
}