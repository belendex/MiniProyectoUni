using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageReal : MonoBehaviour
{
    public int damage;
    public GameObject particles;
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
            if(particles != null)
            {
                print("particulas");
                Instantiate(particles, transform.position, transform.rotation);
            }
            Destroy(gameObject,0.5f);
        }
    }
}