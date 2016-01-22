using UnityEngine;
using System.Collections;

public class LoiteringErea : MonoBehaviour 
{

	public float warkspeed;

	void OnTriggerStay(Collider zombie)
	{
		//ahead
		zombie.transform.Translate (Vector3.forward * warkspeed * Time.deltaTime);
	}

	void OnTriggerExit(Collider enemy)
	{
		if (enemy.gameObject.tag == "zombie") 
		{
			enemy.transform.Rotate(0 , enemy.transform.rotation.y + (100 * Random.Range(-0.8f,-1.0f)) , 0);
		}
	}
}
