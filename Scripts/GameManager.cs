using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    #region Values
    GameObject[] trickyCubes;
    GameObject doorBlade1;
    GameObject bottonBorder1;
    GameObject doorBlade2;
    GameObject bottonBorder2;
    GameObject doorBlade3;
    GameObject bottonBorder3;
    GameObject topBorder3;
    GameObject doorBlade4;
    GameObject bottonBorder4;
    GameObject topBorder4;
    GameObject doorBlade5;
    GameObject bottonBorder5;

    public int Coin;
 
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    #endregion
    #region Booleans
    public static bool istrickyCubeclose;
    public static bool isQuestiontrue;
    public static bool isIdkQuestionTrue;
    public static bool isRespawnRoom;
    #endregion

    private void Awake()
    {
        trickyCubes = GameObject.FindGameObjectsWithTag("trickyCubes");


        doorBlade1 = GameObject.Find("doorBlade1");
        bottonBorder1 = GameObject.Find("bottonBorder1");
        doorBlade2 = GameObject.Find("doorBlade2");
        bottonBorder2 = GameObject.Find("bottonBorder2");
        doorBlade3 = GameObject.Find("doorBlade3");
        bottonBorder3 = GameObject.Find("bottonBorder3");
        topBorder3 = GameObject.Find("topBorder3");
        doorBlade4 = GameObject.Find("doorBlade4");
        topBorder4 = GameObject.Find("topBorder4");
        bottonBorder4 = GameObject.Find("bottonBorder4");
        doorBlade5 = GameObject.Find("doorBlade5");
        bottonBorder5 = GameObject.Find("bottonBorder5");

        isRespawnRoom = false;
        isQuestiontrue = false;
        istrickyCubeclose = false;
        isIdkQuestionTrue = false;
        Coin = 0;
        
    }



    void Update()
    {

        
    
        if (Coin == 1)
        {

            float dist = Vector3.Distance(doorBlade1.transform.position, bottonBorder1.transform.position);
            if (dist <= 5)
            {
                Vector3 targetPosition = doorBlade1.transform.TransformPoint(new Vector3(0, -2, 0));
                doorBlade1.transform.position = Vector3.SmoothDamp(doorBlade1.transform.position, targetPosition, ref velocity, smoothTime);
            }
            else
            {
                Vector3 targetPosition = doorBlade1.transform.TransformPoint(new Vector3(0, 0, 0));
                doorBlade1.transform.position = Vector3.SmoothDamp(doorBlade1.transform.position, targetPosition, ref velocity, smoothTime);
            }
        }

        if (isQuestiontrue)
        {
            StartCoroutine(openGateTimer());
            
        }

        if (Coin == 2)
        {
            float dist = Vector3.Distance(doorBlade3.transform.position, bottonBorder3.transform.position);
            if (dist <= 5)
            {
                Vector3 targetPosition = doorBlade3.transform.TransformPoint(new Vector3(0, -2, 0));
                doorBlade3.transform.position = Vector3.SmoothDamp(doorBlade3.transform.position, targetPosition, ref velocity, smoothTime);
            }
            else
            {
                Vector3 targetPosition = doorBlade3.transform.TransformPoint(new Vector3(0, 0, 0));
                doorBlade3.transform.position = Vector3.SmoothDamp(doorBlade3.transform.position, targetPosition, ref velocity, smoothTime);
            }
        }
        if (Coin == 5)
        {
            float dist = Vector3.Distance(doorBlade5.transform.position, bottonBorder5.transform.position);
            if (dist <= 5)
            {
                Vector3 targetPosition = doorBlade5.transform.TransformPoint(new Vector3(0, -2, 0));
                doorBlade5.transform.position = Vector3.SmoothDamp(doorBlade5.transform.position, targetPosition, ref velocity, smoothTime);
            }
            else
            {
                Vector3 targetPosition = doorBlade5.transform.TransformPoint(new Vector3(0, 0, 0));
                doorBlade5.transform.position = Vector3.SmoothDamp(doorBlade5.transform.position, targetPosition, ref velocity, smoothTime);
            }
        }

        if(isIdkQuestionTrue) 
        {
            
            float dist = Vector3.Distance(doorBlade4.transform.position, bottonBorder4.transform.position);
            if (dist <= 5)
            {
                Vector3 targetPosition = doorBlade4.transform.TransformPoint(new Vector3(0, -2, 0));
                doorBlade4.transform.position = Vector3.SmoothDamp(doorBlade4.transform.position, targetPosition, ref velocity, smoothTime);
            }
            else
            {
                Vector3 targetPosition = doorBlade4.transform.TransformPoint(new Vector3(0, 0, 0));
                doorBlade4.transform.position = Vector3.SmoothDamp(doorBlade4.transform.position, targetPosition, ref velocity, smoothTime);
            }
        }


        if (isRespawnRoom)
        {
            doorBlade3.transform.position = topBorder3.transform.position;
            doorBlade4.transform.position = topBorder4.transform.position;
            isRespawnRoom = false;
        }



        if (istrickyCubeclose)
        {
            StartCoroutine(trickyCubeTimeropen());
            istrickyCubeclose = false;
        }
        Debug.Log(Coin + "COİNCOİN");

    }



    IEnumerator trickyCubeTimeropen()
    {
        yield return new WaitForSeconds(2.7f);
        foreach (GameObject x in trickyCubes)
        {
            x.SetActive(true);

        }

    }
     IEnumerator openGateTimer()
    {
        yield return new WaitForSeconds(6.6f);
        float dist = Vector3.Distance(doorBlade2.transform.position, bottonBorder2.transform.position);
        if (dist <= 5)
        {
            Vector3 targetPosition = doorBlade2.transform.TransformPoint(new Vector3(0, -2, 0));
            doorBlade2.transform.position = Vector3.SmoothDamp(doorBlade2.transform.position, targetPosition, ref velocity, smoothTime);
        }
        else
        {
            Vector3 targetPosition = doorBlade2.transform.TransformPoint(new Vector3(0, 0, 0));
            doorBlade2.transform.position = Vector3.SmoothDamp(doorBlade2.transform.position, targetPosition, ref velocity, smoothTime);
        }
    }


   

}
