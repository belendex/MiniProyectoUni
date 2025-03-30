using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurret : MonoBehaviour
{
    public Transform parentCube; // El cubo padre
    public Transform cameraTransform; // La c�mara (hijo del padre)

    public float sensitivityX = 100f;
    public float sensitivityY = 100f;

    private float rotationX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        // Rotar el cubo padre en el eje Y (horizontal)
        parentCube.Rotate(Vector3.up * mouseX);

        // Rotar la c�mara en el eje X (vertical), limitando el �ngulo de visi�n
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -45f, 15f); // L�mite de 15� hacia abajo y -45� hacia arriba

        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
