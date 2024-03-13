using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionController : MonoBehaviour
{
    private int targetsHit = 0;
    public string nextSceneName; // Nombre de la siguiente escena despu�s de completar la misi�n
    public Camera mainCamera; // Referencia a la c�mara principal
    public Camera missionEndCamera; // Referencia a la c�mara para el final de la misi�n

    public void RegisterTargetHit()
    {
        targetsHit++;

        if (targetsHit >= 3)
        {
            // Cambiar a la c�mara de fin de misi�n
            mainCamera.gameObject.SetActive(false);
            missionEndCamera.gameObject.SetActive(true);

            // Esperar un breve tiempo antes de cambiar de escena
            Invoke("ChangeScene", 60f);
        }
    }

    private void ChangeScene()
    {
        // Cambiar a la siguiente escena cuando se han impactado los tres objetivos
        SceneManager.LoadScene(nextSceneName);
    }
}
