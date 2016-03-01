using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameController : MonoBehaviour {


	[SerializeField] GameObject[] Spawners;
	GameObject[] Smoke;
	public  GameObject Player;
	public List<GameObject> enemies;
	bool testTrigger = false;
	float timer;
	float Enemytimer;
	public int levelNum = 0, killed = 0;
	// Use this for initialization
	void Start () {
		Smoke = GameObject.FindGameObjectsWithTag ("Smoke");
		//Spawners = GameObject.FindGameObjectsWithTag ("Spawner");
		enemies = new List<GameObject>();
		enemies.Add (GameObject.FindGameObjectWithTag ("Enemy"));
	}

//	public Transform GetClosestEnemy(GameObject player)
//	{
//		Transform tMin = null;
//		float minDist = Mathf.Infinity;
//		Vector3 currentPos = player.gameObject.transform.position;
//		foreach (GameObject t in enemies)
//		{
//			float dist = Vector3.Distance(t.gameObject.transform.position, currentPos);
//			if (dist < minDist)
//			{
//				tMin = t.gameObject.transform;
//				minDist = dist;
//			}
//		}
//		return tMin; //closet enemy Transform it'll do
//	}

	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time - timer > 2f) {
			int rando = Random.Range (0, 3);
			Smoke [rando].gameObject.GetComponent<ParticleSystem> ().Play ();
			Smoke [rando].gameObject.GetComponent<AudioSource> ().Play ();
			timer = Time.time;
		}
		if (levelNum <= 3) {
			if (Time.time - Enemytimer > 4f) {
				Spawn ();
				Enemytimer = Time.time;

			}
		} else if(Player.GetComponent<Player>().EndOfGame){
			if (Time.time - Enemytimer > 1.2f) {
				Spawn ();
				Enemytimer = Time.time;
			}
		}
		//Debug.Log ("killed: " + killed);
		if (killed >= 2 && levelNum <=3 ) {
			killed = 0;
			Player.gameObject.GetComponent<Player> ().MoveOn (levelNum += 1);
			Debug.Log (levelNum + " IS LEVEL");

		}
	}

	public void Spawn(){
		if (Player.gameObject.GetComponent<Player> ().Spawnable == true) {
			if (levelNum == 0) {
				int rando = Random.Range (0, 3);
				//Debug.Log (rando + " is spawner");
				Spawners [rando].gameObject.GetComponent<Spawner> ().SpawnEnemy (levelNum);


			}
			if (levelNum == 1) {
				int rando = Random.Range (3, 6);
				//Debug.Log (rando + " is spawner");
				Spawners [rando].gameObject.GetComponent<Spawner> ().SpawnEnemy (levelNum);
		

			}
			if (levelNum == 2) {
				int rando = Random.Range (3, 6);
				Spawners [rando].gameObject.GetComponent<Spawner> ().SpawnEnemy (levelNum);


			}

			if (levelNum == 3) {
				int rando = Random.Range (6, 7);
				Spawners [rando].gameObject.GetComponent<Spawner> ().SpawnEnemy (levelNum);


			}
			if (levelNum == 4) {
				int rando = Random.Range (7, 10);
				Spawners [rando].gameObject.GetComponent<Spawner> ().SpawnEnemy (levelNum);


			}
		}
	}
}
