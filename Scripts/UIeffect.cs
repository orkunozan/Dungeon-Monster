using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIeffect : MonoBehaviour {

	
	void FixedUpdate () {
        gameObject.transform.Rotate(0, 0.5f, 0);
	}
}
