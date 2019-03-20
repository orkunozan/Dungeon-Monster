using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class END : MonoBehaviour {
    public float smoothTime = 0.3F;
    public float speed=10;
    private Vector3 velocity = Vector3.zero;
    public GameObject textTopBorder;
    public GameObject text;
    public GameObject button;

    private void Awake()
    {
        button.SetActive(false);

    }

    private void Update()
    {
        float dist = Vector3.Distance(textTopBorder.transform.position, text.transform.position);
      
            if (dist >= 5) 
            {
                Vector3 targetPosition = text.transform.TransformPoint(new Vector3(0, speed, 0)); 
                text.transform.position = Vector3.SmoothDamp(text.transform.position, targetPosition, ref velocity, smoothTime);
            }                                                                                                 
                                                                                                               
            else
            {
                Vector3 targetPosition = text.transform.TransformPoint(new Vector3(0, 0, 0));
                text.transform.position = Vector3.SmoothDamp(text.transform.position, targetPosition, ref velocity, smoothTime);
                button.SetActive(true);
            }
        }


    public void BackMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
