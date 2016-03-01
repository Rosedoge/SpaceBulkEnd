using UnityEngine;
using System.Collections;

public class AmmoRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate (0,0, 20 * Time.time);
	}
}
