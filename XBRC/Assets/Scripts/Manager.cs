using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
	public float Money;
	public float Score = 0;
	public int treated = 0;

	GameObject UI;

	public float Effiecency = 10;
	public float EffiecencyModifier = 4;

	public GameObject[] bed;
	int count = 0;

	private void Start()
	{
		UI = GameObject.Find("Canvas");
	}


	public void IncMoney(float money)
	{
		Money += money;
		Score += money;
		treated++;
		UI.GetComponent<UI>().UpdateMoney(Money);
		//Debug.Log(Money);
	}
	
	public void DecMoney(float money)
	{
		Money -= money;
		//Debug.Log(Money);
	}

	public bool StopGame = false;

	private void Update()
	{

		if (StopGame)
		{
			Debug.Log("STOP GAME");
			Destroy(GameObject.Find("Door"));
			UI.GetComponent<UI>().DisplayScore();
		}


	}

	public void BuyBed()
	{
		if (count <11)
		{
			if (Money>UI.GetComponent<UI>().BedCost)
			{
				bed[count].transform.position += new Vector3(0, 2, 0);
				DecMoney(UI.GetComponent<UI>().BedCost);
				count++;
				UI.GetComponent<UI>().BedCost = (count + 1) * 10000;
			}
			
		}
		
	}

	public void UpgradeEffiecency()
	{
		if (Money > (UI.GetComponent<UI>().UpgradeCost))
		{
			DecMoney(UI.GetComponent<UI>().UpgradeCost);

			Effiecency += (4);
			//Debug.Log(EffiecencyModifier);

			if (Effiecency > 80)
			{
				Effiecency = 80;
				UI.GetComponent<UI>().DisableUpgrade();
			}

			UI.GetComponent<UI>().UpgradeCost += (UI.GetComponent<UI>().UpgradeCost) * 0.1f;
		}
	}
}
