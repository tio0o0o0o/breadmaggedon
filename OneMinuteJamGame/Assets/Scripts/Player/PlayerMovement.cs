using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed, rotationSpeed;

    private Vector2 moveDirection;

    //Returns a Vector2 of horizontal and vertical input
    void GetMoveDirection()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector2(horizontalInput, verticalInput);
        moveDirection.Normalize(); 
    }

    void Move()
    {
        GetMoveDirection();
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    void Rotate()
    {
        if (moveDirection != Vector2.zero)
        {
            Quaternion rotateTo = Quaternion.LookRotation(Vector3.forward, moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTo, rotationSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        switch (GameStateManagerScript.gameState)
        {
            case GameStateManagerScript.gameStatesEnum.Gameplay:
                Move();
                Rotate();
                break;

            case GameStateManagerScript.gameStatesEnum.Gameover:
                break;

            default:
                break;
        }
    }
}



