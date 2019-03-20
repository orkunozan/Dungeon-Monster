using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleDamage : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            var healthdamage = GameObject.Find("Player").GetComponent<HealthBar>();
            healthdamage.health -= 30;
            var hit2 = GameObject.Find("Player").GetComponent<audioScript>();
            hit2.hit2Check = true;
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
