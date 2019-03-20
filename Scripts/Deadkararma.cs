using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadkararma : MonoBehaviour
{


    public static int counterLoop = 0;
    Animator deadanim;
    HealthBar healthcontrolk;
    void Awake()
    {

        healthcontrolk = GameObject.Find("Player").GetComponent<HealthBar>();
        deadanim = GetComponent<Animator>();
    }

    void Update()
    {

        if (healthcontrolk.health <= 0 )
        {
            Debug.Log("counter miktarı :" + counterLoop);
            
            deadanim.SetBool("isDeadkararma", true);

            var dead = GameObject.Find("Player").GetComponent<audioScript>();
            if (counterLoop == 0)
            {

            dead.deadCheck = true;
                counterLoop++;
            }
            else
            {
                dead.deadCheck = false;
            }
            


        }
        else
        {
            deadanim.SetBool("isDeadkararma", false);
            counterLoop = 0;

        }



        if (HealthBar.isHit)
        {
            deadanim.SetBool("isHit", true);

        }
        else if (HealthBar.isHit == false)
        {
            deadanim.SetBool("isHit", false);
        }



    }
}
