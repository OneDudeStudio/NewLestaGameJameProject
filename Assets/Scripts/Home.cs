using System;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private int _graphicsCardMaxNum = 30;
    [SerializeField] private Mining _mining;
    private int _totalCards = 0;
    
    public UIController UIController;


    private void Awake()
    {
        UIController = FindObjectOfType<UIController>();
        Time.timeScale = 1;
    }

    private void Update()
    {
        Debug.Log("SDSDDS");
    }


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
        UIController.SetCanvasActive(UIController._gameWinCCanvas);
        Time.timeScale = 0;
        Debug.Log("end");
    }
}