using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Método que se llamará cuando se presione el botón para salir
    public void ExitGameOnClick()
    {
        // Si estás en el editor, esto no funcionará, pero en un build sí cerrará la aplicación
        Application.Quit();

        // Si estás en el editor de Unity, usar esto para ver el cierre simulado
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
