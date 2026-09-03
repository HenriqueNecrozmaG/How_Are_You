using UnityEngine;
using Ink.Runtime;
using UnityEngine.InputSystem;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private InputActionReference interactAction;
    
    [Header("Ink Story")]
    [SerializeField] private TextAsset inkJson;

    private Story story;
    private int currentChoiceIndex = -1;

    public bool dialoguePlaying = false;
    bool interactQueued;

    void Awake()
    {
        story = new Story(inkJson.text);
        interactQueued = false;
    }

    void OnEnable()
    {
        GameManager.Instance.dialogueEvents.onEnterDialogue += EnterDialogue;
        GameManager.Instance.dialogueEvents.onUpdateChoiceIndex += UpdateChoiceIndex;
    }

    void OnDisable()
    {
        GameManager.Instance.dialogueEvents.onEnterDialogue -= EnterDialogue;
        GameManager.Instance.dialogueEvents.onUpdateChoiceIndex -= UpdateChoiceIndex;

    }

    private void UpdateChoiceIndex(int choiceIndex)
    {
        this.currentChoiceIndex = choiceIndex;
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

        if (!dialoguePlaying) return;

        ContinueOrExitStory();
    }

    void EnterDialogue(string knotName)
    {
        if (dialoguePlaying)
        {
            return;
        }
        
        dialoguePlaying = true;
        GameManager.Instance.dialogueEvents.DialogueStarted();

        if (!knotName.Equals(""))
        {
            story.ChoosePathString(knotName);
        }
        else
        {
            Debug.Log("Knot name is empty");
        }
    }

    void ContinueOrExitStory()
    {
        if (story.currentChoices.Count > 0 && currentChoiceIndex != -1)
        {
            story.ChooseChoiceIndex(currentChoiceIndex);
            currentChoiceIndex = -1;
        }

        if (story.canContinue)
        {
            string dialogueLine = story.Continue();

            GameManager.Instance.dialogueEvents.DisplayDialogue(dialogueLine, story.currentChoices);
        }
        else if(story.currentChoices.Count == 0)
        {
            StartCoroutine(ExitDialogue());
        }
    }

    IEnumerator ExitDialogue()
    {
        yield return null;

        dialoguePlaying = false;
        GameManager.Instance.dialogueEvents.DialogueFinished();

        story.ResetState();
    }
}
