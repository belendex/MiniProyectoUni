using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretPlayer : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);


    }


}
