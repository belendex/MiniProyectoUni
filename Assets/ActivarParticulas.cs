using Cinemachine;
using System.Collections;
using UnityEngine;

public class ActivarParticulas : MonoBehaviour
{
    // Referencia al sistema de partículas
    public GameObject sistemaParticulasPropio;
    public GameObject sistemaParticulas2;
    public GameObject sistemaParticulas3;
    public GameObject sistemaParticulas4;
    public GameObject sistemaParticulas5;
    public CinemachineVirtualCamera virtualCameraPlayer;
    public CinemachineVirtualCamera virtualCameraCinematic;
    public scr droneScript;
    public VidaDrone vidaDrone;
    public bool finish;
    public Camera torretcam;
    public void Update()
    {

        if (sistemaParticulas2.activeSelf && sistemaParticulas3.activeSelf && sistemaParticulas4.activeSelf && sistemaParticulas5.activeSelf && sistemaParticulasPropio.activeSelf && vidaDrone.vida<=0)
        {
            if (finish==false)
            {
                finish = true;
                StartCoroutine(FallDroneAnim());
            }
            virtualCameraPlayer.enabled = false;
            virtualCameraCinematic.enabled = true;
            torretcam.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entró en el trigger tiene la etiqueta "bullet"
        if (other.CompareTag("Bullet")||other.CompareTag("TorretBullet"))
        {
            // Activar el sistema de partículas si está desactivado
            if (!sistemaParticulasPropio.activeSelf)
            {
                sistemaParticulasPropio.SetActive(true);
                
               
            }
        }
    }

    IEnumerator FallDroneAnim()
    {
        yield return new WaitForSeconds(1.2f);
        droneScript.FallDrone();
    }
}
