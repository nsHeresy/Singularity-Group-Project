using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    public GameObject player;
    public GameObject Wormhole;
    public GameObject Swarm;

    public Image panel;
    public Image gameOverPanel;

    public Canvas gameOverUI;
    public Canvas gameUI;

    private GameObject activeSwarm;

    int waveCount = 0;
    float timeBetweenPortals = 30f;
    float portalCooldown = 0f;

    bool isInited = false;

    ArrayList portalPairs;



    void Start () {
        //At the start of the game, fade the player's 'event panel' in to transparent
        //from black.

        //Color fadeToClear = new Color(1f, 1f, 1f, 0f);
        //panel.GetComponent<FadeIn>().PanelFade(fadeToClear, 3f, false);
        StartNewSwarm();
        
	}
	

    //LevelController handles the main game loop, in terms of wormhole spawning
	void Update () {

        if (isInited)
        {
            //only fires new wormholes when the cooldown is ready
            if (portalCooldown <= 0)
            {
                GetComponent<AudioSource>().Play();
                OpenPairedPortals();
            }
            else
                portalCooldown -= Time.deltaTime;


            //if the player is destroyed somehow, the game will end
            if (player == null)
            {
                EndTheGame();
            }
        }

        if (activeSwarm.GetComponent<SwarmController>().IsCleared()) {
            Debug.Log("Okay");
            //StartNewSwarm();
        }
	}

    //destroys each of the portals in the scene currently. 
    void DestroyPortals() {
        foreach (GameObject a in portalPairs)
        {
            Destroy(a);
        }
    }


    //Generates a random number of portal pairs in the scene, at random locations.
    //Can generate between 1 and 3 pairs at a time
    //links these wormholes to each other, the player, and the UI
    //returns the list of all created portal pairs
    ArrayList OpenPairedPortals() {

        portalCooldown = timeBetweenPortals;

        int numPortalPairs = Random.Range(1,3);
        portalPairs = new ArrayList();

        for (int n = 0; n < numPortalPairs; n++) {

            Vector3 locationA = new Vector3(Random.Range(0, 1000), Random.Range(0, 500), Random.Range(-300, 300));
            Vector3 locationB = new Vector3(Random.Range(0, 1000), Random.Range(0, 500), Random.Range(-300, 300));

            GameObject portalA = GameObject.Instantiate(Wormhole, locationA, Random.rotation);
            GameObject portalB = GameObject.Instantiate(Wormhole, locationB, Random.rotation);

            portalA.GetComponent<Teleport>().sisterWormhole = portalB;
            portalA.GetComponent<Teleport>().player = player;
            portalA.GetComponent<Teleport>().panel = panel;

            portalB.GetComponent<Teleport>().sisterWormhole = portalA;
            portalB.GetComponent<Teleport>().player = player;
            portalB.GetComponent<Teleport>().panel = panel;

            portalPairs.Add(portalA);
            portalPairs.Add(portalB);
        }

        return portalPairs;
    }

    void openLevel() {
        //stub - interior level transfer
    }



    //called when the player is destroyed somehow
    //free the cursor, fade to black
    //show the Game Over UI
    void EndTheGame() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        gameUI.enabled = false;
        gameOverUI.enabled = true;
        gameOverPanel.GetComponent<FadeIn>().PanelFade(new Color(0f, 0f, 0f, 255f), 2f, false);
        Time.timeScale = 0.2f;

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
