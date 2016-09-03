using UnityEngine;
using System.Collections;

public class AppleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Events.eventBus ().Subscribe<AppleEaten> ((m) => {
			Debug.Log("event received!");
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
