using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour {

    Animator deadanimperson;
    
    
    HealthBar healthcontrol;
    
    void Awake () {
        healthcontrol = GetComponent<HealthBar>();
        deadanimperson = GetComponent<Animator>();
	}
	
	void Update ()
    {
        if (HealthBar.isHit)
        {
            

            deadanimperson.SetBool("isHitbool", true);

        }
        else if (HealthBar.isHit == false)
        {

           
            deadanimperson.SetBool("isHitbool", false);
            

        }


        if (healthcontrol.health <= 0 )
        {
            deadanimperson.enabled = true;

            deadanimperson.SetBool("isDead", true);
            
        }
        else if (healthcontrol.health<=100 && healthcontrol.health>0)
        {
            deadanimperson.enabled = false;
            deadanimperson.SetBool("isDead", false);
            






        }




    }

}
