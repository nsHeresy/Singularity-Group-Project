using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmController : MonoBehaviour {

    public float MinVelocity = 5;
    public float MaxVelocity = 20;
    public float Randomness = 1;
    public int FlockSize = 1;
    public GameObject Prefab;
    public GameObject Chasee;

    public Vector3 FlockCenter;
    public Vector3 FlockVelocity;

    private GameObject[] _entities;
    private Collider _swarmBound;
    private LevelController _levelController;

    private bool _hasCleared = false;

    public void StartSwarm(GameObject target) {

        Chasee = target;

        _swarmBound = GetComponent<Collider>();

        _levelController = GameObject.Find("Level Controller").GetComponent<LevelController>();

        GenerateSwarm();
    }

    private void Update()
    {
        var theCenter = Vector3.zero;
        var theVelocity = Vector3.zero;

        if (_hasCleared) return;

        var deadCount = 0;
        for (int n = 0; n < _entities.Length; n++)
        {
            GameObject entity = _entities[n];
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

        if(deadCount == _entities.Length)
        {
            _hasCleared = true;
            _entities = null;
            return;
        }

        FlockCenter = theCenter / (FlockSize);
        FlockVelocity = theVelocity / (FlockSize);
    }

    private void GenerateSwarm() {

        _entities = new GameObject[FlockSize];
        for (var i = 0; i < FlockSize; i++)
        {
            var position = new Vector3(
                Random.value * _swarmBound.bounds.size.x,
                Random.value * _swarmBound.bounds.size.y,
                Random.value * _swarmBound.bounds.size.z
            ) - _swarmBound.bounds.extents;

            var entity = Instantiate(Prefab, transform.position, transform.rotation) as GameObject;
            entity.transform.parent = transform;
            entity.transform.localPosition = position;
            entity.GetComponent<SwarmBehaviour>().SetController(gameObject);
            _entities[i] = entity;
        }
    }
    
    public bool IsCleared() {
        return _hasCleared;
    }

    public IEnumerable<GameObject> GetEntities() {
        return _entities;
    }
}
