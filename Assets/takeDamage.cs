using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class takeDamage : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        life vidaPersonaje = other.GetComponent<life>();
        if (vidaPersonaje != null)
        {
            vidaPersonaje.Takedamage(damage);
           
           
        }
    }
}

