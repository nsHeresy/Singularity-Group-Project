using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	public GameObject explo;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	
	
	void OnCollisionEnter(Collision col) {

        GameObject hitObject = col.gameObject;
        if (hitObject.GetComponent<Targetable>() != null)
            Debug.Log("It's a hit!");
            hitObject.GetComponent<Targetable>().Damage(1);
		GameObject.Instantiate(explo, col.contacts[0].point, Quaternion.identity);	
		Destroy(gameObject);
	}
	
	
}
