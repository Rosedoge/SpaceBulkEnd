using UnityEngine;
using System.Collections;

public class GrenadeScript : MonoBehaviour {
	public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		//explode, yo
		if (col.gameObject.tag != "Gun") {
			//explooooode
			//Debug.Log("I hit enemy");
			GameObject cas2 = (GameObject)Instantiate (explosion, this.gameObject.transform.position, this.gameObject.transform.rotation);
			cas2.gameObject.GetComponent<ParticleSystem> ().Play ();
			Destroy (this.gameObject);

		}


	}
}
