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
            MoveTowardsRandomLocation();
        }
	}
    
    Vector3 SetRandomLocation()
    {

        //pick a new dest
        Vector3 vector = new Vector3(Random.Range(0, 1000), Random.Range(0, 500), Random.Range(-300, 300));
        return  randomTarget = vector;
    }
    
    void MoveTowardsRandomLocation()
    {
        GameObject g = new GameObject("Temp");
        g.transform.position = randomTarget;
        FollowTargetWithRotation(g.transform, 50, 20);
        Destroy(g);

    }
    
    bool IsDestNotInRange()
    {
        var distance = (randomTarget - transform.position).magnitude;
        Debug.Log(distance >= 50);
        return distance >= 50;
    }

    void FollowTargetWithRotation(Transform target, float distanceToStop, float speed)
    {
        if (Vector3.Distance(transform.position, target.position) > distanceToStop)
        {
            transform.LookAt(target);
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
        }
    }
}
