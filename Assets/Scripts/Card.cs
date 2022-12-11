using UnityEngine;

public class Card : Rotator
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
