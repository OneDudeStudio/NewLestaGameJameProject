using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int m_targetFrameRate;
    private void OnValidate()
    {
        Application.targetFrameRate = m_targetFrameRate;
    }
}