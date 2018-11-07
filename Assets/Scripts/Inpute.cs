using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inpute : MonoBehaviour {

	bool isSwiped;
	Vector2 lastTouch;
	float minSwipeDis;

	void Awake () {
		minSwipeDis = Screen.width / 100f;
		print (minSwipeDis);
	}

	public void Down () {
		isSwiped = false;
		lastTouch = Input.mousePosition;
	}

	public void Drag () {
		if (!isSwiped) {
			Vector2 touchPos = Input.mousePosition;

			if (Vector2.Distance (lastTouch, touchPos) > minSwipeDis) {
				Timer.o.enabled = true;
				Ball.o.rb.velocity = Vector2.zero;
				Ball.o.rb.AddForce ((touchPos - lastTouch).normalized * 500); 
				lastTouch = touchPos;
			}
			print ("swipedß" + (touchPos - lastTouch));
		}
		isSwiped = true;
	}
}
