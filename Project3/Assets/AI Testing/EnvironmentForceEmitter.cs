using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentForceEmitter : MonoBehaviour {

    LevelController levelController;

    float minForce = 20f;
    float maxForce = 100f;
    const float gravitationalConstant = 100f;

	// Use this for initialization
	void Start () {
        levelController = GameObject.Find("Level Controller").GetComponent<LevelController>();
	}
	
	void FixedUpdate () {
        

        GameObject[] entities = levelController.GetActiveSwarm().getEntities();

        foreach (GameObject entity in entities) {
            if(entity != null)
                ApplyForce(entity.GetComponent<SwarmBehaviour>());
        }

    }

    void ApplyForce(SwarmBehaviour entity) {
        
        Rigidbody entityrb = entity.GetComponent<Rigidbody>();

        Vector3 directionOfForce = entity.transform.position - transform.position;
        float distance = directionOfForce.magnitude;

        var forceMagnitude = gravitationalConstant * (GetComponent<Rigidbody>().mass * entityrb.mass) / Mathf.Pow(distance, 2);
        //Debug.Log(forceMagnitude);  
        var forceMultiplier = Mathf.Min(minForce, maxForce / Vector3.Distance(entity.transform.position, transform.position));
        forceMagnitude *= forceMultiplier;

        Vector3 forceVector = directionOfForce.normalized * forceMagnitude;
        //Debug.Log(forceVector);
        entityrb.AddForce(forceVector);

    }
}
