using UnityEngine;

public class PlayerCards : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private Transform _handTransform;
    private bool _isWithCard = false;
    [SerializeField] private AnimatorManager animatorManager;

    public bool IsWithCard() => _isWithCard;

    public void AddCard()
    {
        animatorManager.SetPickUpAnimation();
        _isWithCard = true;
        GameObject card = Instantiate(_cardPrefab, transform.position+Vector3.up*2, Quaternion.identity);
        card.transform.parent = _handTransform;
        card.transform.localPosition = Vector3.zero;
        card.transform.localRotation = Quaternion.identity;
    }

    public void RemoveCard()
    {
        animatorManager.SetPickUpAnimation();
        _isWithCard = false;
        Destroy(transform.GetChild(1).gameObject);
    }
}