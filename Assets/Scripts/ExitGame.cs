using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // M�todo que se llamar� cuando se presione el bot�n para salir
    public void ExitGameOnClick()
    {
        // Si est�s en el editor, esto no funcionar�, pero en un build s� cerrar� la aplicaci�n
        Application.Quit();

        // Si est�s en el editor de Unity, usar esto para ver el cierre simulado
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
