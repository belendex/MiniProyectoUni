using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurret : MonoBehaviour
{
    public Transform parentCube; // El cubo padre
    public Transform cameraTransform; // La cámara (hijo del padre)

    public float sensitivityX = 100f;
    public float sensitivityY = 100f;

    private float rotationX = 0f;
    public float distanciaInteractuable;
    public PlayerController playerController;
    public UIManager uimanager;
    public bool playerInside;
    public Camera cameraTorreta;
    public Camera cameraPlayer;
    public GameObject personaje;
    public ActivarParticulas drone;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        uimanager = UIManager.Instance;
    }

    void Update()

    {  
        if (drone.finish==true) {
            cameraPlayer.enabled = true;
            return;
            //return evita que se ejecute lo qu está abajo, 
        }

        if (playerInside==true)
        {

       
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        // Rotar el cubo padre en el eje Y (horizontal)
        parentCube.Rotate(Vector3.up * mouseX);

        // Rotar la cámara en el eje X (vertical), limitando el ángulo de visión
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -45f, 15f); // Límite de 15° hacia abajo y -45° hacia arriba

         cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        }

        if (Vector3.Distance(transform.position, playerController.transform.position) <= distanciaInteractuable)
        {
            uimanager.ShowTextInteractive();
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerInside = !playerInside;
                if (playerInside==true) {
                cameraPlayer.enabled = false;
                cameraTorreta.enabled = true;
                playerController.enabled = false;
                personaje.SetActive(false);
                }
                else
                {
                    cameraPlayer.enabled = true;
                    cameraTorreta.enabled = false;
                    playerController.enabled = true;
                    personaje.SetActive(true);
                }
            }
        }

        else
        {
            uimanager.HideTextInteractive();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanciaInteractuable);
    }
}
