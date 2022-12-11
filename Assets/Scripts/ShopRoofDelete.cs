using UnityEngine;

public class ShopRoofDelete : MonoBehaviour
{
    [SerializeField] private GameObject _roof;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerCards pl))
        {
            _roof.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _roof.SetActive(true);
    }
}
