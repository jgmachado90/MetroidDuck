using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    private static Duck _instance;
    public static Duck Instance
    {
        get
        {
            return _instance;
        }
    }


    public DialogueTrigger currentDialogueEntity;



    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }


    public void Action()
    {
        if (currentDialogueEntity != null)
        {
            currentDialogueEntity.TriggerDialogue();
        }

    }


}
