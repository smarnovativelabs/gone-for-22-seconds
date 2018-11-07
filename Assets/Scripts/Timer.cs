using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour {

	public static float timeLeft = 22;
	public static Timer o;
	AudioSource audio;
	Text time;

	void Awake () {
		o = this;
		time = GetComponent <Text> ();
		audio = GetComponent <AudioSource> ();
	}
	
	void Update () {
		if (timeLeft > 0) {
			timeLeft -= Time.deltaTime;

			if (timeLeft < 0) {
				timeLeft = 0;
				UI.o.UI_Pause ();
				audio.enabled = false;
				AdMob.o.ShowVideo ();
				UI.o.PauseBtn.SetActive (false);
				PlayerPrefs.SetInt ("best", (int)Ball.o.transform.position.y);
			}

			time.text = timeLeft.ToString ("0");
		}
		if (timeLeft > 0 && timeLeft < 5 && !audio.isPlaying)
			audio.enabled = true;
	}
}
