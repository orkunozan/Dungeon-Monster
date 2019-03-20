using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour {

     Animator dooranim;

    void Start () {
		
	}

    private void Awake()
    {
        dooranim = GetComponent<Animator>();
    }
    
    void Update () {
		
	}
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player"){
            dooranim.SetBool("isOpen", true);
        }
        

        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
           dooranim.SetBool("isOpen", false);

        }

    }
}
