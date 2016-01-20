using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour 
{
	public float warkspeed;
	public float rotatespeed;
	public GameObject zombie;
	Animator animator;
	AnimatorStateInfo AnimSt;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		animator.SetTrigger("Walk");
		//ahead
		zombie.transform.Translate (Vector3.forward * warkspeed * Time.deltaTime);
	}

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag=="Player")
		{
			// LookAtplayer
			Quaternion LookAtPlayer=Quaternion.LookRotation(other.transform.position-transform.position);
			zombie.transform.rotation=Quaternion.Slerp(transform.rotation,LookAtPlayer,rotatespeed*Time.deltaTime);

			if(zombie.transform.position.x-other.gameObject.transform.position.x < 2.0f)
			{
				animator.SetTrigger("Attak");
			}
		}
	}
}
