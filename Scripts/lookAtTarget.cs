using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtTarget : MonoBehaviour {
    public float sens=0.125f;
    public GameObject bullet;
    public Transform bulletPos;
    float spawnCheckTime=0;
    public float speed = 5000;
    GameObject bulletFire;
    Vector3 relativePosition;
    Quaternion targetRotation;

   
    
    bool rotating = false;
    float rotationTime;
   



    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {           

            relativePosition = other.transform.position - transform.position;
            targetRotation = Quaternion.LookRotation(relativePosition);
            rotationTime = Time.deltaTime*10f;
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation,rotationTime);
            

        



            spawnCheckTime += Time.deltaTime;
            if (spawnCheckTime > 1f)
            {

              
                 bulletFire= Instantiate(bullet, bulletPos.position, Quaternion.identity);
                bulletFire.GetComponent<Rigidbody>().AddForce(transform.forward * 1500);
                spawnCheckTime = 0;
            }

            Destroy(bulletFire,3);
        }

    }


    

    
}
