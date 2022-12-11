using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private int _graphicsCardMaxNum = 30;
    [SerializeField] private Mining _mining;
    private int _totalCards = 0;

    public void AddCard()
    {
        if (_totalCards < _graphicsCardMaxNum - 1)
        {
            _totalCards++;
            _mining.AddGraphicsCard();
            return;
        }
        EndOfGame();
    }

    private void EndOfGame()
    {
        Debug.Log("end");
    }
}
