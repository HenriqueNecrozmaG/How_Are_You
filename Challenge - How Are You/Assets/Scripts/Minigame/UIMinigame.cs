using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMinigame : MonoBehaviour
{
    public static int score;
    [SerializeField] TextMeshProUGUI textScore;
    public static int time;
    [SerializeField] TextMeshProUGUI textTime;
    [SerializeField] Canvas canvasPause;
    [SerializeField] Button buttonPause;
    [SerializeField] TextMeshProUGUI textOrder1;
    [SerializeField] TextMeshProUGUI textOrder2;
    [SerializeField] TextMeshProUGUI textOrder3;
    [SerializeField] TextMeshProUGUI textOrder4;
    [SerializeField] TextMeshProUGUI textOrder5;
    [SerializeField] private Canvas canvasConfigurations;

    void Start()
    {
        score = 0;
        time = 120;

        int order1Time = (int)MinigameManager.orderTime[0];
        int order2Time = (int)MinigameManager.orderTime[1];
        int order3Time = (int)MinigameManager.orderTime[2];
        int order4Time = (int)MinigameManager.orderTime[3];
        int order5Time = (int)MinigameManager.orderTime[4];

        textOrder1.text = order1Time.ToString();
        textOrder2.text = order2Time.ToString();
        textOrder3.text = order3Time.ToString();
        textOrder4.text = order4Time.ToString();
        textOrder5.text = order5Time.ToString();

        canvasPause.enabled = false;
        StartCoroutine(Timer(1));
        textScore.text = "Pontuação: " + score;
        textTime.text = "Tempo: " + time;
        canvasConfigurations.enabled = false;
    }

    void Update()
    {
        int order1Time = (int)MinigameManager.orderTime[0];
        int order2Time = (int)MinigameManager.orderTime[1];
        int order3Time = (int)MinigameManager.orderTime[2];
        int order4Time = (int)MinigameManager.orderTime[3];
        int order5Time = (int)MinigameManager.orderTime[4];

        textOrder1.text = order1Time.ToString();
        textOrder2.text = order2Time.ToString();
        textOrder3.text = order3Time.ToString();
        textOrder4.text = order4Time.ToString();
        textOrder5.text = order5Time.ToString();

        textTime.text = "Tempo: " + time;
        textScore.text = "Pontuação: " + score;
        if (time <= 0)
        {
            SceneManager.LoadScene("ResultsScene");
        }
    }

    public void Pause()
    {
        canvasPause.enabled = true;
        buttonPause.enabled = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        canvasPause.enabled = false;
        buttonPause.enabled = true;
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScreen");
    }

    public void Configurations()
    {
        canvasConfigurations.enabled = true;
    }

    public void CloseConfigurations()
    {
        canvasConfigurations.enabled = false;
    }

    IEnumerator Timer(float t)
    {
        yield return new WaitForSeconds(t);
        time--;
        StartCoroutine(Timer(t));
    }
}