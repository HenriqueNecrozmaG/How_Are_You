using System.Collections;
using UnityEngine;

public class PlateOrder : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(MinigameManager.orderValue[MinigameManager.plateNumber] == MinigameManager.plateValue[MinigameManager.plateNumber])
        {
            print("Correct" + " " + MinigameManager.orderTime[MinigameManager.plateNumber]);
            UIMinigame.score += 10;
            StartCoroutine(CleanPlate());
            audioSource.Play();
        }
        MinigameManager.emptyPlate = transform.position.x;
        StartCoroutine(DiscardWrong());
    }

    IEnumerator CleanPlate()
    {
        yield return new WaitForSeconds(0.2f);
        MinigameManager.emptyPlate = 1;
        if (MinigameManager.plateNumber == 0)
        {
            MinigameManager.orderTime[0] = 0;
        }
        if (MinigameManager.plateNumber == 1)
        {
            MinigameManager.orderTime[1] = 0;
        }
        if (MinigameManager.plateNumber == 2)
        {
            MinigameManager.orderTime[2] = 0;
        }
        if (MinigameManager.plateNumber == 3)
        {
            MinigameManager.orderTime[3] = 0;
        }
        if (MinigameManager.plateNumber == 4)
        {
            MinigameManager.orderTime[4] = 0;
        }
    }

    IEnumerator DiscardWrong()
    {
        yield return new WaitForSeconds(0.2f);
        MinigameManager.emptyPlate = 1;
        if(MinigameManager.plateNumber == 0)
        {
            MinigameManager.plateValue[0] = 0;
        }
        if (MinigameManager.plateNumber == 1)
        {
            MinigameManager.plateValue[1] = 0;
        }
        if (MinigameManager.plateNumber == 2)
        {
            MinigameManager.plateValue[2] = 0;
        }
        if (MinigameManager.plateNumber == 3)
        {
            MinigameManager.plateValue[3] = 0;
        }
        if (MinigameManager.plateNumber == 4)
        {
            MinigameManager.plateValue[4] = 0;
        }
    }
}
