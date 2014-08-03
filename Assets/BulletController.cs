using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	private Transform thisTrans;

	// Use this for initialization
	void Start () {
		thisTrans = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		thisTrans.Translate(Vector3.forward * Time.deltaTime * 25);
	}
}
