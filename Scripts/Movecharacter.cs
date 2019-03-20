using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecharacter : MonoBehaviour
{

    public static float movementSpeed = 6;
    private CharacterController cc;
    public AnimationCurve jumpFallOff;
    public float jumpMultiplier;
    private bool isJumping;
    public GameObject FlashLight;
    bool isLightOn;
    float fallingTime = 0;
    public static int groundCounter = 0;
    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        isLightOn = false;
    }

    private void Update()
    {

        PlayerMovement();

        Flashlight();

    }

    private void FixedUpdate()
    {
        fallingDamage();
    }

    private void PlayerMovement()
    {
        float hori = Input.GetAxis("Horizontal") * movementSpeed;
        float vert = Input.GetAxis("Vertical") * movementSpeed;
        Vector3 moveForward = transform.forward * vert;
        Vector3 moveRight = transform.right * hori;
        cc.SimpleMove(moveForward + moveRight);



        jumpInput();

    }
    private void jumpInput()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {

            isJumping = true;
            StartCoroutine(JumpEvent());
        }

    }
    private void Flashlight()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isLightOn)
        {
            FlashLight.SetActive(true);
            isLightOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isLightOn)
        {
            FlashLight.SetActive(false);
            isLightOn = false;
        }
    }

    void fallingDamage()
    {

        if (groundCounter == 0)
        {

            if (cc.isGrounded)
            {

                groundCounter += 1;
            }
        }

        if (groundCounter == 1)
        {
            if (!cc.isGrounded)
            {
                fallingTime += Time.deltaTime;


            }







            if (cc.isGrounded)
            {

                if (1.30f > fallingTime && fallingTime >= 1.25f)
                {
                    gameObject.GetComponent<HealthBar>().health -= 20;
                    var hit1 = GameObject.Find("Player").GetComponent<audioScript>();
                    hit1.hit1Check = true;


                    HealthBar.isHit = true;
                    StartCoroutine(hittimer());

                }

                else if (1.55f > fallingTime && fallingTime >= 1.30f)
                {
                    gameObject.GetComponent<HealthBar>().health -= 30;
                    var hit2 = GameObject.Find("Player").GetComponent<audioScript>();
                    hit2.hit2Check = true;

                    HealthBar.isHit = true;
                    StartCoroutine(hittimer());
                }

                else if (fallingTime >= 1.55)
                {
                    gameObject.GetComponent<HealthBar>().health -= 50;
                    var hit3 = GameObject.Find("Player").GetComponent<audioScript>();
                    hit3.hit3Check = true;

                    HealthBar.isHit = true;
                    StartCoroutine(hittimer());
                }

                fallingTime = 0;


            }

        }

    }



    IEnumerator hittimer()
    {
        yield return new WaitForSeconds(0.2f);

        HealthBar.isHit = false;
    }

    private IEnumerator JumpEvent()
    {
        cc.slopeLimit = 90f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            cc.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;

        } while (!cc.isGrounded);


        isJumping = false;

        cc.slopeLimit = 90f;

    }







}





