using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
	private Text scoreText;
	private static int score, highScore;

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text> ();
		score = 0;
		scoreText.text = "Score: 0";
	}

	//アイテムを取った時の得点加算
	public void chachItem(int i_score) {
		scoreText = GetComponent<Text> ();
		score += i_score;
		if (score < 0)
			score = 0;
		scoreText.text = "Score: " + score.ToString();
	}

	public static int getMyScore() {
		return score;
	}

	public static int getHighScore() {
		return highScore;
	}

	//ハイスコアを保存,変数highScoreを取得
	public void highScoreSet() {
		if (!PlayerPrefs.HasKey ("Init")) {
			SetKey ();
			highScore = score;
		} else {
			highScore = PlayerPrefs.GetInt ("HIGH_SCORE");
			if (score > highScore) {
				highScore = score;
				PlayerPrefs.SetInt ("HIGH_SCORE", score);
			}
		}
	}

	void SetKey() {
		PlayerPrefs.SetInt ("Init", 1);
		PlayerPrefs.SetInt ("HIGH_SCORE", score);
	}
}