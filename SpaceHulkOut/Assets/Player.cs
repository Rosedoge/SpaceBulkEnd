using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player : MonoBehaviour {
	[SerializeField] GameObject Gun;
	public GameObject Gun2;
	[SerializeField] GameObject GunEnd;
	public GameObject GunEnd2;
	[SerializeField] GameObject Casing;
	[SerializeField] GameObject Flash;
	public GameObject BulletPrefab;
	public GameObject Bullet2;
	public GameObject PlayerCam;
	public GameObject Player4Nav;
	public GameObject Loc2,Loc3, Loc4;
	public GameObject Flamethrower;

	public GameObject Controller;

	public bool _____ ;

	public AudioClip GunSound;
	public AudioClip Flame;

	public bool EndOfGame = false;
	public GameObject Text;
	public bool Spawnable = true;
	public AudioClip[] Voices;
	Transform closestEnemy;
	int GunNum = 0; 
	MeshRenderer[] FlashKids;
	MeshRenderer[] GunParts;
	MeshRenderer[] GunParts2;
	GameObject casingClone;// = Casing.gameObject;
	GameObject GrenadeClone;

	float timer;

	void Start () {
		casingClone = Casing.gameObject;
		FlashKids = Flash.gameObject.GetComponentsInChildren <MeshRenderer>();
		//FlashOff ();
		//MoveOn(4);
	}

	void Awake () {
		casingClone = Casing.gameObject;
		FlashKids = Flash.gameObject.GetComponentsInChildren <MeshRenderer>();
		//FlashOff ();
		//GunParts = new List<MeshRenderer>();
		GunParts = Gun.GetComponentsInChildren <MeshRenderer>();
		GunParts2 = Gun2.GetComponentsInChildren <MeshRenderer>();
		//Player4Nav.gameObject.GetComponent<NavMeshAgent> ().destination = Loc3.gameObject.transform.position;

		foreach (MeshRenderer r in GunParts2) { // makes gun invisible lol
			r.enabled = false;

		}

	}


	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Location") {
			//Debug.Log ("Trigger!");
//			this.gameObject.GetComponent<HudController> ().WarningOn();
			Spawnable = true;
		}

		if (col.gameObject.name == "Loc4") {

			EndOfGame = true;
			Text.gameObject.GetComponent<ClockScript> ().vision ();
			Text.gameObject.GetComponent<ClockScript> ().activate = true;
		}


	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Location") {
			Spawnable = false;
