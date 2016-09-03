using UnityEngine;
using System.Collections;
using TinyMessenger;

public class AppleEater : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		DestroyObject (coll.gameObject);
		Events.eventBus ().Publish (new AppleEaten ());
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
