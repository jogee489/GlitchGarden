using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

public Camera myCamera;

	private GameObject defendersParent;

	// Use this for initialization
	void Start () {
		defendersParent = GameObject.Find("Defenders");
		if (!defendersParent) {
			defendersParent = new GameObject("Defenders");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		Vector2 rawPosition = caclulateWorldPoint();
		Vector2 worldPosition = snapToGrid(rawPosition);
		Quaternion zero = Quaternion.identity;
		GameObject defender = Button.selectedDefender;
		GameObject newDefender = Instantiate (defender, worldPosition, zero) as GameObject;
		newDefender.transform.parent = defendersParent.transform;
		
	}
	
	Vector2 snapToGrid (Vector2 rawWorldPosition) {
		float oldX = rawWorldPosition.x;
		float oldY = rawWorldPosition.y;
		
		float newX = Mathf.RoundToInt(oldX);
		float newY = Mathf.RoundToInt(oldY);
		
		return new Vector2(newX, newY);
	}
	
	Vector2 caclulateWorldPoint () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
		Vector2 worldPoint = myCamera.ScreenToWorldPoint(weirdTriplet);
		
		return worldPoint;
	}
}
