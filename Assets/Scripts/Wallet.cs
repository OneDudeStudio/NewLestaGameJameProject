using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _money = 100;
    
    [SerializeField] private UIController _uiController;
    private PlayerCards _playerCards;

    private void Start() => _playerCards = GetComponent<PlayerCards>();
   
    public bool TryBuy(int price)
    {
        if(_money-price >= 0)
        {
            _money -= price;
            _uiController.ChangeCoinsText(_money);
            _playerCards.AddCard();
            return true;
        }
        return false;
    }

    public void AddMoney(int money)
    {
        _money += money;
        _uiController.ChangeCoinsText(_money);
    }    
}
