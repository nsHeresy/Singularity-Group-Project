using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Panda;

public class EnemyAI : MonoBehaviour {

    private Transform target;
    private Transform myTransform;
    private Vector3 randomTarget;

    //AI stuff
    public float rotationSpeed;
    public float maxDist;
    public float fireDist;

    //AI Speeds
    public float moveSpeed;

    void Start()
    {
        Rigidbody r = GetComponent<Rigidbody>();
        r.velocity = r.transform.forward * moveSpeed;

        target = GameObject.FindGameObjectWithTag("Player").transform;
        myTransform = this.transform;

        Vector3 vector = new Vector3(Random.Range(-500, 500), Random.Range(-500, 500), Random.Range(-500, 500));
        randomTarget = vector;
    }

    [Task]
    void RotateTowardsPlayer()
    {
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
    }

    [Task]
    void MoveForward()
    {
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
    }

    [Task]
    bool IsPlayerWithinApproachRange()
    {
        var distance = (target.position - myTransform.position).magnitude;
        return distance < maxDist;
    }

    [Task]
    bool IsPlayerWithinAttackRange()
    {
        var distance = (target.position - myTransform.position).magnitude;
        return distance < fireDist;
    }

    [Task]
    void Fire()
    {
        // Fire code here
        Task.current.Succeed();
    }

    [Task]
    void SetRandomLocation() {

        //pick a new dest
        Vector3 vector = new Vector3(Random.Range(-500,500), Random.Range(-500, 500), Random.Range(-500, 500));
        randomTarget = vector;
    }

    [Task]
    void MoveTowardsRandomLocation() {

    }

    [Task]
    bool IsDestNotInRange () {
        Debug.Log("MeepMeep");
        var distance = (randomTarget - myTransform.position).magnitude;
        Debug.Log(distance >= 50);
        return distance >= 50;
    }
    
}
