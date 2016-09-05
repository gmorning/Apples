using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour {

	[SerializeField]
	private Text scoreLabel;
	[SerializeField]
	private Text maxScoreLabel;
	private int score;

	// Use this for initialization
	void Start () 
	{
		Events.eventBus ().Subscribe<GameStarted> ((m) => {
			transform.localScale = new Vector3 (0, 0, 0);
			score = 0;
		});

		Events.eventBus ().Subscribe<TimeExpired> ((m) => {
			transform.localScale = new Vector3(1,1,1);

			int maxScore = PlayerPrefs.GetInt("max_score");
			maxScore = Mathf.Max(maxScore, score);
			PlayerPrefs.SetInt("max_score", maxScore);

			scoreLabel.text = "Score: " + score.ToString();
			maxScoreLabel.text = "Max: " + maxScore.ToString();
		});

		Events.eventBus ().Subscribe<AppleEaten> ((m) => {
			score++;
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startGame() {
		Events.eventBus ().Publish (new GameStarted ());
	}
}
