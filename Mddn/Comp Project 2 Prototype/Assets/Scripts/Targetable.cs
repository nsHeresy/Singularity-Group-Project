using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetable : MonoBehaviour {


    public GameObject entity;
    public float health;
    public bool isDead = false;

    //Animations and Particles


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void damage(float amount) {
        health -= amount;
        if (health <= 0) {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death() {

        isDead = true;
        playDeathAnimation();
        GameObject.Destroy(entity);
        yield return null;
    }

    void playDeathAnimation() {
        Debug.Log("It's dead, Jim");
        //Explosion, followed by phase out (Brackeys)
    }
}
