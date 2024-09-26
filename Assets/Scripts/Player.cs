using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    // Detecta colisiones con un Collider 3D
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador ha colisionado con un objeto que tiene el tag 'Goal'
        if (other.CompareTag("Goal"))
        {
            gameManager.CompleteLevel(); // Completar el nivel
        }
    }
}
