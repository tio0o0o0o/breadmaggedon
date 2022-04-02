using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPicker : MonoBehaviour
{
    //private float Coin = 0;
    public int Coin = 0;

    public TextMeshProUGUI textcoins;

    private void OnTriggerEnter2D(Collider2D other)
    {
       //Debug.Log ("entered collider");
        if (other.transform.tag == "Coin")
        {
            Coin ++;
            textcoins.text = Coin.ToString();
            //Debug.Log("Destroy triggered");
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("Highscore", Coin);
        }    
    }
}