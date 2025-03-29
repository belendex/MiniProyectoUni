using System.Collections;
using UnityEngine;

public class Torret : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo1;
    public Transform puntoDisparo2;
    public float tiempoEntreRafagas = 1.5f;
    public float tiempoEntreBalas = 0.2f;
    public int balasPorRafaga = 5;
    public GameObject objetivoDesactivador;

    public float velocidadRotacion = 30f; // Velocidad de rotación en grados por segundo
    public float anguloMaximo = 30f; // Ángulo máximo de giro desde la posición inicial

    private bool puedeDisparar = true;
    private float anguloObjetivo;
    private bool girandoDerecha = true; // Alternar dirección del giro

    void Start()
    {
        StartCoroutine(DispararRafagas());
        anguloObjetivo = transform.eulerAngles.y + anguloMaximo; // Ángulo inicial de referencia
    }

    void Update()
    {
        RotarTorreta();
    }

    IEnumerator DispararRafagas()
    {
        while (puedeDisparar)
        {
            if (objetivoDesactivador == null)
            {
                puedeDisparar = false;
                yield break;
            }

            for (int i = 0; i < balasPorRafaga; i++)
            {
                DispararBala();
                yield return new WaitForSeconds(tiempoEntreBalas);
            }

            yield return new WaitForSeconds(tiempoEntreRafagas);
        }
    }

    void DispararBala()
    {
        if (puedeDisparar)
        {
            Instantiate(balaPrefab, puntoDisparo1.position, puntoDisparo1.rotation);
            Instantiate(balaPrefab, puntoDisparo2.position, puntoDisparo2.rotation);
        }
    }

    void RotarTorreta()
    {
        // Suavizar el giro usando RotateTowards
        float anguloActual = transform.eulerAngles.y;
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            Quaternion.Euler(0, anguloObjetivo, 0),
            velocidadRotacion * Time.deltaTime
        );

        // Si alcanzó el ángulo objetivo, cambia de dirección
        if (Mathf.Abs(anguloActual - anguloObjetivo) < 0.5f)
        {
            girandoDerecha = !girandoDerecha;
            if (girandoDerecha == true)
            {
                anguloObjetivo = transform.eulerAngles.y + anguloMaximo;
            }
            else
            {
                anguloObjetivo = transform.eulerAngles.y - anguloMaximo;
            }

            anguloObjetivo = girandoDerecha
                ? transform.eulerAngles.y + anguloMaximo
                : transform.eulerAngles.y - anguloMaximo;
        }
    }
}
