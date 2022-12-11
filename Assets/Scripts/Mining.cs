using System.Collections;
using UnityEngine;

public class Mining : MonoBehaviour
{
    private bool _isMining = true;
    private int _graphicsCardNum = 0;
    [SerializeField] private int _graphicsCardMaxNum = 30;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private float _graphicsCardCooldown = 1f;
    [SerializeField] private float _moneyPerCard = .05f;

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

    public void AddGraphicsCard()
    {
        _graphicsCardNum++;
    }
}
