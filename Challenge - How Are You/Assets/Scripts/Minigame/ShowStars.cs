using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowStars : MonoBehaviour
{
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;

    void Start()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
    }

    void Update()
    {
        if(UIMinigame.score >= 30)
        {
            star1.SetActive(true);
        }
        if (UIMinigame.score >= 60)
        {
            star2.SetActive(true);
        }
        if (UIMinigame.score >= 90)
        {
            star3.SetActive(true);
        }
    }

    public void ReturnToGame()
    {
        SceneManager.LoadScene("GameScreen");
    }
}