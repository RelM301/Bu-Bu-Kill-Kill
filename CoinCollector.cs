using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public int coinCount = 301;
    public Text coinCounterText;
    public AudioSource getCoin;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Coin"))
        {
            coinCount++;
            coinCounterText.text = " " + coinCount.ToString();
            getCoin.PlayOneShot(getCoin.clip);
            Destroy(other.gameObject);
        }
    }
}
