using UnityEngine;

public class PickBurger : MonoBehaviour
{
    public GameObject burger;
    public static int placedBurgers;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (gameObject.tag == "Burger")
        {
            if(placedBurgers < 1)
            {
                Instantiate(burger, new Vector2(6, 1.5f), burger.transform.rotation);
                placedBurgers += 1;
            }
        }
    }
}