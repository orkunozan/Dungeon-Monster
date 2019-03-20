using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickStep : MonoBehaviour
{
    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            StartCoroutine(trickyCubeTimerclose());
            GameManager.istrickyCubeclose = true;
        }
        
    }
        private IEnumerator trickyCubeTimerclose()
    {
        yield return new WaitForSeconds(0.70f);
        gameObject.SetActive(false);

        
    }
    

}


