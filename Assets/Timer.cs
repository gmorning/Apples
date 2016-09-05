using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private float timeLeft = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timeLeft > 0)
			timeLeft -= Time.deltaTime * 1.0f;
		else if (timeLeft < 0) {
			timeLeft = 0;
			Events.eventBus ().Publish (new TimeExpired ());
		}

		GetComponent<Text> ().text = Mathf.CeilToInt(timeLeft).ToString ();
	}
}
