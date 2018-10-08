using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UI;


public class Targetable : MonoBehaviour {

    public float Health;

    public ParticleSystem Explosion; 
    public AudioClip ExplosionNoise;

    public GameObject TargetPrefab;
    private Image _targetBox;


    public bool IsDead = false;

    private void Start()
    {
        _targetBox = Instantiate(TargetPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        
    }

    private void Update()
    {
        _targetBox.enabled = false;
        if (IsDead) {
            StartCoroutine("Death");
            return;
        }

        if (!(Camera.main.WorldToScreenPoint(transform.position).z > 0)) return;
        _targetBox.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }

    public void Enable()
    {
        _targetBox.enabled = true;
    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.layer == gameObject.layer)
            return;
        var magnitude = GetComponent<Rigidbody>().velocity.magnitude;
        Damage(magnitude * 3);
        //GameObject.Instantiate(explosion, entity.transform.position, Quaternion.identity);
    }


    public void Damage(float amount) {
        Health -= amount;
        if (Health <= 0) StartCoroutine(Death());
    }

    private IEnumerator Death() {

        IsDead = true;
        //playDeathAnimation();
        
        Destroy(gameObject);
        yield return null;
    }

//    void playDeathAnimation() {
//        GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
//        AudioSource.PlayClipAtPoint(explNoise, transform.position,1f);
//    }
}
