using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDamage : MonoBehaviour {

   



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

           var healthdamage = GameObject.Find("Player").GetComponent<HealthBar>();
            healthdamage.health -= 100;
            HealthBar.isHit = true;
            StartCoroutine(hittimer());
        }
        
    }
   



    IEnumerator hittimer()
    {
        yield return new WaitForSeconds(0.2f);
        HealthBar.isHit = false;
    }
}
