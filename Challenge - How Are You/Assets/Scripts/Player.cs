using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement Config")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private InputActionReference moveAction;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator anim;

    private Vector2 finalMove;
    public static bool isDialoguePlaying;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        isDialoguePlaying = false;
    }
    
    void Update()
    {
        ReadInput();
        ApplyMovement();
        Animate();
    }

    private void ReadInput()
    {
        moveInput = moveAction.action.ReadValue<Vector2>().normalized;
    }

    private void ApplyMovement()
    {
        //if (dialogueManager.dialoguePlaying) return;
        if (isDialoguePlaying) return;
 
        Vector2 move = new Vector2(moveInput.x, moveInput.y);
        finalMove = move * moveSpeed;
        rb.linearVelocity = finalMove;

        if (finalMove.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (finalMove.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void Animate()
    {
        anim.SetInteger("pMoveX", (int)finalMove.x);
        anim.SetInteger("pMoveY", (int)finalMove.y);
    }
}
