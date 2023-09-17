using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager: MonoBehaviour
{
    // Start is called before the first frame update
  public NPC npc; 

  bool isTalking = false;

  float distance;

  public GameObject player;
  public GameObject dialogueUi;

  public Text npcName;
  public Text npcDialoguebox;
  public Text playerResponse;

  void Start()
  {
    dialogueUI.SetActive(false);
  }                                                                                                                                                                                                                                          
}
