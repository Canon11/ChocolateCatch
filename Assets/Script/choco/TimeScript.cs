using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

	private Text timeText;
	public int time = 5;

	GameObject ScoreText;
	ScoreScript scoreScript;

	// Use this for initialization
	void Start () {
		ScoreText = GameObject.Find("Score");
		scoreScript = ScoreText.GetComponent<ScoreScript> ();
		timeText = GetComponent<Text> ();
		timeText.text = "Time: " + time.ToString ();
		StartCoroutine (PlayTime ());
	}
	
	IEnumerator PlayTime() {
		while (true) {
			//時間が0に成るとハイスコアを保存しResultへ
			if (time == 0) {
				scoreScript.highScoreSet();
				Application.LoadLevel("Result");
			}

			yield return new WaitForSeconds (1.0f);
			time--;
			timeText.text = "Time: " + time.ToString ();
		}
	}
}
