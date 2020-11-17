using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool dialoging = false;
    public bool ended = false;

    public void TriggerDialogue()
    {
        if (!dialoging)
        {
            DialogueManager.Instance.StartDialogue(dialogue, this);
            dialoging = true;
        }
        else
        {
            DialogueManager.Instance.DisplayNextSentence();
        }
    }

    
}
 