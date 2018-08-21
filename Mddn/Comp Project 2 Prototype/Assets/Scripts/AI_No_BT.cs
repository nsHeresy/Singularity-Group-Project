using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_No_BT : MonoBehaviour {

    Vector3 randomTarget;

	// Use this for initialization
	void Start () {
        randomTarget = SetRandomLocation();

	}
	
	// Update is called once per frame
	void Update () {
        if (IsDestNotInRange())
        {
            MoveTowardsRandomLocation();
        }
        else {
            SetRandomLocation();
        }
	}
    

    /// <summary>
    /// Set a random location in the scene for the enemy to move towards
    /// </summary>
    /// <returns> The new random location for the enemy to go towards</returns>
    Vector3 SetRandomLocation()  {
        Vector3 vector = new Vector3(Random.Range(0, 1000), Random.Range(0, 500), Random.Range(-300, 300));
        return  randomTarget = vector;
    }
    
    /// <summary>
    /// Generates a placeholder gameObject at the position of the random location
    /// Then uses its transform to instruct the enemy on where to move
    /// </summary>
    void MoveTowardsRandomLocation()
    {
        GameObject g = new GameObject("Temp");
        g.transform.position = randomTarget;
        FollowTargetWithRotation(g.transform, 50, 20);
        Destroy(g);

    }
    
    /// <summary>
    /// Check if this enemy is in range of its destination
    /// </summary>
    /// <returns>True if the enemy is close to its target, False otherwise</returns>
    bool IsDestNotInRange()
    {
        var distance = (randomTarget - transform.position).magnitude;
        Debug.Log(distance >= 50);
        return distance >= 50;
    }

    /// <summary>
    /// Moves the enemy towards their target, using the Rigidbody force system.
    /// </summary>
    /// <param name="target">The transform to move towards</param>
    /// <param name="distanceToStop">How close it needs to get</param>
    /// <param name="speed">How fast it can travel to get there</param>
    void FollowTargetWithRotation(Transform target, float distanceToStop, float speed)
    {
        if (Vector3.Distance(transform.position, target.position) > distanceToStop)
        {
            transform.LookAt(target);
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
            //StartCoroutine(DoCollisionAvoidance());
        }
    }

    /// <summary>
    /// Stub for collision detection and avoidance - yet to be implemented.
    /// </summary>
    /// <returns></returns>
    IEnumerator DoCollisionAvoidance() {
        //stub
        yield return null;
    }
}
