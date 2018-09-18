using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmBehaviour : MonoBehaviour {
    private GameObject Controller;
    private bool inited = false;
    private float minVelocity;
    private float maxVelocity;
    private float randomness;
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
                body.velocity = body.velocity + Calc() * Time.deltaTime;

                // enforce minimum and maximum speeds for the boids
                float speed = body.velocity.magnitude;
                if (speed > maxVelocity)
                {
                    body.velocity = body.velocity.normalized * maxVelocity;
                }
                else if (speed < minVelocity)
                {
                    body.velocity = body.velocity.normalized * minVelocity;
                }

                // check for upcoming obstacles

            }

            float waitTime = Random.Range(0.3f, 0.5f);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private Vector3 Calc()
    {
        Vector3 randomize = new Vector3((Random.value * 2) - 1, (Random.value * 2) - 1, (Random.value * 2) - 1);

        randomize.Normalize();
        SwarmController swarmController = Controller.GetComponent<SwarmController>();
        Vector3 flockCenter = swarmController.flockCenter;
        Vector3 flockVelocity = swarmController.flockVelocity;
        Vector3 follow = chasee.transform.localPosition;

        flockCenter = flockCenter - transform.localPosition;
        flockVelocity = flockVelocity - body.velocity;
        follow = follow - transform.localPosition;

        return (flockCenter + flockVelocity + follow * 2 + randomize * randomness);
    }

    public void SetController(GameObject theController)
    {
        Controller = theController;
        SwarmController swarmController = Controller.GetComponent<SwarmController>();
        minVelocity = swarmController.minVelocity;
        maxVelocity = swarmController.maxVelocity;
        randomness = swarmController.randomness;
        chasee = swarmController.chasee;
        inited = true;
    }
}