using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject spawnLocation;
    public GameObject enemyPrefab;
    public int waveSize = 30;

    bool isWaveActive = false;

    GameObject currentEnemy;
    
	
	// Update is called once per frame
	void Update () {
        
	}

     void SpawnWave(int waveSize) {
        //Stub for wave implementation
    }

    void DeleteWave() {
        //stub for deleting wave
    }

    void ModifyWave() {
        //stub for incrementing wave count, changing wave settings etc
    }




}
