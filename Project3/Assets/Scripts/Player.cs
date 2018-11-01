using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float CurHealth = 50;
    public float MaxHealth = 100;
	public float HealFactor = 2;
	
	public static Vector3 PlayerPosition;

	public static int CurrentScore;
	
	public Image HealthBar;
	public Text ScoreText;
	
	
	private void Update ()
	{
		PlayerPosition = transform.position;
		HealthBar.fillAmount = CurHealth / MaxHealth;
		ScoreText.text = CurrentScore.ToString();
        if (CurHealth <= 0) {
            Kill();
        }
        RegenHealth();
	}

    private void OnCollisionEnter(Collision collision)
    {
        var magnitude = GetComponent<Rigidbody>().velocity.magnitude;
        Damage(magnitude * 5);
    }

    private void Damage(float amount) {
        CurHealth -= amount;
    }

    private void RegenHealth() {
        CurHealth += Time.deltaTime * HealFactor;
        if (CurHealth > MaxHealth)
            CurHealth = MaxHealth;
    }

    private void Kill() {
        Debug.Log("Kill Me");
    }
	
}
