using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Omnom : MonoBehaviour {

	[SerializeField]
	private Text caption;

	private int score;

	// Use this for initialization
	void Start () {
		Events.eventBus ().Subscribe<AppleEaten> ((m) => {
			caption.text = (++score).ToString();
		});
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			var target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 speed = target - transform.position;
			GetComponent<Rigidbody2D> ().velocity = speed.normalized * 4.0f;
		}
	}
}
