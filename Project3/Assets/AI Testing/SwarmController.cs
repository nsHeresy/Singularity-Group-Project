using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmController : MonoBehaviour {

    public float minVelocity = 5;
    public float maxVelocity = 20;
    public float randomness = 1;
    public int flockSize = 1;
    public GameObject prefab;
    public GameObject chasee;

    public Vector3 flockCenter;
    public Vector3 flockVelocity;

    private GameObject[] entities;
    private Collider swarmBound;
    private LevelController levelController;

    private bool hasCleared = false;

    public void StartSwarm(GameObject target) {

        chasee = target;

        swarmBound = GetComponent<Collider>();

        levelController = GameObject.Find("Level Controller").GetComponent<LevelController>();

        GenerateSwarm();


    }

    void Update()
    {
        Vector3 theCenter = Vector3.zero;
        Vector3 theVelocity = Vector3.zero;

        if (hasCleared)
            return;

        int deadCount = 0;
        for (int n = 0; n < entities.Length; n++)
        {
            GameObject entity = entities[n];
            if (entity != null && (entity as Object) != null)
            {

                theCenter = theCenter + entity.transform.localPosition;
                theVelocity = theVelocity + entity.GetComponent<Rigidbody>().velocity;
            }
            else {
                entity = null;
                deadCount++;
            }
        }

        if(deadCount == entities.Length)
        {
            hasCleared = true;
            entities = null;
            return;
        }

        flockCenter = theCenter / (flockSize);
        flockVelocity = theVelocity / (flockSize);
    }

    void GenerateSwarm() {

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

    public bool IsCleared() {
        return this.hasCleared;
    }

    public GameObject[] getEntities() {
        return entities;
    }
}
