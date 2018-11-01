using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// Apply this script to a minimap Quad to have it track the X and Z locations of its given object,
/// while still maintaining a constant Y location.
/// 
/// </summary>
/// 
public class MinimapTracking : MonoBehaviour {

    public GameObject trackingObject;
    public float offset;    //how far above the object should this thing track.
    float initHeight;

    private void Start()
    {
        initHeight = this.transform.position.y;
    }


    void LateUpdate () {
        Vector3 objectPos = trackingObject.transform.position;
        transform.position = new Vector3(objectPos.x, objectPos.y + offset, objectPos.z);
	}
}
