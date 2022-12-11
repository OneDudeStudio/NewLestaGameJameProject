using System.Collections;
using UnityEngine;

public class Mining : MonoBehaviour
{
    private bool _isMining = true;
    private int _graphicsCardNum = 0;
    [SerializeField] private int _graphicsCardMaxNum = 5;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private float _graphicsCardCooldown = 10f;
    [SerializeField] private int _moneyPerCard;

    private void Start()
    {
        StartCoroutine(MiningCoroutine());
    }
    public IEnumerator MiningCoroutine()
    {
        while (_isMining) {
            yield return new WaitForSeconds(_graphicsCardCooldown);
            _wallet.AddMoney(_moneyPerCard * _graphicsCardNum);
        }        
    }
    public bool TryAddGraphicsCard()
    {
        if(_graphicsCardNum < _graphicsCardMaxNum)
        {
            _graphicsCardNum++;
            return true;
        }
        return false;
    }
}
