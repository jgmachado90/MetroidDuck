using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Image dialogueImage;
    public Image nameImage;

    private Queue<string> sentences;
    public static DialogueManager instance;

    public DialogueTrigger currentDialogueTrigger;

    private void Start()
    {
        instance = this;
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, DialogueTrigger current)
    {
        currentDialogueTrigger = current;

        dialogueImage.gameObject.SetActive(true);
        nameImage.gameObject.SetActive(true);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

    }

    public void EndDialogue()
    {
        currentDialogueTrigger.dialoging = false;
        dialogueImage.gameObject.SetActive(false);
        nameImage.gameObject.SetActive(false);
    }
}
