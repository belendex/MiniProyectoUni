using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform laserOrigin; // Origen del l�ser (el objeto que mueve la luz)
    public float laserLength = 100f; // Longitud del l�ser
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // Aseguramos que haya dos puntos
    }

    void Update()
    {
        // Establecer la posici�n inicial del l�ser (el origen)
        lineRenderer.SetPosition(0, laserOrigin.position);

        // Direcci�n del l�ser (hacia donde apunta el objeto)
        Vector3 laserDirection = laserOrigin.forward;

        // Establecer la posici�n final del l�ser
        lineRenderer.SetPosition(1, laserOrigin.position + laserDirection * laserLength);
    }
}
