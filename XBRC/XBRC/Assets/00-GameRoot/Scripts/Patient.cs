using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Patient : MonoBehaviour
{
	
	public Image playerhealth;

	public Animator p_anime;

	public bool treated = false;

	public float treatmentTime;
	public float deathTime;

	public float treatmentCost;

	public float maxTime = 40f;
	public float minTime = 20f;

	

	private void Start()
	{
		p_anime = GetComponent<Animator>();
		p_anime.SetBool("isWalking", true);
	
		treatmentTime = Random.Range(minTime, maxTime);
		treatmentCost = treatmentTime * 1000;
		deathTime = treatmentTime * 3;

		treatmentTime = treatmentTime - (treatmentTime * (GameManager.effiecency/100));
		FindObjectOfType<AudioManager>().PlaySound("NPC_VL1");
		
	}

	public bool Treated = false;

	private void Update()
	{
		float dist = Vector3.Distance(GameObject.Find("exit").transform.position, transform.position);

		if (dist <= 3)
		{
			Destroy(gameObject);
		}

		

		deathTime -= Time.deltaTime;

		if ((deathTime<= 0f)&&(!Treated))
		{
			GameManager.STATIC_EndGame();
		}

	}

	public void Pay()
	{
		GameManager.STATIC_IncreaseFunds(treatmentCost);
		
	}
}
