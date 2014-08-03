using UnityEngine;
using System.Collections;

[AddComponentMenu("Character/Enemy Controller")]
public class EnemyController : MonoBehaviour {

	private Transform thisTransform;
	public Transform Player;

	// Use this for initialization
	void Awake () {
		thisTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		thisTransform.LookAt(Player.position);
		thisTransform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
	}
}
