using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

	public float moveSpeed;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0,0));
	}
}
