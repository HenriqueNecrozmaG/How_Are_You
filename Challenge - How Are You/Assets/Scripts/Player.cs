using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement Config")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private InputActionReference moveAction;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    public static bool isDialoguePlaying;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        isDialoguePlaying = false;
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
        //if (dialogueManager.dialoguePlaying) return;
        if (isDialoguePlaying) return;
 
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
