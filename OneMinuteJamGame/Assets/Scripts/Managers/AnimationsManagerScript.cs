using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManagerScript : MonoBehaviour
{
    [SerializeField] Animator characterAnimator;

    private void Update()
    {
        if (PlayerMovement.moveDirection.magnitude >= 0.01f)
        {
            characterAnimator.SetBool("IsMoving", true);
        }
        else
        {
            characterAnimator.SetBool("IsMoving", false);
        }
    }
}
