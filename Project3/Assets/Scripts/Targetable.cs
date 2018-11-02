using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Targetable : MonoBehaviour
{
    public float Health;

    public ParticleSystem ExplosionDeathEffect;
    public AudioClip ExplosionDeathNoise;

    public GameObject TargetPrefab;
    public GameObject TargetLockPrefab;
    public int TargetRangeFromPlayer = 250;
    public int ScoreOnDeath = 100;
    
    private Image _targetBox;
    public Image targetLock;

    private bool _dying = false;

    private static List<Targetable> _possibleTargetLocks = new List<Targetable>();
    public static Targetable ClosestTarget = null;

    private void Start()
    {
        _targetBox = Instantiate(TargetPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        targetLock = Instantiate(TargetLockPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        targetLock.enabled = false;
        _targetBox.enabled = false;
    }

    private void Update()
    {
        if (_dying) return;
        
        if (IsDead())
        {
            StartCoroutine("Death");
            return;
        }
        if (PauseController.IsGamePaused) return;
        Target();
        FindPossibleTargetLock();
    }

    private bool PreconditionTarget()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        if (Vector3.Distance(transform.position, Player.PlayerPosition) > TargetRangeFromPlayer) return false;
        return pos.z > 0 && !IsDead();
    }

    
    /// <summary>
    /// Finds the closest target to the mouse and target locks that target
    /// For shooting and missie systems  
    /// </summary>
    public static void TargetLock()
    {
        const float distance = 99999f;
        if (ClosestTarget != null) ClosestTarget.targetLock.enabled = false;
        foreach (var possibleTargetLock in _possibleTargetLocks)
        {
            if (possibleTargetLock == null) continue;
            var distToPlayer = Vector3.Distance(possibleTargetLock.transform.position, Player.PlayerPosition);
            if (distToPlayer < distance)
            {
                ClosestTarget = possibleTargetLock;
            }
        }

        if (ClosestTarget == null) return;
        var pos = Camera.main.WorldToScreenPoint(ClosestTarget.transform.position);
        if (pos.z < 0) return;

        ClosestTarget.targetLock.enabled = true;
        ClosestTarget.targetLock.transform.position = pos;
        _possibleTargetLocks = new List<Targetable>();
    }

    /// <summary>
    /// Gets targets close the mouse to find the closest to target lock
    /// </summary>
    public void FindPossibleTargetLock()
    {
        if (PreconditionTarget() == false) return;
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var mousePosDistance = Vector2.Distance(pos, Input.mousePosition);
        if (mousePosDistance > 50) return;
        _possibleTargetLocks.Add(this);
    }

    /// <summary>
    /// If close to player the object is set as target for target locking and drawing target
    /// </summary>
    public void Target()
    {
        _targetBox.enabled = false;
        if (PreconditionTarget() == false) return;
        _targetBox.enabled = true;
        _targetBox.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Stops targetables killing each other
        if (collision.gameObject.layer == gameObject.layer) return;
        
        Debug.Log(collision.gameObject.layer);
        Debug.Log(gameObject.layer);
        
        var magnitude = GetComponent<Rigidbody>().velocity.magnitude;
        Damage(magnitude * 3);
    }

    public void Damage(float amount)
    {
        Health -= amount;
        if (Health <= 0) StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        //Removes targets
        if (_targetBox != null) _targetBox.enabled = false;
        if (targetLock != null) targetLock.enabled = false;
        
        //Start dying process animation 
        _dying = true;
        var explosion = Instantiate(ExplosionDeathEffect, transform.position, Quaternion.identity);
        explosion.transform.parent = transform;
        AudioSource.PlayClipAtPoint(ExplosionDeathNoise, Player.PlayerPosition, 1f);

        var totalDuration = explosion.main.duration;
        yield return new WaitForSeconds(totalDuration);
        
        explosion.Stop();
        DestroyImmediate(explosion);
        
        explosion = null;
        
        Destroy(gameObject);
        
        //Ensure any targeting is removed
        if (_targetBox != null) _targetBox.enabled = false;
        if (targetLock != null) targetLock.enabled = false;
        
        Player.CurrentScore += ScoreOnDeath;

        yield return null;
    }

    public bool IsDead()
    {
        return Health <= 0;
    }

    
}