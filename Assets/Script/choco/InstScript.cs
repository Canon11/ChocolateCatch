using UnityEngine;
using System.Collections;

public class InstScript : MonoBehaviour {

	public GameObject item_10, item_m20, item_30;
	public float timeSpan = 1.0f;

	private float x, y;
	private int itemNum;
	private GameObject item;

	// Use this for initialization
	void Start () {
		y = 16.0f;
		StartCoroutine (CreateItem ());
	}

	IEnumerator CreateItem() {
		while (true) {
			x = Random.Range(-10.3f, 10.3f);
			itemNum = Random.Range (0, 10);

			if (itemNum <= 5) item = item_10;
			else if (itemNum <= 7) item = item_m20;
			else item = item_30;

			Instantiate (item, new Vector2(x, y), Quaternion.identity);
			yield return new WaitForSeconds (timeSpan);
		}
	}
}
