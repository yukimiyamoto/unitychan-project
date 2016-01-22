using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour 
{
	//PlayerHP
	public GameObject[] PlayerLife;

	// Update is called once per frame
	public void UpdateLife (int life) 
	{
		//DisplayHP
		for (int lifeindex = 0; lifeindex<PlayerLife.Length; lifeindex++) 
		{
			if(lifeindex<life)
			{
				PlayerLife[lifeindex].SetActive(true);
			}
			else
			{
				PlayerLife[lifeindex].SetActive(false);
			}
		}
	}
}
