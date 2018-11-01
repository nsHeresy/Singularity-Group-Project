using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSystem : MonoBehaviour
{
    public GameObject RocketPrefab;
    public GameObject ImpactEffect;
    public AudioClip ImpactNoise;

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
    }

    private void Update()
    {
        Targetable.TargetLock();
        _timer += Time.deltaTime;
        _rocketTimer += Time.deltaTime;
        if (Input.GetButton("Fire1") && _timer >= _timeBetweenShots && !PauseController.IsGamePaused)
        {
            Shoot();
        }

        if (Input.GetButton("Fire2") && _rocketTimer >= _timeBetweenRockets && !PauseController.IsGamePaused)
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

        _gunLight.enabled = true;
        _gunLine.enabled = true;

        _gunAudio.Play();

        _gunLine.SetPosition(0, transform.position);

        var dist = Vector2.Distance(Targetable.ClosestTarget.targetLock.transform.position, Input.mousePosition);
        
        if (dist < 50)
        {
            Targetable.ClosestTarget.Damage(Damage);

        }
    }

    public void ShootRocket() {
        _rocketTimer = 0f;
        GameObject rocket = Instantiate(RocketPrefab, transform.position, transform.rotation);
        rocket.GetComponent<GuidedRocket>().target = Targetable.ClosestTarget.gameObject;
    }

    public void DisableEffects()
    {
        _gunLight.enabled = false;
        _gunLine.enabled = false;
        _gunLine.SetPosition(1, transform.position + transform.forward * Range);
    }
}