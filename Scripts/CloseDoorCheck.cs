using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorCheck : MonoBehaviour
{
    GameObject doorBlade;
    GameObject topBorder;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    bool isPlayerIN;

    void Awake()
    {
        doorBlade = GameObject.Find("doorBlade");
        topBorder = GameObject.Find("topBorder");

        isPlayerIN = false;


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            isPlayerIN = true;

            var noEscapeCheck = GameObject.Find("Player").GetComponent<audioScript>();
            noEscapeCheck.escapeCheck = true;

        }
    }
    private void Update()
    {
        //https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html
        float dist = Vector3.Distance(topBorder.transform.position, doorBlade.transform.position);
        if (isPlayerIN)
        {

            if (dist >= 5) // target position - top border
            {
                Vector3 targetPosition = doorBlade.transform.TransformPoint(new Vector3(0, 2, 0)); // her seferinde kaç vectorlük hareket edecek onun hesabı.
                doorBlade.transform.position = Vector3.SmoothDamp(doorBlade.transform.position, targetPosition, ref velocity, smoothTime); // doorBlade.transform.position is start position.
            }                                                                                                   // V0 - başlangıç hızı
                                                                                                                // targetPosition'ın ne kadar sürede tamamlanacağı.
            else
            {
                Vector3 targetPosition = doorBlade.transform.TransformPoint(new Vector3(0, 0, 0));
                doorBlade.transform.position = Vector3.SmoothDamp(doorBlade.transform.position, targetPosition, ref velocity, smoothTime);
            }

        }





    }



}
