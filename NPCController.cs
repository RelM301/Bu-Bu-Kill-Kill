using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public DialogueTrigger trigger;
    public QuestManager questManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            trigger.StartDialogue();
            questManager.CompleteCurrentQuest();
        }
    }
}
