using UnityEngine;

public class PlayerCards : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;
    private bool _isWithCard = false;

    public bool IsWithCard() => _isWithCard;

    public void AddCard()
    {
        _isWithCard = true;
        GameObject card = Instantiate(_cardPrefab, transform.position+Vector3.up, Quaternion.identity);
        card.GetComponent<Card>().StopRotation();
        card.transform.parent = transform;
        card.transform.localRotation = transform.rotation;
        
    }

    public void RemoveCard()
    {
        _isWithCard = false;
        Destroy(transform.GetChild(1).gameObject);
    }
}
