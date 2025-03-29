using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 10f;
    public float daño = 10f;
    

    void Start()
    {
      
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) // Si usas 2D
    {
        Debug.Log("Colisión con: " + other.gameObject.name); // Para ver qué colisiona

        if (other.CompareTag("Player")) // Asegúrate de que el Player tiene el tag "Player"
        {
            life player = other.GetComponent<life>(); // Busca el script correcto
            if (player != null)
            {
                Debug.Log("Daño aplicado: " + daño);
                player.Takedamage(daño); // Aplica daño
            }
            Destroy(gameObject); // Destruye la bala tras impactar
        }
    }
}

