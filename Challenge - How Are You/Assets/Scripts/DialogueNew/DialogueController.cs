using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueController : MonoBehaviour
{
    public static DialogueController Instance { get; private set; }

    [Header("Dialogue Canvas Config")]
    public Canvas dialogueCanvas;
    public TextMeshProUGUI collaboratorNameText;
    public TextMeshProUGUI dialogueText;
    public Image portraitImage;

    [Header("Choices Config")]
    public Transform choiceContainer;
    public GameObject choiceButtonPrefab;

    [Header("Text Input Config")]
    public GameObject textInputPanel;
    public TMP_InputField textInputField;
    public Button textInputSubmitButton;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        textInputPanel.SetActive(false);
    }

    public void ShowDialogueUI(bool show)
    {
        dialogueCanvas.enabled = show;
    }

    public void SetNPCInfo(string npcName, Sprite portrait)
    {
        collaboratorNameText.text = npcName;
        portraitImage.sprite = portrait;
    }

    public void SetDialogueText(string text)
    {
        dialogueText.text = text;
    }

    public void ClearChoices()
    {
        foreach (Transform child in choiceContainer) Destroy(child.gameObject);
    }

    public void CreateChoiceButton(string choiceText, UnityAction onClick)
    {
        GameObject choiceButton = Instantiate(choiceButtonPrefab, choiceContainer);
        choiceButton.GetComponentInChildren<TextMeshProUGUI>().text = choiceText;
        choiceButton.GetComponent<Button>().onClick.AddListener(onClick);
    }

    public void ShowTextInput(UnityAction<string> onSubmit)
    {
        textInputPanel.SetActive(true);
        textInputField.text = "";
        textInputField.Select();
        textInputField.ActivateInputField();

        textInputSubmitButton.onClick.RemoveAllListeners();
        textInputSubmitButton.onClick.AddListener(() =>
        {
            string enteredText = textInputField.text;
            textInputPanel.SetActive(false);
            onSubmit(enteredText);
        });
    }
}
