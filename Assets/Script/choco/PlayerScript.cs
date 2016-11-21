using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private Animator animator;
	private int doJumpId, doRunId;
	private float s_rate = 1.0f;
	private bool facingRight = true;

	GameObject ScoreText;
	ScoreScript scoreScript;
	AudioSource audioSource;
	AudioClip audioClip;

	public float speed = 0.1f;
	public AudioClip clip1, clip2, clip3;


	AnimatorStateInfo stateInfo;
	Vector3 pos;

	// Use this for initialization
	void Start () {
		ScoreText = GameObject.Find("Score");
		scoreScript = ScoreText.GetComponent<ScoreScript> ();
		audioSource = GetComponent<AudioSource> ();
		animator = GetComponent<Animator> ();
		doJumpId = Animator.StringToHash ("doJump");
		doRunId = Animator.StringToHash ("doRun");
	}
	
	// Update is called once per frame
	void Update () {
		characterJump ();
		characterMove ();
	}

	void characterJump() {
		if (Input.GetKey (KeyCode.UpArrow))
			animator.SetBool (doJumpId, true);
		else
			animator.SetBool(doJumpId, false);
	}

	void characterMove() {
		float h = Input.GetAxis ("Horizontal");

		if ((facingRight && h < 0) || (!facingRight && h > 0)) {
			facingRight = (h > 0);
			transform.localScale = new Vector3((facingRight ? 0.2f : -0.2f), 0.2f, 0.2f);
		}

		if (h != 0) {
			pos = transform.position;
			pos.x += h * s_rate * speed;
			transform.position = pos;
			animator.SetBool(doRunId,true);
		} else {
			animator.SetBool (doRunId, false);
		}
	}

	//アイテムに衝突した時の挙動
	void OnCollisionEnter2D(Collision2D collision) {
		if (!collision.gameObject.CompareTag ("floor")) {
			if (collision.gameObject.CompareTag ("Item_10")) {
				audioClip = clip1;
				scoreScript.chachItem (10);
			} else if (collision.gameObject.CompareTag ("Item_m20")) {
				audioClip = clip2;
				scoreScript.chachItem (-20);
			} else if (collision.gameObject.CompareTag ("Item_30")) {
				audioClip = clip3;
				scoreScript.chachItem (30);
			}
			Destroy (collision.gameObject);
			audioSource.PlayOneShot (audioClip);
		}
	}
}
