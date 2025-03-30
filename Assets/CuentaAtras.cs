using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{
    public float tiempo;
    public TextMeshProUGUI txt;
    bool end;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (end==true) 
        {
            return;
        }
        if (tiempo<=0)

        {
            FindObjectOfType<life>().Takedamage(1000);
            end = true;
        }
        tiempo -= Time.deltaTime;
        tiempo=Mathf.Max(0, tiempo);
        int minutos = Mathf.FloorToInt(tiempo/60);
        int segundos = Mathf.FloorToInt(tiempo % 60);


        txt.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
