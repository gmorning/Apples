using UnityEngine;
using System.Collections;

public class Omnom : MonoBehaviour {

	private Vector3 speed;
	private Vector3 target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			target.z = 0;
			speed = (target - transform.position).normalized * 0.1f;
			speed.z = 0;
		}
			
		if ((transform.position - target).magnitude > speed.magnitude)
			transform.position += speed;
	}
}
