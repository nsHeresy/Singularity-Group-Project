using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    public GameObject player;
    public GameObject Wormhole;
    public GameObject Swarm;
    
    private GameObject activeSwarm;

    int waveCount = 0;
    float timeBetweenPortals = 30f;
    float portalCooldown = 0f;

    void Start () {

        
        StartNewSwarm();
        
	}
	

    //LevelController handles the main game loop, in terms of wormhole spawning
	void Update () {

        if (activeSwarm.GetComponent<SwarmController>().IsCleared()) {
            //StartNewSwarm();
        }
	}
    
    public void StartNewSwarm() {
        //make sure the swarm is dead and done
        if (activeSwarm != null)
        {
            activeSwarm.SetActive(false);
            Destroy(activeSwarm);
            activeSwarm = null;
        }

        //make a new swarm
        activeSwarm = Instantiate(Swarm, transform);
        activeSwarm.GetComponent<SwarmController>().StartSwarm(player);
    }
    

    public SwarmController GetActiveSwarm() {
        return activeSwarm.GetComponent<SwarmController>();
    }
}
