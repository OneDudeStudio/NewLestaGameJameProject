using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private int _cardPrice = 26;
    [SerializeField] private PlayerCards _playerCards;
    [SerializeField] private bool _isInShop = false;

    private void OnTriggerEnter(Collider other) => _isInShop = true;
    private void OnTriggerExit(Collider other) => _isInShop = false;


    private void Update()
    {
        if (!_isInShop)
            return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryBuyCard();
        }
    }

    public void TryBuyCard()
    {
        if (_playerCards.IsWithCard())
        {
            AlreadyWithCard();
            return;
        }
        bool res = _wallet.TryBuy(_cardPrice);
        if (res)
            AddCard();
        else
            NotEnoughMoney();
    }

    private void AddCard()
    {
        Debug.Log("Bying card");
    }

    private void NotEnoughMoney()
    {
        //текстом в ui
        Debug.Log("Not enough Money");
    }
    private void AlreadyWithCard()
    {
        //текстом в ui
        Debug.Log("Already with Card");
    }

}
