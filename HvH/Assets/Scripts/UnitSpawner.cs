using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitSpawner : MonoBehaviour {

	List<GameObject> spawnLocsA = new List<GameObject> ();
	List<GameObject> spawnLocsB = new List<GameObject> ();
	public float spawnRate;
	public GameObject testDemon;
	public GameObject testAngel;
	public GameObject spawnloc1;
	public GameObject spawnloc2;
	public GameObject spawnloc3;
	public GameObject spawnloc4;
	public GameObject spawnloc5;
	public GameObject spawnloc6;
	Vector3 spawnLocation1;
	Vector3 spawnLocation2;
	Vector3 spawnLocation3;



	float spawnCD;

	// Use this for initialization
	void Start () {
		spawnCD = spawnRate;
		spawnLocsA.Add (spawnloc1);
		spawnLocsA.Add (spawnloc2);
		spawnLocsA.Add (spawnloc3);
		spawnLocsB.Add (spawnloc4);
		spawnLocsB.Add (spawnloc5);
		spawnLocsB.Add (spawnloc6);
	}
	
	// Update is called once per frame
	void Update () {
		spawnCD += Time.deltaTime;
		if (spawnCD >= spawnRate)
		{
			SpawnUnits(Random.Range(0,3), Random.Range (0,3));
			spawnCD = 0;
		}
	}

	void SpawnUnits(int a, int b)
	{
		//Instantiate (testAngel, spawnLocsA [a].transform.position, new Quaternion(0,1,0,0));
		Instantiate (testDemon, spawnLocsB [b].transform.position, new Quaternion(0,1,0,0));
	}

	public void spawnPlayerUnit()
	{
		Instantiate (testAngel, spawnLocsA [Random.Range(0,3)].transform.position, new Quaternion(0,0,0,0));
	}
}
