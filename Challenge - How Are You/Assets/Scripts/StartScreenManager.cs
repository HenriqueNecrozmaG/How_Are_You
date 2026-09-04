using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] private Canvas canvasConfigurations;

    void Start()
    {
        canvasConfigurations.enabled = false;
    }

    public void Play()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameScreen");
    }

    public void Configurations()
    {
        canvasConfigurations.enabled = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void CloseConfigurations()
    {
        canvasConfigurations.enabled = false;
    }
}
