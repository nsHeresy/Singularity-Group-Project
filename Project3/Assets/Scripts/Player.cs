using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public static Vector3 PlayerPosition;

	private void Start () {
		
	}
	
	private void Update ()
	{
		PlayerPosition = transform.position;

	}
	
}
