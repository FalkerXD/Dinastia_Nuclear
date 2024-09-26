using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour
{
    public Animator transitionAnimator; // Animator para la animaci�n de transici�n
    public float transitionTime = 1f;   // Duraci�n de la transici�n (en segundos)

    // Funci�n para cargar el siguiente nivel (puedes llamar a esta funci�n cuando sea necesario)
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    // Funci�n que inicia la transici�n y carga el nuevo nivel
    IEnumerator LoadLevel(int levelIndex)
    {
        // Reproducir la animaci�n de transici�n (Fade Out)
        transitionAnimator.SetTrigger("Start");

        // Esperar el tiempo de la transici�n
        yield return new WaitForSeconds(transitionTime);

        // Cargar la escena siguiente
        SceneManager.LoadScene(levelIndex);
    }
}
