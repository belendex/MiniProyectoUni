using UnityEngine;

public class ActivarParticulas : MonoBehaviour
{
    // Referencia al sistema de part�culas
    public GameObject sistemaParticulas;
    
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entr� en el trigger tiene la etiqueta "bullet"
        if (other.CompareTag("bullet"))
        {
            // Activar el sistema de part�culas si est� desactivado
            if (!sistemaParticulas.activeSelf)
            {
                
                
                sistemaParticulas.SetActive(true);
            }
        }
    }
}
