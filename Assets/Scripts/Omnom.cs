using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Omnom : MonoBehaviour {

	[SerializeField]
	private Text caption;

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
			GetComponent<Rigidbody2D> ().velocity = speed.normalized * 4.0f;
		}
	}
}
