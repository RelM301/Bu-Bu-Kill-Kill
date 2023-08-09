using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNPC : MonoBehaviour
{
    /*Código general para los NPCs que se complementa 
    con el código RandomDialogue.*/
    public RandomDialogue randomDialogue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            randomDialogue.StartRandomDialogue();
        }
    }
}
