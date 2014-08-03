using UnityEngine;
using System.Collections;

[AddComponentMenu("Character/Time Controller")]
public class TimeController : MonoBehaviour {

	private Vector3 inputVector = Vector3.zero;
	private Vector3 oldVector = Vector3.zero;
	private float clampedValue = 0.01f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Get the input vector from kayboard or analog stick
		oldVector = inputVector;
		inputVector.x = Input.GetAxisRaw("Horizontal");
		inputVector.z = Input.GetAxisRaw("Vertical");
		clampedValue = Mathf.Lerp(oldVector.magnitude,inputVector.magnitude,1);
		clampedValue = Mathf.Clamp(clampedValue,0.15f,1f);
		Time.timeScale = clampedValue;
	}
}
