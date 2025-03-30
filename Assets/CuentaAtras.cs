using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{
    public float tiempo;
    public TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.deltaTime;
        tiempo=Mathf.Max(0, tiempo);
        int minutos = Mathf.FloorToInt(tiempo/60);
        int segundos = Mathf.FloorToInt(tiempo % 60);


        txt.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
