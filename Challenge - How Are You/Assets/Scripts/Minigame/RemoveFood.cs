using UnityEngine;

public class RemoveFood : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if((MinigameManager.emptyPlate > transform.position.x - 0.1f) && (MinigameManager.emptyPlate < transform.position.x + 0.1f))
        {
            Destroy(gameObject);
        }
    }
}