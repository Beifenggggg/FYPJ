using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    bool isTalking = false;
    float distance;

    public GameObject player;
    public GameObject dialogueUi;

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;

    public Button[] optionButtons;  // Player response buttons

    public float maxConversationDistance = 2.5f;

    private int selectedOptionIndex = -1;

    // Dummy NPC class for demonstration
    public class Npc
    {
        public string name;
        public string[] dialogue;
        public string[] playerOptions;
    }

    void Start()
    {
        // Set up button click listeners
        for (int i = 0; i < optionButtons.Length; i++)
        {
            int index = i;  // Store the index to avoid closure issues
            optionButtons[i].onClick.AddListener(() => OnOptionSelected(index));
        }
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player is not assigned. Make sure to assign them in the inspector.");
            return;
        }

        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= maxConversationDistance)
        {
            if (Input.GetKeyDown(KeyCode.P) && !isTalking)
            {
                StartConversation();
            }
            else if (Input.GetKeyDown(KeyCode.P) && isTalking)
            {
                EndDialogue();
            }
        }
        else
        {
            if (dialogueUi != null)
                dialogueUi.SetActive(false);
        }
    }

    void StartConversation()
    {
        isTalking = true;
        if (dialogueUi != null)
            dialogueUi.SetActive(true);

        // Replace with your NPC data
        Npc npc = new Npc
        {
            name = "NPC Name",
            dialogue = new string[] { "Hello!", "How are you?" },
            playerOptions = new string[] { "Good", "Not so good" }
        };

        npcName.text = npc.name;

        if (npc.dialogue.Length > 0)
            npcDialogueBox.text = npc.dialogue[0];
        else
            Debug.LogWarning("No dialogue set for the NPC.");

        DisplayPlayerOptions(npc);
    }

    void EndDialogue()
    {
        isTalking = false;
        if (dialogueUi != null)
            dialogueUi.SetActive(false);
    }

    void DisplayPlayerOptions(Npc npc)
    {
        ClearOptions();

        // Display only one option (if available)
        if (npc.playerOptions.Length > 0)
        {
            optionButtons[0].gameObject.SetActive(true);
            optionButtons[0].GetComponentInChildren<Text>().text = npc.playerOptions[0];
        }
    }

    void ClearOptions()
    {
        foreach (Button optionButton in optionButtons)
        {
            optionButton.gameObject.SetActive(false);
        }
    }

    void OnOptionSelected(int optionIndex)
    {
        selectedOptionIndex = optionIndex;
        string optionText = "Player: " + optionButtons[optionIndex].GetComponentInChildren<Text>().text;
        playerResponse.text = optionText;

        // Handle the selected option here

        // For demonstration purposes, let's display the next NPC dialogue
        DisplayNextDialogue();
    }

    void DisplayNextDialogue()
    {
        // Logic to display the next dialogue based on the selected option
        // For simplicity, let's just display the next dialogue in the NPC's dialogue array
        // Update npcDialogueBox.text with the next dialogue.
        // If there are no more dialogues, you can end the conversation.
    }
}
