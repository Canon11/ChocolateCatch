using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ResultScoreScript : MonoBehaviour {

	GameObject myScore, highScore;
	Text myScoreText, highScoreText;

	int myPoint, highPoint;

	// Use this for initialization
	void Start () {
		myScore = GameObject.Find ("score_text");
		myScoreText = myScore.GetComponent<Text> ();
		myPoint = ScoreScript.getMyScore ();
		myScoreText.text = "Your Score: " + myPoint.ToString ();

		highScore = GameObject.Find ("hscore_text");
		highScoreText = highScore.GetComponent<Text> ();
		highPoint = ScoreScript.getHighScore ();
		highScoreText.text = "High Score: " + highPoint.ToString ();
	}
}
