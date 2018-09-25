using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour {
	
	public Camera cam;

    public GameObject ImpactEffect;
    public AudioClip ImpactNoise;
	
	//range of the weapon
	//used externally for targeting reticule
	public static int Range = 300;
	public int Damage = 10;

    //weapon vars
    private LineRenderer _gunLine;
    private AudioSource _gunAudio;
    private Light _gunLight;

    //utils
    private float _timer;
    private float _timeBetweenShots = 0.1f;
    private float _effectDisplayTime = 0.2f;

    private void Awake() {

        _gunLine = GetComponent<LineRenderer>();
        _gunAudio = GetComponent<AudioSource>();
        _gunLight = GetComponent<Light>();

    }

    void Update () {
        _timer += Time.deltaTime;

		if(Input.GetButton("Fire1") && _timer >= _timeBetweenShots && !PauseController.isGamePaused){
			Shoot();
		}

        if (_timer >= _timeBetweenShots * _effectDisplayTime) {
            DisableEffects();
        }
	}

    public void SwitchWeapons() 
    {
        //stub
    }

	private void OnGUI()
	{
		var hits = Physics.OverlapSphere(transform.position, Range, 11);
		foreach (var hit in hits)
		{
			var ai = hit.GetComponent(typeof(Targetable)) as Targetable;
			if (ai == null) continue;
			var pos = cam.WorldToScreenPoint(ai.transform.position);
			GUI.Box(new Rect(pos.x, pos.y, 20f, 20f), "hello");
		}
	}


	public void Shoot() {
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

	public void ApplyHit(RaycastHit hit, int damage) {
        Instantiate(ImpactEffect, hit.point, Quaternion.identity);
        AudioSource.PlayClipAtPoint(ImpactNoise, hit.point);
        var t = hit.collider.gameObject.GetComponent<Targetable>();
        if (t != null)
            t.Damage(damage);
	}

    public void DisableEffects() {
        _gunLight.enabled = false;
        _gunLine.enabled = false;
        _gunLine.SetPosition(1, transform.position + transform.forward * Range); 
    }
}
