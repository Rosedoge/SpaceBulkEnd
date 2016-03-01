using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class ClockScript : MonoBehaviour
{
	float timeLeft = 120.0f;

	public Text text;
	public bool activate = false;

	public void vision(){
		text.enabled = true;


	}
	void Update()
	{
		if (activate) {
			timeLeft -= Time.deltaTime;
			text.text = "Time Left:" + Mathf.Round (timeLeft);
			if (timeLeft < 0) {
				SceneManager.LoadScene (2);
			}
		}
	}
}