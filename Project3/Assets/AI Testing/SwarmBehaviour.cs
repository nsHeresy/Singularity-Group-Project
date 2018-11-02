using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmBehaviour : MonoBehaviour {
    private GameObject Controller;
    private bool inited = false;
    private float minVelocity;
    private float maxVelocity;
    private float randomness;
    private float collisionDetectionRadius = 20;
    private float RotationMargin = 0.1f;
    private float TurnSpeed = 50;
    private GameObject chasee;
    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        StartCoroutine("SwarmSteering");
    }

    IEnumerator SwarmSteering() {
        while (true)
        {
            if (inited)
            {
                //Vector3 nearestCollision = CheckIfCollisionImminent();
                //if (nearestCollision != transform.position)
                //{

                //    Debug.Log("Something to collide with");
                //    DoCollisionAvoidance(nearestCollision);
                    
                //}
                
                body.velocity = body.velocity + Calc() * Time.deltaTime;
                EnforceSpeedBounds(); 
                //transform.rotation = Quaternion.LookRotation(body.velocity);
            }

            var waitTime = Random.Range(0.3f, 0.5f);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private Vector3 CheckIfCollisionImminent() {
        var nearObjects = Physics.OverlapSphere(transform.position, collisionDetectionRadius, 9);
        if (nearObjects.Length == 0)
            return transform.position;
        else {
            var avgLocation = new Vector3(0,0,0);
            foreach (var t in nearObjects)
            {
                avgLocation += t.transform.position;
            }
            avgLocation = avgLocation / nearObjects.Length;

            //Might need to find nearest collision instead
            return avgLocation;
        }
    }

    private void DoCollisionAvoidance(Vector3 position) {
        Vector3 facing = position - transform.position;
        if (facing.magnitude < RotationMargin) { return; }

        // Rotate the rotation AWAY from the player...
        Quaternion awayRotation = Quaternion.LookRotation(facing);
        Vector3 euler = awayRotation.eulerAngles;
        euler.y -= 180;
        awayRotation = Quaternion.Euler(euler);

        // Rotate the game object.
        transform.rotation = Quaternion.Slerp(transform.rotation, awayRotation, TurnSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        EnforceSpeedBounds();
    }

    private Vector3 Calc()
    {
        var randomize = new Vector3((Random.value * 2) - 1, (Random.value * 2) - 1, (Random.value * 2) - 1);

        randomize.Normalize();
        var swarmController = Controller.GetComponent<SwarmController>();
        var flockCenter = swarmController.FlockCenter;
        var flockVelocity = swarmController.FlockVelocity;
        var follow = chasee.transform.localPosition;

        flockCenter = flockCenter - transform.localPosition;
        flockVelocity = flockVelocity - body.velocity;
        follow = follow - transform.localPosition;

        return (flockCenter + flockVelocity + follow * 2 + randomize * randomness);
    }

    private void EnforceSpeedBounds() {
        float speed = body.velocity.magnitude;
        if (speed > maxVelocity)
        {
            body.velocity = body.velocity.normalized * maxVelocity;
        }
        else if (speed < minVelocity)
        {
            body.velocity = body.velocity.normalized * minVelocity;
        }
    }

    private Vector3 GetFlockVelocity() {
        return Controller.GetComponent<SwarmController>().FlockVelocity.normalized;
    }

    public void SetController(GameObject theController)
    {
        Controller = theController;
        SwarmController swarmController = Controller.GetComponent<SwarmController>();
        minVelocity = swarmController.MinVelocity;
        maxVelocity = swarmController.MaxVelocity;
        randomness = swarmController.Randomness;
        chasee = swarmController.Chasee;
        inited = true;
    }
}