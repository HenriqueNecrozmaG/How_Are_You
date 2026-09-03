using Ink.Runtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialoguePanelUI : MonoBehaviour
{
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private DialogueChoiceButton[] choiceButtons;

    void Awake()
    {
        dialogueCanvas.enabled = false;
        ResetPanel();
    }

    private void OnEnable()
    {
        GameManager.Instance.dialogueEvents.onDialogueStarted += DialogueStarted;
        GameManager.Instance.dialogueEvents.onDialogueFinished += DialogueFinished;
        GameManager.Instance.dialogueEvents.onDisplayDialogue += DisplayDialogue;
    }

    private void OnDisable()
    {
        GameManager.Instance.dialogueEvents.onDialogueStarted -= DialogueStarted;
        GameManager.Instance.dialogueEvents.onDialogueFinished -= DialogueFinished;
        GameManager.Instance.dialogueEvents.onDisplayDialogue -= DisplayDialogue;
    }

    private void DialogueStarted()
    {
        dialogueCanvas.enabled = true;
    }

    private void DialogueFinished()
    {
        dialogueCanvas.enabled = false;
        ResetPanel();
    }

    private void DisplayDialogue(string dialogueLine, List<Choice> dialogueChoices)
    {
        dialogueText.text = dialogueLine;

        if (dialogueChoices.Count > choiceButtons.Length)
        {
            Debug.LogError("More dialogue choices ("
            + dialogueChoices.Count + ") came through than supported ("
            + choiceButtons.Length + ")");
        }

        foreach (DialogueChoiceButton choiceButton in choiceButtons)
        {
            choiceButton.gameObject.SetActive(false);
        }

        int choiceButtonIndex = dialogueChoices.Count - 1;

        for (int inkChoiceIndex = 0; inkChoiceIndex < dialogueChoices.Count; inkChoiceIndex++)
        {
            Choice dialogueChoice = dialogueChoices[inkChoiceIndex];
            DialogueChoiceButton choiceButton = choiceButtons[choiceButtonIndex];

            choiceButton.gameObject.SetActive(true);
            choiceButton.SetChoiceText(dialogueChoice.text);
            choiceButton.SetChoiceIndex(inkChoiceIndex);

            if (inkChoiceIndex == 0)
            {
                choiceButton.SelectButton();
                GameManager.Instance.dialogueEvents.UpdateChoiceIndex(0);
            }

            choiceButtonIndex--;
        }
    }

    private void ResetPanel()
    {
        dialogueText.text = "";
    }
}
