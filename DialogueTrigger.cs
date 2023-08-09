using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    /*Este script, contiene los datos de mensajes y personajes.
    Manda mensajes al DialogueManager*/
    #region VARIABLES

    public Message [] messages;
    public Actor [] actors;
    public QuestManager questManager;

    #endregion

    public void StartDialogue()
    {
            DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
            dialogueManager.OpenDialogue(messages, actors, questManager);
    }
}

[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor 
{
    public string name;
    public Sprite sprite;
}
