using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoin : MonoBehaviour {



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var getCoin = GameObject.Find("GameManager").GetComponent<GameManager>();
            getCoin.Coin += 1;
            Destroy(gameObject);
        }
    }

}
