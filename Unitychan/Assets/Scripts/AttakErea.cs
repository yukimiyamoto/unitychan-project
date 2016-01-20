using UnityEngine;
using System.Collections;

public class AttakErea : MonoBehaviour {

	Animator attakanim;

	// Use this for initialization
	void Start () 
	{
		attakanim = GetComponentInParent<Animator> ();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="Player")
		attakanim.SetTrigger("attak");
	}
}
