using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	public GameObject bullet;
	public GameObject gun;
	public AudioSource audio;
	public AudioClip shot;

	private Animator thisAnim;
	private int count = 0;

	// Use this for initialization
	void Start () {
		thisAnim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			GameObject go = (GameObject)Instantiate(bullet,gun.transform.position,gun.transform.rotation);
			count++;
			go.name = "Shell:" + count;
			thisAnim.SetBool("Fire",true);
			audio.PlayOneShot(shot);
		};
		audio.pitch = Time.timeScale;
	}
}
