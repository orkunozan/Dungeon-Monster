using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHealth : MonoBehaviour
{

    
    void Update()
    {
        transform.Rotate(0, 0, 0.4f);
    }

    private void OnTriggerEnter(Collider other)
    {



        {
            if (other.tag == "Player")
            {
                var gethealth = GameObject.Find("Player").GetComponent<HealthBar>();
                gethealth.health += 20;
                Destroy(gameObject);
            }

        }


    }
}
