using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	[SerializeField] Text score;
	[SerializeField] TextMesh best;

	public Rigidbody2D rb;
	AudioSource audio;
//	Vector2 lastTouch;
//	float minSwipeDis;
	public static Ball o;

//	void OnGUI () {
//		GUILayout.Label (rb.velocity.magnitude + "");
//	}
	void Awake () {
		o = this;
//		minSwipeDis = Screen.width / 2000f;
//		print (minSwipeDis);
	}

	void Start () {
		rb = GetComponent <Rigidbody2D> ();
		audio = GetComponent <AudioSource> ();
		best.text = "Best " + PlayerPrefs.GetInt ("best", 0).ToString ();
		best.transform.position = new Vector3 (best.transform.position.x, PlayerPrefs.GetInt ("best", -1), best.transform.position.z);
	}
	
	void Update () {
//		if (Input.GetMouseButtonDown (0)) {
//			lastTouch = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//		}
//		if (Input.GetMouseButton (0)) {
//			Vector2 touchPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//
//			if (Vector2.Distance (lastTouch, touchPos) > minSwipeDis) {
//				Timer.o.enabled = true;
//				rb.velocity = Vector2.zero;
//				rb.AddForce ((touchPos - lastTouch).normalized * 300); 
//				lastTouch = touchPos;
//			}
//		}
		score.text = transform.position.y.ToString ("0");
	}

	void OnCollisionEnter2D(Collision2D coll) {
		audio.Play ();

	}
}
