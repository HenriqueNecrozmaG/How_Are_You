using UnityEngine;

[CreateAssetMenu(fileName = "NPCDialogue", menuName = "NPCDialogue")]
public class NPCDialogue : ScriptableObject
{
    [Header("Dialogue Config")]
    public string npcName;
    public Sprite npcPortait;
    public string[] dialogueLines;
    public bool[] autoProgressLines;
    public bool[] endDialogueLines;
    public float autoProgressDelay = 1.5f;
    public float typingSpeed = 0.05f;

    [Header("Choices Config")]
    public DialogueChoice[] choices;

    [Header("First Interaction Config")]
    public int firstInteractionCompleteIndex;
}

[System.Serializable]

public class DialogueChoice
{
    public int dialogueIndex;
    public string[] choices;
    public int[] nextDialogueIndexes;
    public bool[] requiresTextInput;
}