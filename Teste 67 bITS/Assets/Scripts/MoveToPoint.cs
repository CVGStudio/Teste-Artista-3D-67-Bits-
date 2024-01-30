using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    public Transform[] targetPoints; // Lista de pontos para onde o objeto deve se mover
    public float speed = 5f; // Velocidade de movimento
    public float rotationSpeed = 180f; // Velocidade de rotação

    private int currentTargetIndex = 0; // Índice do ponto de destino atual

    void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        // Verifica se há pelo menos um ponto de destino
        if (targetPoints != null && targetPoints.Length > 0)
        {
            // Obtém o ponto de destino atual
            Transform currentTarget = targetPoints[currentTargetIndex];

            // Calcula a direção para o ponto de destino
            Vector3 direction = currentTarget.position - transform.position;

            // Normaliza a direção para manter uma velocidade constante
            Vector3 normalizedDirection = direction.normalized;

            // Calcula a distância entre o objeto e o ponto de destino
            float distance = Vector3.Distance(transform.position, currentTarget.position);

            // Move o objeto na direção do ponto de destino com uma velocidade suavizada
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

            // Se o objeto chegou ao ponto de destino
            if (distance < 0.1f)
            {
                // Calcula a rotação necessária para virar 180 graus
                Quaternion targetRotation = Quaternion.LookRotation(-transform.forward, transform.up);

                // Rotaciona suavemente o objeto
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                // Move para o próximo ponto de destino
                currentTargetIndex = (currentTargetIndex + 1) % targetPoints.Length;
            }
        }
    }
}
