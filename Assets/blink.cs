using System.Collections;
using UnityEngine;

public class LaserAndSpotlightBlink : MonoBehaviour
{
    public Light spotlight; // El Spotlight que se va a encender y apagar
    public LineRenderer lineRenderer; // La línea del láser
    public float onDuration = 3f; // Duración encendido
    public float offDuration = 8f; // Duración apagado
    public AudioClip warningSound; // Sonido de aviso
    private AudioSource audioSource; // Fuente de audio
    public Collider lasercollider; 
    private bool isOn = true;

    private void Start()
    {
        if (spotlight == null)
            spotlight = GetComponent<Light>();

        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        // Agregar o buscar el componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        StartCoroutine(BlinkingEffect());
    }

    private IEnumerator BlinkingEffect()
    {
        while (true)
        {
            if (!isOn) // Si está apagado, iniciar la secuencia de encendido
            {
                // Reproducir el sonido de aviso
                if (warningSound != null)
                {
                    audioSource.PlayOneShot(warningSound);
                }

                // Esperar 2 segundos antes de encender la luz
                yield return new WaitForSeconds(2f);

                // Encender el Spotlight y el LineRenderer
                spotlight.enabled = true;
                lineRenderer.enabled = true;
                lasercollider.enabled = true;
                yield return new WaitForSeconds(onDuration);
            }
            else
            {
                // Apagar el Spotlight y el LineRenderer
                spotlight.enabled = false;
                lineRenderer.enabled = false;
                lasercollider.enabled = false;
                yield return new WaitForSeconds(offDuration);
            }

            isOn = !isOn; // Cambiar estado
        }
    }
}
