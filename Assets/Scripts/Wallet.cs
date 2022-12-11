using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private float _money = 100;
    
    [SerializeField] private UIController _uiController;
    private PlayerCards _playerCards;

    private void Start() => _playerCards = GetComponent<PlayerCards>();
   
    public bool TryBuy(float price)
    {
        if(_money-price >= 0)
        {
            _money -= price;
            Math.Round(_money, 2);
            _uiController.ChangeCoinsText(_money);
            _playerCards.AddCard();
            return true;
        }
        return false;
    }

    public void AddMoney(float money)
    {
        _money += money;
        Math.Round(_money, 2);
        _uiController.ChangeCoinsText(_money);
    }    
}
