using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetable : MonoBehaviour {


    public GameObject entity;               //the physical model of this entity
    public float health;                    //how much health does it have

    //Animations and Particles
    public ParticleSystem explosion;        //explosion to trigger when this entity dies
    public AudioClip explNoise;             //sound to play when this entity dies


    public bool isDead = false;             //used to check conditions elsewhere in the program

    private void Update()
    {
        if (isDead) {
            StartCoroutine("Death");
        }
    }


    /// <summary>
    /// Damages the entity when they have a collision with another object.
    /// Damage is relative to the speed of the collision.
    /// </summary>
    /// <param name="collision"> data on the collision which has just happened</param>
    private void OnCollisionEnter(Collision collision) {
        float magnitude = GetComponent<Rigidbody>().velocity.magnitude;
        Debug.Log(magnitude);
        Damage(magnitude * 3);
        //GameObject.Instantiate(explosion, entity.transform.position, Quaternion.identity);
    }

    /// <summary>
    /// Damages the entity by a certain amount. If the entity is dead, starts the Death coroutine.
    /// </summary>
    /// <param name="amount">How much damage to take</param>
    public void Damage(float amount) {
        health -= amount;
        if (health <= 0) {
            StartCoroutine(Death());
        }
    }

    /// <summary>
    /// Coroutine called when entity dies. 
    /// Does not finish until the playDeathAnimation is complete
    /// Destroys the entity when it is complete
    /// </summary>
    /// <returns>Nothing</returns>
    IEnumerator Death() {

        isDead = true;
        //playDeathAnimation();
        Destroy(entity);
        yield return null;
    }

    /// <summary>
    /// Instantiates an explosion at the location of this entity, and plays the explosion sound at this location also. 
    /// 
    /// </summary>
    void playDeathAnimation() {
        GameObject.Instantiate(explosion, entity.transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(explNoise,entity.transform.position,1f);
    }
}
