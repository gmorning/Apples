using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AppleManager : MonoBehaviour {

	[SerializeField]
	private GameObject applePrefab;

	private HashSet<GameObject> apples = new HashSet<GameObject>();

	// Use this for initialization
	void Start ()
	{
		Events.eventBus ().Subscribe<GameStarted> ((m) => {
			for (int i = 0; i < 5; i++) {
				var apple = Instantiate (applePrefab) as GameObject;
				apple.transform.position = Random.insideUnitCircle * 7.0f;
				apples.Add (apple);
			}
		});

		Events.eventBus ().Subscribe<AppleEaten> ((m) => {
			var apple = m.apple;
			apple.transform.position = Random.insideUnitCircle * 7.0f;
		});

		Events.eventBus ().Subscribe<TimeExpired> ((m) => {
			foreach(var apple in apples) {
				Destroy(apple);
			}
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
