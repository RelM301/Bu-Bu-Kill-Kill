using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class FoodCollector : MonoBehaviour
{
    #region VARIABLES

    public float maxEnergy = 100f;
    public Image energyBar;
    public AudioSource eatSound, damageSound;
    public PostProcessVolume postProcessingVolume;

    private float energyIncreaseAmount = 10f;
    private Vignette vignette;
    private float currentEnergy;

    #endregion

    private void Start()
    {
        currentEnergy = 25f;
        UpdateEnergyBar();
        
        //Toma los ajustes de viñeta.
        postProcessingVolume.profile.TryGetSettings(out vignette);
        vignette.active = false;
    }

    /*Función que compara el collider con el Tag "Food" y el tag "Makibishi"  
    ambos actualizan la energía, de manera positiva (if) y negativa (if else)
    destruye los objetos colisionados, activa sonido y efecto de viñeta mediante una corrutina.*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            currentEnergy += energyIncreaseAmount;
            if (currentEnergy > maxEnergy)
            {
                currentEnergy = maxEnergy;
            }
            eatSound.PlayOneShot(eatSound.clip);
            Destroy(other.gameObject);
            UpdateEnergyBar();

            vignette.color.value = Color.green;
            StartCoroutine(ActivateVignetteEffect());
        }
        else if (other.CompareTag("Makibishi"))
        {
            currentEnergy -= maxEnergy * 0.05f;
            if (currentEnergy < 0f)
            {
                currentEnergy = 0f;
            }
            damageSound.PlayOneShot(damageSound.clip);
            UpdateEnergyBar();

            vignette.color.value = Color.red;
            StartCoroutine(ActivateVignetteEffect());

        }
    }

    //Función para aumentar la barra de energía.
    private void UpdateEnergyBar()
    {
        float fillAmount = currentEnergy / maxEnergy;
        energyBar.fillAmount = fillAmount;
    }

    private IEnumerator ActivateVignetteEffect()
    {
        vignette.active = true;

        yield return new WaitForSeconds(0.3f);

        vignette.active = false;
    }

}
