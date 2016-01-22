using UnityEngine;
using System.Collections;
using UnityChan;

public class DamageErea : MonoBehaviour 
{
	//damage
	public GameObject damageErea;
	private UnityChanControlScriptWithRgidBody unitychancontroller;
	//unitychan HP
	private PlayerHP lifecount;
	//attak animation
	private Animator attakanim;

	// Use this for initialization
	void Start () 
	{
		attakanim = GetComponentInParent<Animator> ();
		damageErea = GetComponent<GameObject> ();
		unitychancontroller = GameObject.Find ("unitychan_dynamic_locomotion").GetComponent<UnityChanControlScriptWithRgidBody> ();
		lifecount = GameObject.Find ("Life").GetComponent<PlayerHP> ();
	}
	
	void OnTriggerEnter(Collider other)
	{
		//
		if (other.gameObject.tag == "Player") 
		{
			//change animation
			attakanim.SetTrigger ("attak");
			//Damage
			unitychancontroller.playerHP--;
			lifecount.UpdateLife (unitychancontroller.playerHP);
		}
	}
}
