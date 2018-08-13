using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {
   
	float curSpeed;
	float maxSpeed = 50;
	float acc =50;
	float dec = 100;
	float rotateSpeed = 10f;
	float mouseRotate = 0.5f;

    float maxVelocity = 50;
    float minVelocity = 0;


    /** Controls how sensitive the horizontal axis is. */
    public float horizontalSensitivity = 50;

    /** Controls how sensitive the vertical axis is. */
    public float verticalSensitivity = 500;

    /** Controls how strongly the camera tries to keep itself upright. */
    public float correctiveStrength = 20;

    // Use this for initialization
    void Start () {
		curSpeed = 0;
	}

    void FixedUpdate() {

        var rigidbody = GetComponent<Rigidbody>();

        if (Input.GetKey("`"))
        {
            ResetSpeeds(rigidbody);
        }

        DoMouseSteering(rigidbody);
        DoDirectionMods(rigidbody);
    }

    void DoMouseSteering(Rigidbody rb)
    {
        //rb.AddTorque(0, Input.GetAxis("Mouse X") * horizontalSensitivity, 0);
        //rb.AddRelativeTorque(Input.GetAxis("Mouse Y") * verticalSensitivity, 0, 0);

        // Adding the two forces above creates some wobble that causes the camera to become
        // less than perfectly upright.  Set the corrective strength to zero to see what I'm
        // talking about.  The following lines help keep the camera upright.
        //Vector3 properRight = Quaternion.Euler(0, 0, -transform.localEulerAngles.z) * transform.right;
        //Vector3 uprightCorrection = Vector3.Cross(transform.right, properRight);
        //rb.AddRelativeTorque(uprightCorrection * correctiveStrength);

        Debug.Log(Input.GetAxis("Mouse X") * -5);
        if (Input.GetAxis("Mouse X") != 0)
        {
            transform.Rotate(0, 0, Input.GetAxis("Mouse X") * -5, Space.Self);
        }

        Debug.Log(Input.GetAxis("Mouse Y") * -5);
        if (Input.GetAxis("Mouse Y") != 0)
        {
            transform.Rotate(Input.GetAxis("Mouse Y") * -5, 0, 0);
        }


    }

    void DoDirectionMods(Rigidbody rb) {

        if (Input.GetKey("d"))
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * rotateSpeed);
        }

        if (Input.GetKey("a"))
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * -rotateSpeed);
        }

        if (Input.GetKey("w"))
        {
            rb.velocity += transform.forward * acc * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            rb.velocity -= transform.forward * dec * Time.deltaTime;
            
        }


    }

    void ResetSpeeds(Rigidbody rb) {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
