using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedRocket : MonoBehaviour {

    public GameObject target;
    public Rigidbody body;
    public ParticleSystem explodeParticle;

    //visual components
    

    //balancing fields
    public float speed = 10f;     //speed of rocket
    private float timeout = 5;      //seconds before rocket explodes automatically
    private float explodeRadius = 5;    //radius of explosion
    private float explodeDamage = 50;   //damage of explosion
    private float explodeDuration = 2f; //time for explosion animation to run


    private void Start() {
        StartCoroutine("TimeOut");
        body = GetComponent<Rigidbody>();
        body.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision) {
        Explode();
    }

    void LateUpdate () {
        if (target != null) {

            transform.LookAt(target.transform);
        }
        //body.AddForce(transform.forward * speed);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    void Explode() {

        //play animation
        explodeParticle.Play();

        //deal damage, not to player
        var enemiesInRange = Physics.OverlapSphere(transform.position, explodeRadius, 9);
        foreach (Collider enemy in enemiesInRange) {
            Targetable enemyTarget = enemy.gameObject.GetComponent<Targetable>();
            if (enemyTarget != null) {
                enemyTarget.Damage(explodeDamage);
            }
        }

        //destroy the rocket
        Object.Destroy(explodeParticle, explodeDuration);
        Object.Destroy(gameObject);
    }

    IEnumerator TimeOut() {
        yield return new WaitForSeconds(timeout);
        Explode();
    }
}
