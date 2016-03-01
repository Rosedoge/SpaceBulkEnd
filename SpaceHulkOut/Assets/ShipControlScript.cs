using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ShipControlScript : MonoBehaviour {
	float timer;
	// Use this for initialization
	void Start () {
		timer = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.name != "omega_fighter") {
			this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x + 2, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
			//this.gameObject.transform.Rotate(0,Time.deltaTime*2,0);

			if (Time.time - timer > 30) {
				SceneManager.LoadScene (1);

			}
		} else {
			this.gameObject.transform.position = new Vector3 ((float)(this.gameObject.transform.position.x - 0.2), this.gameObject.transform.position.y, this.gameObject.transform.position.z);
			//this.gameObject.transform.Rotate(0,Time.deltaTime*2,0);

			if (Time.time - timer > 5) {
				Application.Quit ();

			}

		}
	}
}
