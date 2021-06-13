using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed = 1f;
	public float damage = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		GameObject obj = collider.gameObject;
		
		// Return when not hitting attacker.
		if (!obj.GetComponent<Attacker>()) {
			return;
		}
		
		Health health = obj.GetComponent<Health>();
		if (health) {
			health.DealDamage(damage);
			Destroy(gameObject);
		}
	}
}
