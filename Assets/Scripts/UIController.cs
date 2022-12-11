using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;

    public void ChangeCoinsText(int num)
    {
        _coinsText.text = "Coins Now: " + num;
    }
}
