using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour
{

    private AudioSource source;
    public AudioClip TryAgain;
    public AudioClip hit1;
    public AudioClip hit2;
    public AudioClip hit3;
    public AudioClip died;
    public AudioClip thereIsNoEscape;
    public AudioClip WellDone;
    public AudioClip staminaEndsUp;
    public AudioClip yourAnswerIsCorrect;
    public AudioClip yourAnswerIsWrong;
    public AudioClip iDontKnow;


    public bool correctCheck = false;
    public bool wrongCheck = false;
    public bool escapeCheck = false;
    public bool hit1Check = false;
    public bool hit2Check = false;
    public bool hit3Check = false;
    public bool deadCheck = false;
    public bool idkCheck = false;
    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        staminaSound();
        //diedCheck();

        if (idkCheck)
        {
            idkSound();
            idkCheck = false;

        }

        if (correctCheck)
        {
            correctAnswer();
            correctCheck = false;
        }

        if (wrongCheck)
        {
            wrongAnswer();
            wrongCheck = false;
        }

        if (escapeCheck)
        {
            noEscape();
            escapeCheck = false;
        }

        if (hit1Check)
        {
            hit1Sound();
            hit1Check = false;
        }

        if (hit2Check)
        {
            hit2Sound();
            hit2Check = false;

        }

        if (hit3Check)
        {
            hit3Sound();
            hit3Check = false;

        }

        if (deadCheck)
        {
            playerDied();
            deadCheck = false;
        }
    }

    void staminaSound()
    {
        if (GetComponent<StaminaBar>().mana <= 0)
        {
            source.PlayOneShot(staminaEndsUp, 0.6F);
        }
    }

    void playerDied()
    {

            source.PlayOneShot(died, 1F);

    }

    public void correctAnswer()
    {
        source.PlayOneShot(yourAnswerIsCorrect, 1F);
    }

    public void wrongAnswer()
    {
        source.PlayOneShot(yourAnswerIsWrong, 1F);
    }

    public void noEscape()
    {
        source.PlayOneShot(thereIsNoEscape, 0.8f);
    }

    public void hit1Sound()
    {
        source.PlayOneShot(hit1, 0.6f);
    }

    public void hit2Sound()
    {
        source.PlayOneShot(hit2, 0.8f);
    }

    public void hit3Sound()
    {
        source.PlayOneShot(hit3, 1);
    }

    public void idkSound()
    {
        source.PlayOneShot(iDontKnow, 1);
    }
}
