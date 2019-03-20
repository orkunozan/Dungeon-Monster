using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            var healthdamage = GameObject.Find("Player").GetComponent<HealthBar>();
            healthdamage.health -= 20;
            var hit1 = GameObject.Find("Player").GetComponent<audioScript>();
            hit1.hit1Check = true;
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

