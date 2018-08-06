using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour {
	
	public GameObject ship;
	
	//range of the weapon
	//used externally for targeting reticule
	public static float range = 200;
	public int shotsToCooldown = 32;
	public int currentShots = 0;
	
	void Start () {
		//currentShots = 0;
	}
	
	void Update () {
		
	}
	
	void onMouseDown() {
		shoot();
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
		return true;
	}

	
	///////////
	//GETTERS//
	///////////
	
	public float getRange() {
		return range;
	}
}
