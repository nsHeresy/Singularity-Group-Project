using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Targetable : MonoBehaviour {

    public float Health;

    public ParticleSystem Explosion; 
    public AudioClip ExplosionNoise;
    
    public GameObject TargetPrefab;
    public GameObject TargetLockPrefab;
    public int TargetRangeFromPlayer = 250;
    private Image _targetBox;
    private static Image _targetLock;

    private static bool Once = true;



    private void Start()
    {
        _targetBox = Instantiate(TargetPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        if (Once)
        {
            _targetLock = Instantiate(TargetLockPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            _targetLock.enabled = false;
            Once = false;
        }
        _targetBox.enabled = false;
    }

    private void Update()
    {
        if (IsDead()) {
            StartCoroutine("Death");
            return;
        }
        Target();
        TargetLock();
    }

    public void TargetLock()
    {
        if (Vector3.Distance(transform.position, Player.PlayerPosition) > TargetRangeFromPlayer) return;
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        _targetLock.enabled = false;
        if (!(pos.z > 0) || IsDead()) return;
        var posDistance = Vector2.Distance(pos, Input.mousePosition);
        if (posDistance > 100) return;
        var currentTargetLockDistance = Vector2.Distance(_targetLock.transform.position, Input.mousePosition);
        if (!(posDistance < currentTargetLockDistance)) return;
        _targetBox.transform.position = pos;
        _targetLock.enabled = true;
    }

    public void Target()
    {
        _targetBox.enabled = false;
        if (Vector3.Distance(transform.position, Player.PlayerPosition) > TargetRangeFromPlayer) return;
        if (!(Camera.main.WorldToScreenPoint(transform.position).z > 0)) return;
        if (IsDead()) return;
        _targetBox.enabled = true;
        _targetBox.transform.position = Camera.main.WorldToScreenPoint(transform.position);
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
        //if (_targetBox != null) _targetBox.enabled = false;
        
        //playDeathAnimation();
        _targetBox.enabled = false;
        Destroy(gameObject);
        yield return null;
    }
    
    public bool IsDead()
    {
        
        return Health <= 0;
    }

//    void playDeathAnimation() {
//        GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
//        AudioSource.PlayClipAtPoint(explNoise, transform.position,1f);
//    }
}
