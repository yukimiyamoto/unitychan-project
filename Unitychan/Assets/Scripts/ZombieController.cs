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
		animator.SetTrigger("Walk");
	}
	
	// Update is called once per frame
	void Update () 
	{
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

			if(zombie.transform.position.x-other.gameObject.transform.position.x < 1.0f)
			{
				animator.SetTrigger("Attak");

				if(AnimSt.normalizedTime<1.0f)
				{
					animator.SetTrigger("Walk");
				}
			}
		}
	}
}
