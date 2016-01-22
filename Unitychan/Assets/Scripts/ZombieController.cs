using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour 
{
	public int zonbieHP;
	public float rotatespeed;
	public GameObject zombie;
	Animator animator;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator> ();
		animator.SetTrigger("walk");
	}
	
	// Update is called once per frame
	void Update () 
	{
		animator.SetTrigger("walk");

		if (zonbieHP < 0)
			Destroy (zombie);
	}

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag=="Player")
		{
			// LookAtplayer
			Quaternion LookAtPlayer=Quaternion.LookRotation(other.transform.position-transform.position);
			zombie.transform.rotation=Quaternion.Slerp(transform.rotation,LookAtPlayer,rotatespeed*Time.deltaTime);
		}
	}
}
