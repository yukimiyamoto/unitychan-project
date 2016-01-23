using UnityEngine;
using System.Collections;
using UnityChan;

public class DamageErea : MonoBehaviour 
{
	//damage
	public GameObject damageErea;
	//attakInterval
	private const float interval = 3.0f;

	private bool attakflag;
	private UnityChanControlScriptWithRgidBody unitychancontroller;
	//unitychan HP
	private PlayerHP lifecount;
	//attak animation
	private Animator attakanim;

	// Use this for initialization
	void Start () 
	{
		attakflag = true;
		attakanim = GetComponentInParent<Animator> ();
		damageErea = GetComponent<GameObject> ();
		unitychancontroller = GameObject.Find ("unitychan_dynamic_locomotion").GetComponent<UnityChanControlScriptWithRgidBody> ();
		lifecount = GameObject.Find ("Life").GetComponent<PlayerHP> ();
		lifecount.UpdateLife (unitychancontroller.playerHP);
	}

	IEnumerator attakInterval()
	{
		float counter = interval;

		while (counter > 0.0f) 
		{
			yield return new WaitForSeconds (1.0f);
			counter--;
		}
		attakflag = true;
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player" && attakflag) 
		{
			attakflag = !attakflag;
			//change animation
			attakanim.SetTrigger ("attak");
			//Damage
			unitychancontroller.playerHP--;
			lifecount.UpdateLife (unitychancontroller.playerHP);

			StartCoroutine(attakInterval());
		}
	}
}
