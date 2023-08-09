using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    #region VARIABLES

    public Text questText;
    public Image npcSprite;
    public GameObject appleCollectorObject;
    public GameObject appleCounterObject;
    public Sprite newSprite;

    private AppleCollector appleCollector;
    private Text appleCounterText;

    #endregion

    //Referencia al scrip "AppleCollector".
    private void Start()
    {
        appleCollector = appleCollectorObject.GetComponent<AppleCollector>();
        appleCounterText = appleCounterObject.GetComponent<Text>();
    }
    
    //Activa el texto y cambia su contenido.
    public void StartQuest()
    {
        questText.gameObject.SetActive(true);
        questText.text = "Habla con Uribo el jabalí";
    }

    //Actualiza la quest actual y modifica su texto.
    public void CompleteCurrentQuest()
    {
        questText.text = "Busca 7 manzanas";
        npcSprite.sprite = newSprite;

        appleCollectorObject.SetActive(true);
        appleCounterObject.SetActive(true);
    }
    
    public bool CanCompleteQuest()
    {
        {
            return false;
        }
    }
}
