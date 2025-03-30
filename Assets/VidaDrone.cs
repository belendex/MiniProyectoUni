using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaDrone : MonoBehaviour
{
    public int vida;
    public GameObject feedbackhit;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TorretBullet")
        {
            vida -= 50;
            Instantiate(feedbackhit,other.transform.position, Quaternion.identity);
            if (vida <= 0)
            {


            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
