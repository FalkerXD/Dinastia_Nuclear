using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar escenas


public class StartGame : MonoBehaviour
{
    // M�todo que se llamar� cuando se presione el bot�n
    public void StartGameOnClick()
    {
        // Aseg�rate de que la escena a cargar est� en la lista de escenas del build
        SceneManager.LoadScene("NivelTutorial"); // Reemplaza "NombreDeLaEscena" con el nombre de la escena que quieras cargar
    }
}
