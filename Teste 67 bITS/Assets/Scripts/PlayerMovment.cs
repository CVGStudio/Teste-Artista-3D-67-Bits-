using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Obtém as entradas do teclado
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.W))
            verticalInput = 1f;
        if (Input.GetKey(KeyCode.S))
            verticalInput = -1f;
        if (Input.GetKey(KeyCode.A))
            horizontalInput = -1f;
        if (Input.GetKey(KeyCode.D))
            horizontalInput = 1f;

        // Calcula a direção de movimento
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move o personagem
        MoveCharacter(moveDirection);
    }

    void MoveCharacter(Vector3 direction)
    {
        // Calcula o deslocamento baseado na direção e velocidade
        Vector3 moveAmount = direction * moveSpeed * Time.deltaTime;

        // Move o objeto na cena
        transform.Translate(moveAmount);
    }
}