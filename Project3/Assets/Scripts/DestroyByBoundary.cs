using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {
    

    /// <summary>
    /// Destroys any object that collides with this object (boundary object)
    /// </summary>
    /// <param name="collision">Data on the collision that took place</param>
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
