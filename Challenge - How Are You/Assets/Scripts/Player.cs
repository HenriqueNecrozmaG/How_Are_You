using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] DialogueManager dialogueManager;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        ReadInput();
        ApplyMovement();
    }

    private void ReadInput()
    {
        moveInput = moveAction.action.ReadValue<Vector2>().normalized;
    }

    private void ApplyMovement()
    {
        if (dialogueManager.dialoguePlaying) return;
 
        Vector2 move = transform.right * moveInput.x + transform.up * moveInput.y;
        Vector2 finalMove = move * moveSpeed;
        rb.linearVelocity = finalMove;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveInput.x = 0;
        moveInput.y = 0;
    }
}
