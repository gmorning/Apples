using UnityEngine;
using System.Collections;

public class AppleManager : MonoBehaviour {

	[SerializeField]
	private GameObject applePrefab;

	// Use this for initialization
	void Start () {
		Events.eventBus ().Subscribe<AppleEaten> ((m) => {
			var apple = Instantiate(applePrefab) as GameObject;
			apple.transform.position = Random.insideUnitCircle * 5.0f;
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
