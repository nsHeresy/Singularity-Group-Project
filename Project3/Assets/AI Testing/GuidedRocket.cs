using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedRocket : MonoBehaviour {

    public GameObject target;
    Rigidbody body;

    public ParticleSystem explodeParticle;
    private ParticleSystem explosion;

    //visual components
    

    //balancing fields
    public float speed = 100f;     //speed of rocket
    private float timeout = 5;      //seconds before rocket explodes automatically
    private float explodeRadius = 5;    //radius of explosion
    private float explodeDamage = 50;   //damage of explosion

    private bool exploding = false;


    private void Start() {
        StartCoroutine("TimeOut");
        body = GetComponent<Rigidbody>();
        body.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision) {
        StartCoroutine("Explode");
    }

    void FixedUpdate () {

        if (exploding) {
            body.velocity = transform.forward.normalized * 0;
            return;
        }
        
        if (target != null) {

            transform.LookAt(target.transform);
        }
        body.AddForce(transform.forward * speed);
    }

    IEnumerator Explode() {

        exploding = true;

        Destroy(GetComponent<Light>());

        //deal damage, not to player
        var enemiesInRange = Physics.OverlapSphere(transform.position, explodeRadius, 9);
        foreach (Collider enemy in enemiesInRange) {
            Targetable enemyTarget = enemy.gameObject.GetComponent<Targetable>();
            if (enemyTarget != null) {
                enemyTarget.Damage(explodeDamage);
            }
        }

        //destroy the rocket
        explosion = Instantiate(explodeParticle, transform.position, Quaternion.identity);
        explosion.transform.parent = transform;
        
        float totalDuration = explosion.main.duration;
        yield return new WaitForSeconds(totalDuration);


        explosion.Stop();
        DestroyImmediate(explosion);
        explosion = null;

        Destroy(gameObject);

        yield return null;
    }

    IEnumerator TimeOut() {
        yield return new WaitForSeconds(timeout);
        StartCoroutine("Explode");
    }
}
