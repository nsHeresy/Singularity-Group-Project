using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Out of Bounds. Destroying.");
        Destroy(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Something collided");
        //Destroy(collision.gameObject);
    }
}
