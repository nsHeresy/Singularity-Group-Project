using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenicBody : MonoBehaviour {

    float RotationSpeed = 0.005f;
    float modifier = 0.5f;
    
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(RotationSpeed * modifier * Time.timeScale, RotationSpeed * modifier * Time.timeScale, RotationSpeed * modifier * Time.timeScale));
	}
}
