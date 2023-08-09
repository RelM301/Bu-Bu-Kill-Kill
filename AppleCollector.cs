using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleCollector : MonoBehaviour
{
    #region VARIABLES

    public int appleCount = 0;
    public Text appleCounterText;
    public AudioSource getApple;
    public GameObject endPanel;

    #endregion
    
    /*Cuando el player toca el collider con el tag "Apple", aumenta el contador
    de manzanas, activa un sonido, destruye el objeto y, actualiza un panel cuando
    la cuenta de manzanas llega a 7*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Apple"))
        {
            appleCount++;
            appleCounterText.text = " " + appleCount.ToString();
            getApple.PlayOneShot(getApple.clip);
            Destroy(other.gameObject);

            if (appleCount == 7)
            {
                endPanel.SetActive(true);
            }
        }
    }

    //Propiedad que permite a otras classes acceder al valor de la variable del contador.
    public int AppleCount
    {
        get { return appleCount; }
    }
}
