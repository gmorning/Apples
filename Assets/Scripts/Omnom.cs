using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Omnom : MonoBehaviour {

	[SerializeField]
	private Text caption;

	[SerializeField]
	private float touchPower;

	private int score;

	enum State {
		IDLE,
		ACTIVE,
	};
	private State state = State.IDLE;


	// Use this for initialization
	void Start ()
	{
		Events.eventBus ().Subscribe<GameStarted> ((m) => {
			score = 0;
			caption.text = "";
			state = State.ACTIVE;
			transform.position = new Vector2(0,0);
//			transform.localRotation = Quaternion.identity;
			GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
			GetComponent<Rigidbody2D>().angularVelocity = 0;
			GetComponent<Rigidbody2D>().rotation = 0;
		});
		
		Events.eventBus ().Subscribe<AppleEaten> ((m) => {
			caption.text = (++score).ToString();
		});

		Events.eventBus ().Subscribe<TimeExpired> ((m) => {
			state = State.IDLE;
		});
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (state == State.ACTIVE && Input.GetMouseButtonDown (0)) {
			var target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 speed = target - transform.position;
//			GetComponent<Rigidbody2D> ().velocity = speed.normalized * 8.0f;
			GetComponent<Rigidbody2D> ().AddForce (speed.normalized * touchPower);
		}
	}
}
