using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;

    public void ChangeCoinsText(float num)
    {
        _coinsText.text = "Coins Now: " + num.ToString("0.00");
    }
}
