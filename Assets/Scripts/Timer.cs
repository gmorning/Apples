using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	[SerializeField]
	private float gameDuration;
	private float timeLeft;

	// Use this for initialization
	void Start () {
		Events.eventBus ().Subscribe<GameStarted> ((m) => {
			timeLeft = gameDuration;
		});
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
