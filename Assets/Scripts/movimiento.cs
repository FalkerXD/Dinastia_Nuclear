using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 5f;         // Velocidad de movimiento horizontal
    public float jumpHeight = 2f;   // Altura del salto
    public float gravity = 9.81f;    // Magnitud de la gravedad
    public float rotationSpeed = 700f; // Velocidad de rotaci�n

    private CharacterController controller;
    private Animator animator;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        // Obt�n el componente CharacterController
        controller = GetComponent<CharacterController>();
        // Obt�n el componente Animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Verifica si el jugador est� en el suelo
        isGrounded = controller.isGrounded;

        // Verifica el movimiento del jugador
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Verifica si el jugador est� movi�ndose
        bool isMoving = move != Vector3.zero;
        animator.SetBool("correr", isMoving);

        // Maneja la animaci�n de salto
        if (isGrounded)
        {
            if (velocity.y < 0)
            {
                velocity.y = -2f; // Valor peque�o para mantener el jugador en el suelo
            }

            if (Input.GetKey(KeyCode.Space))
            {
                // Aplica una velocidad vertical para el salto
                velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
                animator.SetTrigger("salto");
            }
        }
        else
        {
            // Si no est� en el suelo, se est� en el aire y la animaci�n de salto deber�a estar activa
            if (velocity.y > 0)
            {
                animator.SetTrigger("salto");
            }
        }

        // Aplica la gravedad
        velocity.y -= gravity * Time.deltaTime;

        // Calcula la rotaci�n deseada en funci�n del movimiento
        if (isMoving)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Mueve al jugador
        controller.Move(move * speed * Time.deltaTime + velocity * Time.deltaTime);
    }
}