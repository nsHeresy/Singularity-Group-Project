using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmController : MonoBehaviour {

    public float minVelocity = 5;
    public float maxVelocity = 20;
    public float randomness = 1;
    public int flockSize = 3;
    public GameObject prefab;
    public GameObject chasee;

    public Vector3 flockCenter;
    public Vector3 flockVelocity;

    private GameObject[] entities;

    void Start() {

        Collider swarmBound = GetComponent<Collider>();

        entities = new GameObject[flockSize];
        for (var i = 0; i < flockSize; i++)
        {
            Vector3 position = new Vector3(
                Random.value * swarmBound.bounds.size.x,
                Random.value * swarmBound.bounds.size.y,
                Random.value * swarmBound.bounds.size.z
            ) - swarmBound.bounds.extents;

            GameObject entity = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
            entity.transform.parent = transform;
            entity.transform.localPosition = position;
            entity.GetComponent<SwarmBehaviour>().SetController(gameObject);
            entities[i] = entity;
        }
    }

    void Update()
    {
        Vector3 theCenter = Vector3.zero;
        Vector3 theVelocity = Vector3.zero;

        foreach (GameObject entity in entities)
        {
            theCenter = theCenter + entity.transform.localPosition;
            theVelocity = theVelocity + entity.GetComponent<Rigidbody>().velocity;
        }

        flockCenter = theCenter / (flockSize);
        flockVelocity = theVelocity / (flockSize);
    }
}
