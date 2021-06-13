using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof (Health))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances.")]
	public float seenEverySeconds;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool("isAttacking", false);
		}
	}
	
	public void SetSpeed (float speed) {
		currentSpeed = speed;
	}
	
	public void StrikeCurrentTarget (float damage) {
		//Debug.Log(name + " cause damage: " + damage);
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage(damage);
			}
		}
		
	}
	
	// Attack
	public void Attack (GameObject target) {
		currentTarget = target;
	}
}
