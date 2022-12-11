using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private int _cardPrice = 5;
    [SerializeField] private int _priceAdding = 5;
    [SerializeField] private PlayerCards _playerCards;
    [SerializeField] private bool _isInShop = false;

    private void OnTriggerEnter(Collider other) => _isInShop = true;
    private void OnTriggerExit(Collider other) => _isInShop = false;
    
    public UIController UIController;


    private void Awake()
    {
        UIController = FindObjectOfType<UIController>();
    }


    private void Update()
    {
        if (_isInShop)
        {
            UIController.SetCanvasActive(UIController._shopCanvas);
        }
        else
        {
            UIController.SetCanvasDeactive(UIController._shopCanvas);
        }
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
        _cardPrice += _priceAdding;
        Debug.Log("Bying card");
    }

    private void NotEnoughMoney()
    {
        //������� � ui
        Debug.Log("Not enough Money");
    }
    private void AlreadyWithCard()
    {
        //������� � ui
        Debug.Log("Already with Card");
    }

}