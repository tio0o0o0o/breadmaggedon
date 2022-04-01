using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed;

    //Returns a Vector2 of horizontal and vertical input
    Vector2 GetMovementInputs()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        return moveDirection;
    }

    void Move()
    {
        rb.velocity = GetMovementInputs() * Time.deltaTime * moveSpeed;
    }

    private void Update()
    {
        switch (GameStateManagerScript.gameState)
        {
            case GameStateManagerScript.gameStatesEnum.Gameplay:
                Move();
                break;

            case GameStateManagerScript.gameStatesEnum.Gameover:
                break;

            default:
                break;
        }
    }
}
