using UnityEngine;

public class Card : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerCards playerCards))
        {
            if (!playerCards.IsWithCard())
            {
                playerCards.AddCard();
                //particles
                Destroy(gameObject);
            }            
        }
    }
}
