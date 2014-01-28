using UnityEngine;
using System.Collections;
using System;

public class UnitMovement : MonoBehaviour {

	public float movementSpeed;
	public float attackRange;
	public float attackSpeed;
	public float attackDamage;
	float attackCD;
	GameObject target;
	Animator anim;
	public float attackTime;
	float attackAnimCD;

	CharacterController cc;
	// Use this for initialization
	void Start () {
		attackCD = 0;
		cc = transform.GetComponent<CharacterController> ();
		anim = transform.GetComponent<Animator> ();
		//cc.detectCollisions = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		attackAnimCD -= Time.deltaTime;
		if (attackAnimCD <= 0)
		{
			anim.SetBool("Attacking", false);
		}
		if (target == null)
		{
			FindEnemy();
			cc.Move (Vector3.right * movementSpeed * Time.deltaTime);
			//transform.Translate(Vector3.Lerp (transform.position, transform.right, movementSpeed));
		}
		else
		{
			anim.SetBool("Attacking", true);
			attackCD += Time.deltaTime;
			if (attackCD >= attackSpeed)
			{
				AttackEnemy();

				attackCD = 0;
				attackAnimCD = attackTime;
			}
		}
	}

	void FindEnemy()
	{
		Collider[] hits = Physics.OverlapSphere (transform.position, attackRange);
		foreach (Collider hit in hits)
		{
			if (hit.gameObject.tag != transform.gameObject.tag)
			{
				Debug.Log (hit.gameObject.name);
				if (hit.transform.GetComponent<UnitHealth>() != null)
				{
					Debug.Log ("target set");
					target = hit.gameObject;
				}
				if (hit.transform.GetComponent<TowerHealth>() != null)
				{
					target = hit.gameObject;
				}
			}
		}
	}

	protected virtual void AttackEnemy()
	{
		try
		{
			if (target.tag != "Tower")
			{
				target.GetComponent<UnitHealth> ().DealDamage (attackDamage);
			}
			else 
			{
				target.GetComponent<TowerHealth>().DealDamage(attackDamage);
			}
		}

		catch (Exception e)
		{
			target = null;
		}

	}
}
