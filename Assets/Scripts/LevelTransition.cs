using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour
{
    public Animator transitionAnimator; // Animator para la animación de transición
    public float transitionTime = 1f;   // Duración de la transición (en segundos)

    // Función para cargar el siguiente nivel (puedes llamar a esta función cuando sea necesario)
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    // Función que inicia la transición y carga el nuevo nivel
    IEnumerator LoadLevel(int levelIndex)
    {
        // Reproducir la animación de transición (Fade Out)
        transitionAnimator.SetTrigger("Start");

        // Esperar el tiempo de la transición
        yield return new WaitForSeconds(transitionTime);

        // Cargar la escena siguiente
        SceneManager.LoadScene(levelIndex);
    }
}
