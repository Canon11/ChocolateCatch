using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	GameObject bgm;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPlay() {
		bgm = GameObject.Find ("BGM");
		Destroy (bgm);
		Application.LoadLevel ("GamePlay");
	}

	public void OnHowTo() {
		Application.LoadLevel ("HowToPlay");
	}

	public void OnTitle() {
		Application.LoadLevel ("Title");
	}
}
