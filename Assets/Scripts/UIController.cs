using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject _farmCanvas;
    public GameObject _pauseCanvas;
    public GameObject _gameWinCCanvas;
    public GameObject _shopCanvas;
    public TextMeshProUGUI _coinsText;
    public TextMeshProUGUI _coinsTextMain;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("STOP");
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Go");
            
        }
    }
    public void SetCanvasActive(GameObject objectToSpawn)
    {
        objectToSpawn.SetActive(true);
    }
    
    public void SetCanvasDeactive(GameObject objectToSpawn)
    {
        objectToSpawn.SetActive(false);
    }

    public void ChangeCoinsText(float num)
    {
        _coinsText.text = "Всего монет: " + num.ToString("0.00");
        _coinsTextMain.text = "Всего монет: " + num.ToString("0.00");
    }
}