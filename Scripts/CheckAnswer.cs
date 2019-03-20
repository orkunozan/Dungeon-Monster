using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{

    public static int answerCounter = 0;
    static GameObject[] enemies;


    private void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("cannonEnemy");
        Debug.Log("Enemy sayısı : " + enemies.Length);
    }

    private void Update()
    {
        if (GameManager.isQuestiontrue)
        {
            answerCounter = 1;
        }

    }

    void OnMouseDown()
    {
        if (tag == "correct" && answerCounter == 0)
        {

            answerCounter++;
            Debug.Log("Correct Answer" + answerCounter);
            GameManager.isQuestiontrue = true;          
            var correct = GameObject.Find("Player").GetComponent<audioScript>();
            correct.correctCheck = true;


        }// başka odaya geçtiğinde answerCounterı sıfırla.

        if (tag == "wrong" && answerCounter == 0)
        {
            answerCounter++;
            Debug.Log("Wrong Answer. You will die for that!" + answerCounter);
            var wrong = GameObject.Find("Player").GetComponent<audioScript>();
            wrong.wrongCheck = true;
            //Debug.Log("enemy sayısı : " + enemies);

            StartCoroutine(killPlayerTimer());
         

        }

        if (tag == "idk" && answerCounter == 0)
        {
            answerCounter++;
            GameManager.isIdkQuestionTrue = true;
            var idk = GameObject.Find("Player").GetComponent<audioScript>();
            idk.idkCheck = true;
        }


    }

    public static void resetEnemiesActivity()
    {
        foreach (GameObject x in enemies)
        {
            x.GetComponent<SphereCollider>().enabled = false;

        }

        answerCounter = 0;
    }

    IEnumerator killPlayerTimer()
    {
        yield return new WaitForSeconds(5);
        foreach (GameObject x in enemies)
        {
            x.GetComponent<SphereCollider>().enabled = true;


        }
    }
}