﻿using UnityEngine;
using System.Collections;
using UnityChan;

public class Damage : MonoBehaviour 
{
	public GameObject DamageErea;
	private UnityChanControlScriptWithRgidBody unitychancontroller;
	private PlayerHP lifecount;

	// Use this for initialization
	void Start () 
	{
		DamageErea = GetComponent<GameObject> ();
		unitychancontroller = GameObject.Find ("unitychan_dynamic_locomotion").GetComponent<UnityChanControlScriptWithRgidBody> ();
		lifecount = GameObject.Find ("Life").GetComponent<PlayerHP> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider player) 
	{
		if (player.gameObject.tag == "Player") 
		{
			//Damage
			unitychancontroller.playerHP--;
			lifecount.UpdateLife(unitychancontroller.playerHP);
		}
	}
}
