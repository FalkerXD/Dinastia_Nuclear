using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelTransition levelTransition; // Referencia al script LevelTransition
    private bool levelCompleted = false;    // Controla si el nivel ha sido completado

    void Start()
    {
        // Asegurarse de que el LevelTransition est� referenciado
        if (levelTransition == null)
        {
            Debug.LogError("No se ha asignado el LevelTransition en el GameManager");
        }
    }

    void Update()
    {
        // Ejemplo: Cambiar de nivel al pulsar la tecla 'N' o cuando el nivel se completa
        if (Input.GetKeyDown(KeyCode.N) || levelCompleted)
        {
            TransitionToNextLevel();
        }
    }

    // Funci�n para iniciar la transici�n al siguiente nivel
    public void TransitionToNextLevel()
    {
        if (levelTransition != null)
        {
            levelTransition.LoadNextLevel();
        }
    }

    // Llama a esta funci�n desde otro script o evento cuando el jugador complete el nivel
    public void CompleteLevel()
    {
        levelCompleted = true; // Marca el nivel como completado
    }
}
