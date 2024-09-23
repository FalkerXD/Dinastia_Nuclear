using UnityEngine;
using UnityEngine.UI;  // Necesario para trabajar con elementos de UI

public class Salud : MonoBehaviour
{
    public float saludMaxima = 100f;  // Salud máxima del personaje
    public float saludActual;         // Salud actual del personaje
    public Image barraDeSalud;        // Referencia a la imagen de la barra de salud en la UI (o Slider)

    public GameObject efectoMuerte;   // Efecto visual o de partículas para la muerte
    public bool desactivarPersonaje = true;  // Opción para desactivar el GameObject en lugar de destruirlo

    void Start()
    {
        // Inicializa la salud actual con la salud máxima
        saludActual = saludMaxima;

        // Actualizar la barra de salud al inicio
        ActualizarBarraDeSalud();
    }

    // Método para aplicar daño al personaje
    public void RecibirDaño(float cantidad)
    {
        saludActual -= cantidad;  // Reducir la salud actual por la cantidad de daño recibido
        saludActual = Mathf.Clamp(saludActual, 0f, saludMaxima);  // Asegurarse de que la salud no sea menor que 0

        // Actualizar la barra de salud
        ActualizarBarraDeSalud();

        // Verificar si la salud ha llegado a 0 o menos
        if (saludActual <= 0f)
        {
            Morir();  // Llamar al método Morir cuando la salud llegue a 0
        }

        // Opcional: Mostrar la salud actual en la consola, útil para depuración
        Debug.Log($"Salud actual: {saludActual}");
    }

    // Método para actualizar la barra de salud en la UI
    void ActualizarBarraDeSalud()
    {
        if (barraDeSalud != null)
        {
            // Supone que el `Image` está configurado para mostrar la cantidad de salud mediante su fillAmount (si es un Slider cambia esto).
            barraDeSalud.fillAmount = saludActual / saludMaxima;
        }
    }

    // Método para manejar la muerte del personaje
    void Morir()
    {
        // Reproducir efecto de muerte si se ha asignado uno
        if (efectoMuerte != null)
        {
            Instantiate(efectoMuerte, transform.position, transform.rotation);
        }

        // Desactivar el GameObject si la opción está habilitada
        if (desactivarPersonaje)
        {
            gameObject.SetActive(false);
        }
        else
        {
            // Alternativamente, destruir el GameObject
            Destroy(gameObject);
        }
    }
}
