using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Mining _mining;
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private PlayerCards _playerCards;
    private int _cardCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (_playerCards.IsWithCard())
        {
            _cardCount++;
            _playerCards.RemoveCard();
            Debug.Log("карта поставлена");
            if (!_mining.TryAddGraphicsCard())
            {
                Debug.Log("Затычка");
                return;
            }

            GameObject card = Instantiate(_cardPrefab, transform.position + Vector3.up*_cardCount*1.1f, Quaternion.identity);
            card.transform.parent = transform;
            //visual            
        }
    }   
}
