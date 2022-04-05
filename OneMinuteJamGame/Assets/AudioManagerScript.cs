using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip explotion, coin;

    public void PlayExplotion()
    {
        source.PlayOneShot(explotion);
    }

    public void PlayCoin()
    {
        source.PlayOneShot(coin);
    }

    private void Awake()
    {
        ExplosiveMine.OnExplode += PlayExplotion;
        CoinPicker.OnCollect += PlayCoin;
    }

    private void OnDestroy()
    {
        ExplosiveMine.OnExplode -= PlayExplotion;
        CoinPicker.OnCollect -= PlayCoin;
    }
}
