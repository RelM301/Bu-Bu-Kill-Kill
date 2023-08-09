using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private Image progressBar;
    [SerializeField] private Text progressText;
    [SerializeField] private RectTransform playerTransform;

    private float fillSpeed = 0.2f;
    private float targetFillAmount = 1f;

    public static int nextScene = 1;

    #endregion

    void Start()
    {
        StartCoroutine("FillProgressBar");
    }

    //Proceso de carga.
    private IEnumerator FillProgressBar()
    {
        float currentFillAmount = 0f;
        while(currentFillAmount < targetFillAmount)
        {
            //Actualiza relleno de la imagen.
            currentFillAmount += fillSpeed * Time.deltaTime;
            progressBar.fillAmount = currentFillAmount;

            //Actualiza porcentaje.
            int progressPercentage = Mathf.RoundToInt(currentFillAmount * 100);
            progressText.text = progressPercentage.ToString() + "%";

            //Mueve cerdito animado.
            float targetPosition = progressBar.rectTransform.rect.width * currentFillAmount;
            playerTransform.anchoredPosition = new Vector2(targetPosition, playerTransform.anchoredPosition.y);

            yield return null;
        }
        
        SceneManager.LoadSceneAsync(nextScene);

    }
}
