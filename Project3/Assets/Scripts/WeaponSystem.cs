using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSystem : MonoBehaviour
{
    public GameObject RocketPrefab;
    public GameObject ImpactEffect;
    public AudioClip ImpactNoise;

    public GameObject Targeter;
    public GameObject Target;

    //range of the weapon
    //used externally for targeting reticule
    private static int Range = 100;
    public int Damage = 10;

    //weapon vars
    private LineRenderer _gunLine;
    private AudioSource _gunAudio;
    private Light _gunLight;

    //utils
    private float _timer;
    private float _rocketTimer;
    private float _timeBetweenShots = 0.1f;
    private float _timeBetweenRockets = 2.0f;
    private float _effectDisplayTime = 0.2f;

    private void Awake()
    {
        _gunLine = GetComponent<LineRenderer>();
        _gunAudio = GetComponent<AudioSource>();
        _gunLight = GetComponent<Light>();
        //InvokeRepeating ("TargetLock", 1f, 0.00011f);
    }

    private void TargetLock()
    {
        Targetable.TargetLock();
    }
    
    private void Update()
    {
        Targetable.TargetLock();
        _timer += Time.deltaTime;
        _rocketTimer += Time.deltaTime;
        if (Input.GetButton("Fire1") && _timer >= _timeBetweenShots && !PauseController.isGamePaused)
        {
            Shoot();
        }

        if (Input.GetButton("Fire2") && _rocketTimer >= _timeBetweenRockets && !PauseController.isGamePaused)
        {
            ShootRocket();
        }

        if (_timer >= _timeBetweenShots * _effectDisplayTime)
        {
            DisableEffects();
        }
    }

    public void SwitchWeapons()
    {
        //stub
    }

    public void Shoot()
    {
        _timer = 0f;

        Ray shootRay = new Ray();
        RaycastHit hit = new RaycastHit();


        _gunLight.enabled = true;
        _gunLine.enabled = true;

        _gunAudio.Play();

        _gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        //https://docs.unity3d.com/ScriptReference/Physics.BoxCast.html
        //https://docs.unity3d.com/ScriptReference/Renderer-bounds.html
    }

    public void ShootRocket() {
        _rocketTimer = 0f;

        Debug.Log(transform.forward);


        GameObject rocket = Instantiate(RocketPrefab, transform.position, transform.rotation);
        rocket.GetComponent<GuidedRocket>().target = Target;
    }

    public void ApplyHit(RaycastHit hit, int damage)
    {
        Instantiate(ImpactEffect, hit.point, Quaternion.identity);
        AudioSource.PlayClipAtPoint(ImpactNoise, hit.point);
        var t = hit.collider.gameObject.GetComponent<Targetable>();
        if (t != null)
            t.Damage(damage);
    }

    public void DisableEffects()
    {
        _gunLight.enabled = false;
        _gunLine.enabled = false;
        _gunLine.SetPosition(1, transform.position + transform.forward * Range);
    }
}