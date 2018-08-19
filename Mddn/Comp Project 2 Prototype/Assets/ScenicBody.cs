using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenicBody : MonoBehaviour {

    float RotationSpeed = 0.005f;
    
	// Update is called once per frame
	void Update () {
        if(!PauseController.isGamePaused)
        transform.Rotate(new Vector3(RotationSpeed,RotationSpeed,RotationSpeed));
	}
}
