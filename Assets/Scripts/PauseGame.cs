using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;
    private string pauseMenuSceneName = "PauseMenu"; // Nombre de la escena del menú de pausa
    private string gameSceneName; // Nombre de la escena del juego

    void Start()
    {
        // Guardar el nombre de la escena actual del juego
        gameSceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        // Si el jugador presiona la tecla "P", el juego se pausará o reanudará
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        isPaused = true;
        // Guardar el estado del tiempo del juego
        Time.timeScale = 0f;
        // Cargar la escena del menú de pausa
        SceneManager.LoadScene(pauseMenuSceneName, LoadSceneMode.Additive);
    }

    public void ResumeGame()
    {
        isPaused = false;
        // Reanudar el tiempo del juego
        Time.timeScale = 1f;
        // Unload the pause menu scene
        SceneManager.UnloadSceneAsync(pauseMenuSceneName);
    }

}
