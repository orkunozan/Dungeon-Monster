using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkRoomScript : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.isQuestiontrue = false;
            CheckAnswer.answerCounter = 0;
        }
    }
}
