using UnityEngine;
using System.Collections;

public class FallScript : MonoBehaviour {

	public float speed;
	Vector3 pos;

	// Update is called once per frame
	void Update () {
		pos = transform.position;
		pos.y -= speed;
		transform.position = pos;
		if (pos.y <= 0.8)
			Destroy (this.gameObject);
	}
}
