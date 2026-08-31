using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private Canvas canvasGame;
    [SerializeField] private Canvas canvasPause;
    [SerializeField] private Canvas canvasConfigurations;

    void Start()
    {
        canvasGame.enabled = true;
        canvasPause.enabled = false;
        canvasConfigurations.enabled = false;
    }

    public void Pause()
    {
        canvasPause.enabled = true;
        canvasGame.enabled = false;
        Time.timeScale = 0;
    }

    public void Play()
    {
        canvasPause.enabled = false;
        canvasGame.enabled = true;
        Time.timeScale = 1;
    }

    public void Configurations()
    {
        canvasConfigurations.enabled = true;
        canvasPause.enabled = false;
    }

    public void CloseConfigurations()
    {
        canvasConfigurations.enabled = false;
        canvasPause.enabled = true;
    }

    public void Customize()
    {
        print("Customize");
    }

    public void Quit()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
