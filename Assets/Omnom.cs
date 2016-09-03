using UnityEngine;
using System.Collections;

public class Omnom : MonoBehaviour {

	private Vector3 speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			var target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			speed = (target - transform.position).normalized * 2.9f;
			GetComponent<Rigidbody2D> ().velocity = speed;
		}
	}
}
