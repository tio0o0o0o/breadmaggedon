using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CoinPicker : MonoBehaviour
{
    public static event Action OnCollect = delegate { };

    public int Coin = 0;
    public TextMeshProUGUI textcoins;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.tag == "Coin")
        {
            //Adds coins and destroys coin

            //Calls the OnCollect event which calls the SpawnCoin function in the coin spawner
            OnCollect?.Invoke();
            Coin++;
            textcoins.text = Coin.ToString();
            Destroy(other.gameObject); 
        }
    }

    private void OnDestroy()
    {
        //Saves coin to PlayerPref
        savePrefs();
    }

    void savePrefs()
    {
        if (Coin > PlayerPrefs.GetInt("Highscore"))
        {
            //Set the PlayerPref of 'Coins' with the number of coins Collected
            PlayerPrefs.SetInt("Highscore", Coin);
            PlayerPrefs.Save();
        }

    }
}
//Tutorials on PlayerPrefs: https://youtu.be/pZ3laVZQr4Y ; https://youtu.be/CWN_HQeCLWk 
