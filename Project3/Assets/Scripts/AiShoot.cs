using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShoot : MonoBehaviour {
    private GameObject player;
    public float range;
    public float accuracy;

    
    private LineRenderer _gunLine;

    //utils
    private float _timer;
    private float _timeBetweenShots = 1f;
    private float _effectDisplayTime = .5f;

    private void Start()
    {
       player = GameObject.Find("Characters/Player");
       _timer = 0f;
    }

    private void Awake()
    {
        _gunLine = GetComponent<LineRenderer>();
    }


        // Update is called once per frame
        void LateUpdate () {
        _timer += Time.deltaTime;
        Vector3 target = Player.PlayerPosition;
        float distance = Vector3.Distance(target, transform.position);
        if(distance < range && _timer > _timeBetweenShots)
        {
            Shoot(target);
        }
        if (_timer >= _effectDisplayTime)
        {
            DisableEffects();
        }
    }

    private void Shoot(Vector3 target)
    {
        _gunLine.enabled = true;
        _timer = 0f;
        Vector3 direction = target - transform.position;
        direction.x += UnityEngine.Random.Range(accuracy, -accuracy);
        direction.y += UnityEngine.Random.Range(accuracy, -accuracy);
        direction.z += UnityEngine.Random.Range(accuracy, -accuracy);
        _gunLine.SetPosition(0, transform.position);
        _gunLine.SetPosition(1, target);

        RaycastHit hit;
        if(Physics.Raycast(transform.position, direction, out hit, range + 50))
        {
            Debug.DrawRay(transform.position, direction, Color.red, 0.3f);
            Debug.Log("hit");
            
            player.GetComponent<Player>().Damage(1);

        }
        else
        {
            _gunLine.SetPosition(1, direction * range);
            Debug.DrawRay(transform.position, direction, Color.red, 0.3f);
            Debug.Log("miss");
        }
    }
    public void DisableEffects()
    {
        _gunLine.enabled = false;
    }
}
