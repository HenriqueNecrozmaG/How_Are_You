using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;

public class CollaboratorsNew : MonoBehaviour
{
    [Header("Dialogue Config")]
    [SerializeField] private NPCDialogue dialogueData;
    [SerializeField] private DialogueChoice dialogueChoices;
    [SerializeField] private InputActionReference interactAction;
    [SerializeField] private SpriteRenderer speechBubble;

    [Header("Controller Buttons Config")]
    [SerializeField] private Button buttonUp;
    [SerializeField] private Button buttonDown;
    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;

    private DialogueController dialogueController;
    private int dialogueIndex;
    private bool isTyping, isDialogueActive, playerInRadius, interactQueued, isWaitingForTextInput;
    public static string lastPlayerInput = "";

    private enum  FirstInteractionState { NotInteracted, Interacted };
    private static FirstInteractionState firstInteractionState = FirstInteractionState.NotInteracted;

    void Start()
    {
        dialogueController = DialogueController.Instance;

        speechBubble.enabled = false;
        dialogueController.ShowDialogueUI(false);
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

        if (isWaitingForTextInput) return;

        if (dialogueData == null)
        {
            return;
        }

        if (isDialogueActive)
        {
            NextLine();
        }
        else
        {
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        
        if (firstInteractionState == FirstInteractionState.NotInteracted)
        {
            dialogueIndex = 0;
        }
        else
        {
            dialogueIndex = dialogueData.firstInteractionCompleteIndex;
        }

        dialogueController.SetNPCInfo(dialogueData.npcName, dialogueData.npcPortait);
        dialogueController.ShowDialogueUI(true);

        Player.isDialoguePlaying = true;
        buttonUp.interactable = false;
        buttonDown.interactable = false;
        buttonLeft.interactable = false;
        buttonRight.interactable = false;

        DisplayCurrentLine();
    }

    void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueController.SetDialogueText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }

        dialogueController.ClearChoices();

        if (dialogueData.endDialogueLines.Length > dialogueIndex && dialogueData.endDialogueLines[dialogueIndex])
        {
            EndDialogue();
            return;
        }

        foreach(DialogueChoice dialogueChoice in dialogueData.choices)
        {
            if(dialogueChoice.dialogueIndex == dialogueIndex)
            {
                DisplayChoices(dialogueChoice);
                return;
            }
        }

        if (++dialogueIndex < dialogueData.dialogueLines.Length)
        {
            DisplayCurrentLine();
        }
        else
        {
            EndDialogue();
        }
    }

   IEnumerator TypeLine()
   {
        isTyping = true;
        dialogueController.SetDialogueText("");

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueController.SetDialogueText(dialogueController.dialogueText.text += letter);
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        isTyping = false;

        if (dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogueData.autoProgressDelay);
            NextLine();
        }
   }

    void DisplayChoices(DialogueChoice choice)
    {
        for (int i = 0; i < choice.choices.Length; i++)
        {
            int nextIndex = choice.nextDialogueIndexes[i];
            bool needsInput = choice.requiresTextInput != null
                && choice.requiresTextInput.Length > i
                && choice.requiresTextInput[i];

            if (needsInput)
            {
                dialogueController.CreateChoiceButton(choice.choices[i], () => RequestTextInput(nextIndex));
            }
            else
            {
                dialogueController.CreateChoiceButton(choice.choices[i], () => ChooseOption(nextIndex));
            }
        }
    }

    void RequestTextInput(int nextIndex)
    {
        dialogueController.ClearChoices();
        isWaitingForTextInput = true;

        dialogueController.ShowTextInput((enteredText) =>
        {
            lastPlayerInput = enteredText;
            isWaitingForTextInput = false;
            ChooseOption(nextIndex);
        });
    }

    void ChooseOption(int nextIndex)
    { 
        dialogueIndex = nextIndex;
        dialogueController.ClearChoices();
        DisplayCurrentLine();
    }

    void DisplayCurrentLine()
    {
        StopAllCoroutines();
        StartCoroutine(TypeLine());
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        
        isDialogueActive = false;
        dialogueController.SetDialogueText("");
        dialogueController.ShowDialogueUI(false);
        
        Player.isDialoguePlaying = false;
        
        buttonUp.interactable = true;
        buttonDown.interactable = true;
        buttonLeft.interactable = true;
        buttonRight.interactable = true;

        if (firstInteractionState == FirstInteractionState.NotInteracted)
        {
            firstInteractionState = FirstInteractionState.Interacted;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRadius = true;
            speechBubble.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRadius = false;
            speechBubble.enabled = false;
        }
    }
}
