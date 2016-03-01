using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public GameObject controller;
	public GameObject Blood;
	[SerializeField] GameObject Player;
	int Health = 5;

	public AudioClip[] SpawnNoise;
	// Use this for initialization

//	private ParticleCollisionEvent[] collisionEvents = new ParticleCollisionEvent[16];
//	void OnParticleCollision(GameObject other) {
//		ParticleSystem particleSystem;
//		particleSystem = other.GetComponent<ParticleSystem>();
//		int safeLength = particleSystem.GetSafeCollisionEventSize();
//		if (collisionEvents.Length < safeLength)
//			collisionEvents = new ParticleCollisionEvent[safeLength];
//		int numCollisionEvents = particleSystem.GetCollisionEvents(gameObject, collisionEvents);
//		if (other.gameObject.tag == "Explode") {
//			Debug.Log ("AGH");
//
//		}
//		Health -= 1;
//		GameObject cas = (GameObject)Instantiate(Blood, other.gameObject.transform.position, other.gameObject.transform.rotation);
//
//
//	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Explode") {
			GameObject cas = (GameObject)Instantiate(Blood, col.gameObject.transform.position, col.gameObject.transform.rotation);
			//Destroy (this.gameObject);
			Health -= 10;
		}

	}
	void Start () {
		gameObject.GetComponent<NavMeshAgent> ().destination = controller.gameObject.GetComponent<GameController>().Player.transform.position;
		int rando = (int)Random.Range (0, 3);
		AudioClip player = SpawnNoise [rando];
		this.gameObject.GetComponent<AudioSource> ().clip = player;
		this.gameObject.GetComponent<AudioSource> ().Play ();
	}
	void OnParticleCollision(GameObject particle){


		//GetCollisionEvents(ParticleSystem ps, GameObject go, ParticleCollisionEvent[] collisionEvents);
		Health -= 1;
		GameObject cas = (GameObject)Instantiate(Blood, particle.gameObject.transform.position, particle.gameObject.transform.rotation);
		Debug.Log ("hit");
	}

	void OnCollisionEnter(Collision	col){
		if (col.gameObject.tag == "Bullet") {
		//	Debug.Log (Health);
			Health -= 1;
			GameObject cas = (GameObject)Instantiate(Blood, col.gameObject.transform.position, col.gameObject.transform.rotation);

			Destroy (col.gameObject);
		}
//		if (col.gameObject.tag == "Grenade") {
//			//	Debug.Log (Health);
//			Health -= 10;
//			GameObject cas = (GameObject)Instantiate(Blood, col.gameObject.transform.position, col.gameObject.transform.rotation);
//
//
//		}
	}

	// Update is called once per frame
	void Update () {

		if (Health <= 0) {
		//	Debug.Log ("Dies??");
			controller.gameObject.GetComponent<GameController> ().Spawn ();
			controller.gameObject.GetComponent<GameController> ().killed += 1;
			controller.gameObject.GetComponent<GameController> ().enemies.Remove (this.gameObject);
			gameObject.GetComponent<BoxCollider> ().enabled = false;
			Destroy (this.gameObject);

		}
	
	}
}



