using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    private void Start()
    {
        text.text = "Score: " + CoinPicker.Coin.ToString();
    }
}
