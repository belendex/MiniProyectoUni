using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public CameraTurret cameraTorret;
    public GameObject bullet;
    void Start()
    {



    }
    void Update()
    {
        if (cameraTorret.cameraTorreta.gameObject.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, transform.position, transform.rotation);
            }
        }
    }
}





