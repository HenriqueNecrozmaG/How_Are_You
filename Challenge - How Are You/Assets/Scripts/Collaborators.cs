using UnityEngine;
using UnityEngine.InputSystem;

public class Collaborators : MonoBehaviour
{
    [SerializeField] private InputActionReference interactAction;
    [SerializeField] private string dialogueKnotName;
    [SerializeField] private SpriteRenderer speechBubble;

    bool interactQueued;
    bool playerInRadius;

    void Start()
    {
        speechBubble.enabled = false;
    }

    void Update()
    {
        ReadInput();
        InteractPressed();
    }

    void ReadInput()
    {
        if (interactAction.action.WasPressedThisFrame())
        {
            interactQueued = true;
        }
    }

    void InteractPressed()
    {
        if (!interactQueued) return;
        interactQueued = false;

        if (!playerInRadius) return;

        if (!dialogueKnotName.Equals(""))
        {
            GameManager.Instance.dialogueEvents.EnterDialogue(dialogueKnotName);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRadius = true;
            speechBubble.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        playerInRadius = false;
        speechBubble.enabled = false;
    }
}
