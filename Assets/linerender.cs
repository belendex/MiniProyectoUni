using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform laserOrigin; // Origen del láser (el objeto que mueve la luz)
    public float laserLength = 100f; // Longitud del láser
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // Aseguramos que haya dos puntos
    }

    void Update()
    {
        // Establecer la posición inicial del láser (el origen)
        lineRenderer.SetPosition(0, laserOrigin.position);

        // Dirección del láser (hacia donde apunta el objeto)
        Vector3 laserDirection = laserOrigin.forward;

        // Establecer la posición final del láser
        lineRenderer.SetPosition(1, laserOrigin.position + laserDirection * laserLength);
    }
}
