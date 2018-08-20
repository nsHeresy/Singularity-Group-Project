using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetable : MonoBehaviour {


    public GameObject entity;
    public float health;

    //Animations and Particles
    public GameObject explosion;
    public Animation deathAnim;


    public bool isDead = false;


    private void OnCollisionEnter(Collision collision) {
        float magnitude = GetComponent<Rigidbody>().velocity.magnitude;
        Debug.Log(magnitude);
    }


    public void Damage(float amount) {
        health -= amount;
        if (health <= 0) {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death() {

        isDead = true;
        playDeathAnimation();
        Destroy(entity);
        yield return null;
    }

    void playDeathAnimation() {
        Debug.Log("It's dead, Jim");
        GameObject.Instantiate(explosion, entity.transform.position, Quaternion.identity);
        //Explosion, followed by phase out (Brackeys)
    }
}
