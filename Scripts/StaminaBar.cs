using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StaminaBar : MonoBehaviour {
    public RawImage manaBar;
    public float mana = 100;
    public Text manaAmount;
    bool isOverMana;
   
    
	
	void Update () {

        if (!isOverMana)
        {
            hizlan();
        }

        manaBarManage();


    }




    void hizlan()
    {


        if (Input.GetKey(KeyCode.LeftShift) &&( Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D)) )
        {
            if (mana == 0)
            {
                Movecharacter.movementSpeed= 6;
                Debug.Log(Movecharacter.movementSpeed);
            }
            else
            {

                Movecharacter.movementSpeed = 10;
                Debug.Log(Movecharacter.movementSpeed);
            }


            /*speed = 6;
            if (mana == 0)
            {
                speed = 4;
            }*/

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            Movecharacter.movementSpeed = 6;

            Debug.Log("Speed"+Movecharacter.movementSpeed);
        }


    }


    void manaBarManage()
    {



        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (!isOverMana)
            {
                mana -= 25 * Time.deltaTime;
                manaBar.rectTransform.localScale = new Vector3(mana / 100, 1, 1);
                manaAmount.text = "" + (int)mana;
            }
            else
            {
                mana += 30 * Time.deltaTime;
                if (mana > 100)
                {
                    mana = 100;

                }
                manaBar.rectTransform.localScale = new Vector3(mana / 100, 1, 1);
                manaAmount.text = "" + (int)mana;

            }

            if (mana < 0)
            {
                mana = 0;
                isOverMana = true;

                Movecharacter.movementSpeed = 6;
                Debug.Log(Movecharacter.movementSpeed);
            }
        }
        else
        {
            mana += 30 * Time.deltaTime;

            if (mana > 100)
            {
                mana = 100;

                isOverMana = false;
            }

            manaBar.rectTransform.localScale = new Vector3(mana / 100, 1, 1);
            manaAmount.text = "" + (int)mana;

        }


    }
}
