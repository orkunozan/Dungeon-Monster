using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public static bool isHit;
    public RawImage healthBar;
    public float health = 100;
    public Text healthAmount;
    GameObject spawnpoint;
    GameObject checkpoint;
    CameraControl mousesensitivitycheck;
    

    private void Awake()
    {
        
        mousesensitivitycheck = GameObject.Find("Camera").GetComponent<CameraControl>();
        spawnpoint = GameObject.Find("SpawnPoint");
        checkpoint = GameObject.Find("Checkpoint");

    }


    private void Start()
    {
        
    }

    void Update () {



        healthBar.rectTransform.localScale = new Vector3(health / 100, 1, 1);
        healthAmount.text = "" + (int)health;


        if(health >= 100)
        {
            health = 100;
        }


        if (health <= 0)
        {
            Movecharacter.movementSpeed = 0;
            mousesensitivitycheck.mouseSensitivity = 0;
            health = 0;
            StartCoroutine(deadtimer());
        }
    }

    IEnumerator deadtimer()
    {
        yield return new WaitForSeconds(3.5F);

        var getCoin = GameObject.Find("GameManager").GetComponent<GameManager>();


        if (getCoin.Coin >= 3)
        {
            gameObject.transform.position = checkpoint.transform.position;
        }


        else
        {
            gameObject.transform.position = spawnpoint.transform.position;
        }
       
        health = 100;
        mousesensitivitycheck.mouseSensitivity = 94.01f;
        Movecharacter.movementSpeed = 6;

        Transform a = GameObject.Find("Camera").GetComponent<Transform>();
        a.localPosition = new Vector3(0,0.5f,0);
        a.localRotation=Quaternion.Euler(0,0,0);
        Movecharacter.groundCounter = 0;

        CheckAnswer.resetEnemiesActivity();

        Debug.Log("Can" + health);
        
       
    }


    


    


}
