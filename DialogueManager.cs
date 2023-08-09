using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region VARIABLES

    public Image actorImage;
    public Text messageText;
    public RectTransform backgroundBox;
    public static bool isActive = false;

    Message [] currentMessages;
    Actor [] currentActors;

    int activeMessage = 0;
    private QuestManager questManager;

    #endregion

    #region MANEJO DEL DIÁLOGO

    /*Inicia la conversación con los mensajes establecidos desde el inspector.
    QuestManager rastrea el proceso de la misión por medio del diálogo*/
    public void OpenDialogue(Message[] messages, Actor[] actors, QuestManager questManager)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        this.questManager = questManager;

        Debug.Log("Comienza conversación mensajes cargados: " + messages.Length);
        DisplayMessage();

        //Animación de la caja de diálogo.
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorImage.sprite = actorToDisplay.sprite;

        //Efecto del alpha del texto.
        AnimateTextColor();
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Termina la conversación");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;

            //Verifica el status de la quest con base al diálogo.
            if (questManager != null && questManager.CanCompleteQuest())
            {
                questManager.CompleteCurrentQuest();
            }
        }
    }

    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, .5f);
    }

    #endregion

    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    //Actualizar el mensaje con el "tap" del mouse(dedo).
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive == true)
        {
            NextMessage();
        }
    }

    #region DIÁLOGO RANDOM DE LOS NPCs

    //Inicia diálogo con los NPCs
    public void OpenRandomDialogue(string[] messages, Actor[] actors)
    {
        currentMessages = new Message[messages.Length];
        for (int i = 0; i < messages.Length; i++)
        {
            currentMessages[i] = new Message
            {
                actorId = Random.Range(0, actors.Length),
                message = messages[i]
            };
        }

        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Comienza conversación mensajes aleatorios cargados: " + messages.Length);
        DisplayMessage();

        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    #endregion
}
