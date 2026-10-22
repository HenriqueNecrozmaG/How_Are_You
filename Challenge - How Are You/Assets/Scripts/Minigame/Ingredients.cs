using UnityEngine;

public class Ingredients : MonoBehaviour
{
    public GameObject ingredient;
    public int foodValue;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(gameObject.tag == "Bread")
        {
            Instantiate(ingredient, new Vector2(MinigameManager.plateXPosition, -4.25f), ingredient.transform.rotation);
        }
        if (gameObject.tag == "Cheese")
        {
            Instantiate(ingredient, new Vector2(MinigameManager.plateXPosition, -4.25f), ingredient.transform.rotation);
        }
        if (gameObject.tag == "Lettuce")
        {
            Instantiate(ingredient, new Vector2(MinigameManager.plateXPosition, -4.25f), ingredient.transform.rotation);
        }
        if (gameObject.tag == "Tomato")
        {
            Instantiate(ingredient, new Vector2(MinigameManager.plateXPosition, -4.25f), ingredient.transform.rotation);
        }
        MinigameManager.plateValue[MinigameManager.plateNumber] += foodValue;
        print(MinigameManager.plateValue[MinigameManager.plateNumber] + " " + MinigameManager.orderValue[MinigameManager.plateNumber]);
    }
}
