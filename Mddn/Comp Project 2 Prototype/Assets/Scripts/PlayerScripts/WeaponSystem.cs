using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour {
	
	public GameObject ship;
	
	//range of the weapon
	//used externally for targeting reticule
	public static int range = 300;
	public int damage = 10;

	public int shotsToCooldown = 32;
	public int currentShots = 0;
	
	void Start () {
		//currentShots = 0;
	}
	
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			shoot();
		}
	}
	
	
	///////////
	//UTILITY//
	///////////
	
	public bool isObjectInRange() {
		//stub for hit/range detection - implement later
		return true;
	}
	
	
	public bool shoot() {
		//stub for shooting system - implement later
		if(currentShots <= shotsToCooldown){
			Debug.Log("Shooting");
			currentShots++;
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast(ship.transform.position, ship.transform.forward, out hit, range)){
				Debug.Log("Hit");
				applyHit(hit, damage);
				return true;
			}	
		}
		else {
			Debug.Log("Cooldown");
			return false;
		}
		return false;
	}

	public void applyHit(RaycastHit hit, int damage) {
		
	}
}
