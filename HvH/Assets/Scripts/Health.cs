using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float maxHealth;
	float currentHealth;
	
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0)
		{
			Die ();
		}
	}
	public void DealDamage(float amt)
	{
		currentHealth -= amt;
	}
	
	void Die()
	{
		Destroy (this.gameObject);
	}
}
