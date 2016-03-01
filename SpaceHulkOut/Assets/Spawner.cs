using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject mainController;
	[SerializeField] GameObject Enemy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnEnemy(int loc){
		GameObject cas = (GameObject)Instantiate(Enemy, this.gameObject.transform.position, this.gameObject.transform.rotation);
		if (loc == 4) {
			cas.gameObject.GetComponent<NavMeshAgent> ().speed = 10;
		}
		cas.gameObject.GetComponent<EnemyScript> ().controller = mainController;
		mainController.gameObject.GetComponent<GameController> ().enemies.Add (cas.gameObject);


	}
}
