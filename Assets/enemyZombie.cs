using UnityEngine;

public class enemyZombie : MonoBehaviour
{
    public string tagJugador = "Player";
    public string tagObstaculo = "Obstacle"; // Tag del obstáculo
    public float distanciaMinima = 5f;
    public float velocidadMovimiento = 3f;
    public float minY = 0f; // Límite mínimo en el eje Y
    public float maxY = 10f; // Límite máximo en el eje Y
    public int life;
    public GameObject particles;
    public GameObject OjosNormal;
    public GameObject OjosEnfado;
    private Transform jugador;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag(tagJugador).transform;
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia < distanciaMinima)
        {   
            OjosNormal.SetActive(false);
            OjosEnfado.SetActive(true);
            Vector3 direccion = (jugador.position - transform.position).normalized;
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
            float anguloActual = transform.eulerAngles.y;

            transform.rotation = Quaternion.RotateTowards(transform.rotation,rotacionObjetivo, 300 * Time.deltaTime);

            // Raycast para detectar obstáculos
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direccion, out hit, distanciaMinima))
            {
                // Verifica si el objeto detectado tiene la etiqueta de obstáculo
                if (hit.collider.CompareTag(tagObstaculo))
                {
                    // Detiene el movimiento si se detecta un obstáculo
                    return;
                }
            }

            // Restringe el movimiento vertical
            float newY = Mathf.Clamp(transform.position.y, minY, maxY);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // Mover el enemigo hacia el jugador
            transform.Translate(direccion * velocidadMovimiento * Time.deltaTime);
        }
        else
        {
            OjosNormal.SetActive(true);
            OjosEnfado.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            print("bala");
            int dmg = other.gameObject.GetComponent<BulletScript>().damage;
            life = life - dmg;
            
            if (life < 0)
            {  print("entré a trigger");
                Instantiate(particles, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaMinima);
    }
}

