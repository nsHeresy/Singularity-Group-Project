using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Torque")]
[RequireComponent(typeof(Rigidbody))]

/**
 * MouseTorque.cs - a mouselook implementation using torque
 * 
 * All of the smooth mouse look scripts I found used input averages over the last several frames, which
 * ends up not being all that smooth really.  This camera script uses rotational forces (torques) to
 * rotate the camera in response to mouse movement.
 * 
 * The caveat of this camera is that it is possible for the camera to become slightly unstable.  Use
 * the rigidbody properties (mainly angular drag) as well as the correctiveStrength variable to affect
 * the stability of the rotations.
 * 
 * Note: make sure that "Use Gravity" is unchecked in the rigidbody settings.
 * Note: use an angular drag of about 5 or 6.
 * Note: setting a sensitivity value to a negative value inverts that axis.
 * 
 * Author: Robert Grant
 */
public class PlayerCameraController : MonoBehaviour
{
    public void Start()
    {
        
    }

    public void Update()
    {
        
    }
}