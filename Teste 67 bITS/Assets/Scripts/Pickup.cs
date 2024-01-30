using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float rotationSpeed = 50f; // Velocidade de rota��o
    public float movementSpeed = 2f;  // Velocidade de movimento para cima e para baixo
    public float movementRange = 1f;  // Amplitude do movimento

    private float initialY; // Posi��o inicial em Y

    void Start()
    {
        initialY = transform.position.y; // Armazena a posi��o inicial em Y
    }

    void Update()
    {
        // Movimento de rota��o
        RotatePickUp();

        // Movimento para cima e para baixo
        MoveUpDown();
    }

    void RotatePickUp()
    {
        // Rotaciona o objeto em torno do eixo Z
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    void MoveUpDown()
    {
        // Calcula o deslocamento em Y usando uma fun��o seno
        float yOffset = Mathf.Sin(Time.time * movementSpeed) * movementRange;

        // Aplica o deslocamento em Y
        transform.position = new Vector3(transform.position.x, initialY + yOffset, transform.position.z);
    }
}
