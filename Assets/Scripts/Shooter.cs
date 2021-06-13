using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;
	
	// Use this for initialization
	void Start () {
		animator = GameObject.FindObjectOfType<Animator>();
		SetMyLaneSpawner();
		projectileParent = GameObject.Find("Projectiles");
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (IsAttackerAheadInLane()) {
			animator.SetBool("isAttacking", true);
		} else {
			animator.SetBool("isAttacking", false);
		}
	}
	
	void SetMyLaneSpawner() {
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.Log(name + " unable to find spawner in lane.");
	}
	
	private void Fire() {
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
		
	}
	
	private bool IsAttackerAheadInLane() {
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}
		return false;
	}
}
