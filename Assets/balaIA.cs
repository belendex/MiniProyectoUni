using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 10f;
    public float da�o = 10f;
    

    void Start()
    {
      
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) // Si usas 2D
    {
        Debug.Log("Colisi�n con: " + other.gameObject.name); // Para ver qu� colisiona

        if (other.CompareTag("Player")) // Aseg�rate de que el Player tiene el tag "Player"
        {
            life player = other.GetComponent<life>(); // Busca el script correcto
            if (player != null)
            {
                Debug.Log("Da�o aplicado: " + da�o);
                player.Takedamage(da�o); // Aplica da�o
            }
            Destroy(gameObject); // Destruye la bala tras impactar
        }
    }
}

