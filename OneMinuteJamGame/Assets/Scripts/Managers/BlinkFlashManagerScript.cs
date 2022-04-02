using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkFlashManagerScript : MonoBehaviour
{
    //Blink/flash white on player damaged

    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] Material blinkMaterial, defaultMaterial;
    [SerializeField] float blinkTime;

    private void Awake()
    {
        //Subscribes blink to damage delegate
        healthManagerScript.OnDamaged += CallBlinkWhite;
    }

    private void OnDestroy()
    {
        healthManagerScript.OnDamaged -= CallBlinkWhite;
    }

    void CallBlinkWhite()
    {
        StartCoroutine("BlinkWhite");
    }

    IEnumerator BlinkWhite()
    {
        playerSprite.material = blinkMaterial;
        yield return new WaitForSecondsRealtime(blinkTime);
        playerSprite.material = defaultMaterial;
    }
}
