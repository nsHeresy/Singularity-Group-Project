using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    public GameObject Player;
    public GameObject Swarm;
    
    private GameObject _activeSwarm;

    public Text WaveText;
    
    private int _waveCount = 0;

    private void Start () {
        StartNewSwarm();
	}
	
	private void Update () {
        if (_activeSwarm.GetComponent<SwarmController>().IsCleared()) {
            StartNewSwarm();
        }
	}
    
    public void StartNewSwarm() {
        //make sure the swarm is dead and done
        if (_activeSwarm != null)
        {
            _activeSwarm.SetActive(false);
            Destroy(_activeSwarm);
            _activeSwarm = null;
        }

        //make a new swarm
        _waveCount++;
        WaveText.text = _waveCount.ToString();
        _activeSwarm = Instantiate(Swarm, transform);
        _activeSwarm.GetComponent<SwarmController>().StartSwarm(Player);
    }

    public SwarmController GetActiveSwarm() {
        return _activeSwarm.GetComponent<SwarmController>();
    }
}
  