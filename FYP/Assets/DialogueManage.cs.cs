using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManage : MonoBehaviour
{
    Npc npcInstance;  // Assuming Npc is a class, create an instance of it

    // Start is called before the first frame update
    public Npc npc; 

    bool isTalking = false;

    float distance;
    float curResponseTracker = 0;

    public GameObject player;
    public GameObject dialogueUi;

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;

    void Start()
    {
        dialogueUi.SetActive(false);

    }

    void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if(distance <= 2.5f)
        {
            if(Input.GetKeyDown(KeyCode.E) && isTalking==false)
            {
                StartConversation();
            }
            else if(Input.GetKeyDown(KeyCode.E) && isTalking==true)
            {
                EndDialogue();
            }
        } 
    }

    void StartConversation()
    {
        isTalking = true;
        curResponseTracker = 0;
        dialogueUi.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];   
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueUi.SetActive(false);
    }
}