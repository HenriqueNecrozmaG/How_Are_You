using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameLoader : MonoBehaviour
{
    [SerializeField] private Canvas canvasLoadMinigame;

    
    void Start()
    {
        canvasLoadMinigame.enabled = false;
    }

    public void LoadMinigame()
    {
        SceneManager.LoadScene("MinigameScene");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canvasLoadMinigame.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canvasLoadMinigame.enabled = true;
        }
    }
}
