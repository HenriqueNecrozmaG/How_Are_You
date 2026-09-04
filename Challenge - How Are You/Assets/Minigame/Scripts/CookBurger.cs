using System.Collections;
using UnityEngine;

public class CookBurger : MonoBehaviour
{
    int foodValue;
    SpriteRenderer sr;
    bool isCooking = true;
    public bool isCooked;
    bool isBurnt;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(Cook());
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        PickBurger.placedBurgers -= 1;
        if (isBurnt)
        {
            Destroy(gameObject);
        }

        if (isCooking)
        {
            MinigameManager.plateValue[MinigameManager.plateNumber] += foodValue;
            print(MinigameManager.plateValue[MinigameManager.plateNumber] + " " + MinigameManager.orderValue[MinigameManager.plateNumber]);
        }

        transform.position = new Vector2(MinigameManager.plateXPosition, -4.25f);
        isCooking = false;
    }

    IEnumerator Cook()
    {
        yield return new WaitForSeconds(5);
        if(isCooking)
        {
            foodValue = 1000;
            sr.color = new Color32(120, 50, 50, 255);
            isCooked = true;
        }
        yield return new WaitForSeconds(5);
        if (isCooking)
        {
            foodValue = 0;
            sr.color = Color.black;
            isCooked = false;
            isBurnt = true;
        }
    }
}