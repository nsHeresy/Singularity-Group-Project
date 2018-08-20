using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    public GameObject player;
    public GameObject Wormhole;

    public Image panel;

    int waveCount = 0;
    float timeBetweenPortals = 60f;
    float portalCooldown = 0f;



	// Use this for initialization
	void Start () {

        Color fadeToClear = new Color(1f, 1f, 1f, 0f);
        panel.GetComponent<FadeIn>().PanelFade(fadeToClear, 3f, false);

        
	}
	
	// Update is called once per frame
	void Update () {


        if (portalCooldown <= 0)
        {
            GetComponent<AudioSource>().Play();
            OpenPairedPortals();
        }
        else
            portalCooldown -= Time.deltaTime;


        if (player == null) {
            Debug.Log("End the Game");
            Time.timeScale = 0.2f;
        }
		
	}

    ArrayList OpenPairedPortals() {

        portalCooldown = timeBetweenPortals;

        int numPortalPairs = Random.Range(1,3);
        ArrayList portalPairs = new ArrayList();

        for (int n = 0; n < numPortalPairs; n++) {

            Vector3 locationA = new Vector3(Random.Range(-500, 500), Random.Range(-500, 500), Random.Range(-500, 500));
            Vector3 locationB = new Vector3(Random.Range(-500, 500), Random.Range(-500, 500), Random.Range(-500, 500));

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

    }
}
