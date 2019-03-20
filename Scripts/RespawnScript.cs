using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour {

    GameObject player;
    GameObject spawnpoint;
    GameObject coin;
    Vector3 newcoinpoint;
    private void Awake()
    {
        coin = GameObject.Find("CoinX");
        player = GameObject.Find("Player");
        spawnpoint = GameObject.Find("SpawnPointrespawn");
        newcoinpoint = new Vector3(-162.372f, 16.04f, -670.92f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var getCoin = GameObject.Find("GameManager").GetComponent<GameManager>();
            getCoin.Coin -= 1;
            Instantiate(coin, newcoinpoint, Quaternion.identity);
            GameManager.isIdkQuestionTrue = false;
            GameManager.isRespawnRoom = true;            
            CheckAnswer.answerCounter = 0;
            player.transform.position = spawnpoint.transform.position;
            Destroy(gameObject); 
        }
    }
}
