using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapComponent : MonoBehaviour {

    private Quaternion rot;
    private float yPos;

    private MinimapTracking minimap;
    
	void Start () {
        rot = transform.rotation;
	}
	
	void LateUpdate () {

        //transform.position = new Vector3(transform.position.x, minimap.transform.position.y + minimap.offset, transform.position.z);
        transform.rotation = rot;
	}
}
