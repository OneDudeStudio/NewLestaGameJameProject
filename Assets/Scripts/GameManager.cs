using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int m_targetFrameRate;
    
    public UIController UIController;
    public Image buttonSoundImage;
    public Sprite soundOn;
    public Sprite soundOff;
    public bool soundIsOff ;


    private void Awake()
    {
        //UIController = FindObjectOfType<UIController>();
        Time.timeScale = 1;
    }
    private void OnValidate()
    {
        Application.targetFrameRate = m_targetFrameRate;
    }

    public void ShowSettings()
    {
        UIController.SetCanvasActive(UIController._pauseCanvas);
        Time.timeScale = 0;
    }
    public void HideSettings()
    {
        UIController.SetCanvasDeactive(UIController._pauseCanvas);
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void SoundMute()
    {
        if (soundIsOff)
        {
            AudioListener.volume =1;
            buttonSoundImage.sprite = soundOn;
            soundIsOff = false;
        }
        else
        {
            AudioListener.volume =0;
            buttonSoundImage.sprite = soundOff;
            soundIsOff = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}