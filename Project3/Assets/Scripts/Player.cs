using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float CurHealth = 100;
    public float MaxHealth = 100;

    public float HealFactor = 2;

	public static Vector3 PlayerPosition;

	public Image HealthBar;
	
	private void Update ()
	{
		PlayerPosition = transform.position;
		HealthBar.fillAmount = CurHealth / MaxHealth;
        RegenHealth();
	}

    void RegenHealth() {
        CurHealth += Time.deltaTime * HealFactor;
        if (CurHealth > MaxHealth)
            CurHealth = MaxHealth;
    }
	
}
