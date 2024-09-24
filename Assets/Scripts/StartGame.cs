using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar escenas


public class StartGame : MonoBehaviour
{
    // Método que se llamará cuando se presione el botón
    public void StartGameOnClick()
    {
        // Asegúrate de que la escena a cargar esté en la lista de escenas del build
        SceneManager.LoadScene("NivelTutorial"); // Reemplaza "NombreDeLaEscena" con el nombre de la escena que quieras cargar
    }
}
