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
        textOrder1.text = MinigameManager.orderTime[0].ToString();
        textOrder2.text = MinigameManager.orderTime[1].ToString();
        textOrder3.text = MinigameManager.orderTime[2].ToString();
        textOrder4.text = MinigameManager.orderTime[3].ToString();
        textOrder5.text = MinigameManager.orderTime[4].ToString();
        canvasPause.enabled = false;
        StartCoroutine(Timer(1));
        textScore.text = "Pontuação: " + score;
        textTime.text = "Tempo: " + time;
        canvasConfigurations.enabled = false;
    }

    void Update()
    {
        textOrder1.text = MinigameManager.orderTime[0].ToString();
        textOrder2.text = MinigameManager.orderTime[1].ToString();
        textOrder3.text = MinigameManager.orderTime[2].ToString();
        textOrder4.text = MinigameManager.orderTime[3].ToString();
        textOrder5.text = MinigameManager.orderTime[4].ToString();
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

    public void CloseeConfigurations()
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