//			this.gameObject.GetComponent<HudController> ().WarningOff();

		}


	}

	void Update ()
	{

		Debug.Log ("CAN ENEMIES SPAWN? " + Spawnable);
//		if (GunNum == 2) {
//
//
//		}
//


		if (GunNum == 1) {
			if (Input.GetButton ("Fire1")) {
				Flamethrower.gameObject.GetComponent<ParticleSystem> ().Play ();
				Flamethrower.gameObject.GetComponent<ParticleSystem> ().loop = true;
				//Gun.gameObject.GetComponent<AudioSource> ().Play ();

			} else if (Input.GetButtonUp ("Fire1")) {
				Flamethrower.gameObject.GetComponent<ParticleSystem> ().loop = false;
			}
		} else if (GunNum == 0) {
			if (Input.GetButton ("Fire1")) {
				if (Time.time - timer > 0.2f) {
					Gun.gameObject.GetComponent<Animator> ().SetTrigger ("Shooting");
					Gun.gameObject.GetComponent<Animator> ().ResetTrigger ("NotShooting");
					EjectCasing ();
					timer = Time.time;
				}
			}
			if (Input.GetKeyUp (KeyCode.Mouse0)) {
				//print ("space key was released");
				Gun.gameObject.GetComponent<Animator> ().SetTrigger ("NotShooting");
				Gun.gameObject.GetComponent<Animator> ().ResetTrigger ("Shooting");
				FlashOff ();
			}


		} else if (GunNum == 2) {
			

			Gun.gameObject.GetComponent<Animator> ().enabled = false;

			if (Input.GetKeyDown (KeyCode.Mouse0)) { //shoots just once on click
				//this.gameObject.GetComponent<AudioSource> ().Play ();
				GameObject cas2 = (GameObject)Instantiate (Bullet2, GunEnd2.gameObject.transform.position, GunEnd2.gameObject.transform.rotation);
				cas2.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
				cas2.gameObject.GetComponent<SphereCollider> ().enabled = true;
				Vector3 point = Camera.main.transform.position + Camera.main.transform.forward * 10;
				Vector3 dir = (point - GunEnd2.gameObject.transform.position).normalized;
				cas2.gameObject.GetComponent<Rigidbody> ().AddForce (dir * 1000);

			}

		}
	}


	public void MoveOn(int Location){
		if (Location == 1) {
			Spawnable = false;
			Player4Nav.gameObject.GetComponent<NavMeshAgent> ().destination = Loc2.gameObject.transform.position;
			GunNum = 1;
			Gun.gameObject.GetComponent<AudioSource> ().clip = Flame;
		}
		if (Location == 2) {
			Flamethrower.gameObject.GetComponent<ParticleSystem> ().loop = false;
			Flamethrower.gameObject.GetComponent<ParticleSystem> ().Stop ();
			foreach (MeshRenderer r in GunParts) { // makes gun invisible lol
				r.enabled = false;
			}
			foreach (MeshRenderer r in GunParts2) { // makes gun invisible lol
				r.enabled = true;

			}
//			Player4Nav.gameObject.GetComponent<NavMeshAgent> ().destination = Loc3.gameObject.transform.position;
			GunNum = 2;
//			this.gameObject.GetComponent<AudioSource> ().clip = GunSound;
		}
		if (Location == 3) {
			
			//will still use Grenades
			Player4Nav.gameObject.GetComponent<NavMeshAgent> ().destination = Loc3.gameObject.transform.position;
			//GunNum = 0;
			//Gun.gameObject.GetComponent<AudioSource> ().clip = GunSound;
		}

		if (Location == 4) {

			//will still use Grenades
			Player4Nav.gameObject.GetComponent<NavMeshAgent> ().destination = Loc4.gameObject.transform.position;
			//GunNum = 0;
			//Gun.gameObject.GetComponent<AudioSource> ().clip = GunSound;
		}
		Debug.Log ("Location " + Location + "    Gun Num " + GunNum);

	}

	/// <summary>
	/// Ejects the casing.
	/// Because we can't animate well
	/// Create a new gameobject with the same transform as casing, remove the  constraints on the original one, addforce, wait, delete, maybe not delete
	/// </summary>

	public void FlashOn(){
//		foreach(MeshRenderer mesh in FlashKids){
//			mesh.enabled = true;
//
//		}

	}
	public void FlashOff(){
//		foreach(MeshRenderer mesh in FlashKids){
//			mesh.enabled = false;;
//
//		}
//
	}
	public void EjectCasing(){
		if (GunNum == 0) {
			Gun.gameObject.GetComponent<AudioSource> ().Play ();
			GameObject cas2 = (GameObject)Instantiate (BulletPrefab, GunEnd.gameObject.transform.position, GunEnd.gameObject.transform.rotation);
			GameObject cas = (GameObject)Instantiate (casingClone, Casing.gameObject.transform.position, Casing.gameObject.transform.rotation);
			cas.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			cas.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;

			cas.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (new Vector3 (Random.Range (50.6f, 100), Random.Range (-10, 10), Random.Range (-6, 2)));
			Vector3 point = Camera.main.transform.position + Camera.main.transform.forward * 10;
			Vector3 dir = (point - GunEnd.gameObject.transform.position).normalized;
			cas2.gameObject.GetComponent<Rigidbody> ().AddForce (dir * 1000);
		}
	}
}
	 //Use this for initialization


