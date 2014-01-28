using UnityEngine;
using System.Collections;

public class SpawnUnitButton : MonoBehaviour {

	public float maxEnergy;
	public float eRate;
	public float unitSpawnCost;
	public float spawnCD;
	float CD;
	float currentEnergy;


	UnitSpawner us;
	// Use this for initialization
	void Start () {
		currentEnergy = 0;
		us = GameObject.FindGameObjectWithTag ("Scripts").GetComponent<UnitSpawner> ();
		CD = spawnCD;
	}

	void OnGUI()
	{
		GUI.Label (new Rect (300, 150, 500, 500), "Energy: " + Mathf.CeilToInt(currentEnergy));
	}

	// Update is called once per frame
	void Update () {
		CD += Time.deltaTime;
		currentEnergy += Time.deltaTime * eRate;
		if(Input.GetMouseButtonDown(0) && guiTexture.HitTest(Input.mousePosition ) && currentEnergy >= unitSpawnCost && (CD >= spawnCD))		
		{
			CD = 0;
			currentEnergy -= unitSpawnCost;	
			us.spawnPlayerUnit();
			
		}
	}
}
