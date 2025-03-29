using UnityEngine;

public class DestruirAlImpacto : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) // Aseg�rate de que las balas del jugador tengan esta etiqueta
        {
            Destroy(gameObject); // Destruye el objeto
        }
    }
}
