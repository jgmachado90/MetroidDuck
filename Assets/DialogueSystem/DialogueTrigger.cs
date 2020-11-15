using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool dialoging = false;

    public void TriggerDialogue()
    {
        if (!dialoging)
        {
            DialogueManager.instance.StartDialogue(dialogue, this);
            dialoging = true;
        }
        else
        {
            DialogueManager.instance.DisplayNextSentence();
        }
    }


    
}
 