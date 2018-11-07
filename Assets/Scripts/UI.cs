using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

	[SerializeField] Text score;
	[SerializeField] GameObject PausePanel;

	public GameObject PauseBtn;
	public static UI o;

	void Awake () {
		o = this;
	}

	public void UI_Pause () {
		Time.timeScale = 0;
		PausePanel.SetActive (true);
		score.text = Ball.o.transform.position.y.ToString ("0");
//		StartCoroutine (FadeOutMusic ());
	}

	public void UI_Resume () {
		Time.timeScale = 1;
		PausePanel.SetActive (false);
		//		StartCoroutine (FadeOutMusic ());
	}
		
	public void UI_Load (string name) {
		Time.timeScale = 1;
		Timer.timeLeft = 22;
		SceneManager.LoadScene (name);	
	}
}
