using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapComponent : MonoBehaviour {

    private Quaternion rot;
    
	void Start () {
        rot = transform.rotation;
	}
	
	void LateUpdate () {
        transform.rotation = rot;
	}
}
