using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 20f;          // Velocidad de la bala
    public float tiempoVida = 5f;          // Tiempo de vida de la bala antes de ser destruida
    public float retrasoActivacion = 0.5f; // Tiempo de espera antes de que la bala comience a moverse
    public float da�o = 10f;               // Cantidad de da�o que la bala inflige
    public string tagIgnorar = "Player";   // Tag que la bala no debe da�ar (configurable desde el Inspector)

    private Rigidbody rb;
    private bool activada = false;
    private float tiempoDeActivacion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tiempoDeActivacion = Time.time + retrasoActivacion;
        rb.velocity = Vector3.zero; // Inicialmente la velocidad es cero
    }

    void Update()
    {
        // Activar la bala despu�s del retraso de activaci�n
        if (!activada && Time.time >= tiempoDeActivacion)
        {
            activada = true;
            rb.velocity = transform.forward * velocidad;
        }

        // Destruye la bala despu�s de un tiempo si no ha colisionado
        Destroy(gameObject, tiempoVida);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto tiene el tag que debe ignorar la bala
        if (collision.gameObject.CompareTag(tagIgnorar))
        {
            Destroy(gameObject); // Destruye la bala, pero no aplica da�o
            return; // Sale de la funci�n sin hacer nada m�s
        }

        // Verifica si el objeto con el que colisionamos tiene el componente de salud
        Salud saludEnemigo = collision.gameObject.GetComponent<Salud>();
        if (saludEnemigo != null)
        {
            // Aplica da�o al enemigo
            saludEnemigo.RecibirDa�o(da�o);
        }

        // Destruye la bala al colisionar con cualquier objeto
        Destroy(gameObject);
    }
}