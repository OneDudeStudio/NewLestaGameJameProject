using UnityEngine;

public class Farm : MonoBehaviour
{
    [SerializeField] private Home _home;
    [SerializeField] private int _maxCards = 5;
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private PlayerCards _playerCards;
    private int _cardCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (_playerCards.IsWithCard() && _cardCount < _maxCards)
        {
            _cardCount++;
            _home.AddCard();
            _playerCards.RemoveCard();
            GameObject card = Instantiate(_cardPrefab, transform.position, Quaternion.identity);
             if (card.TryGetComponent(out Card cardComp))
             {
                Destroy(cardComp);
             }
            card.transform.parent = transform.GetChild(_cardCount-1);
            card.transform.localPosition = Vector3.zero;          
        }
    }   
}
