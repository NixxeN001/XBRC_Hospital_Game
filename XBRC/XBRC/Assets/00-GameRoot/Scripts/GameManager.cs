using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	static float _availableFunds;
	public static float availableFunds {get{ return _availableFunds; }}

	static float _bedPrice;
	public static float bedPrice { get { return _bedPrice; } }

	static float _upgradePrice;
	public static float upgradePrice { get { return _upgradePrice; } }

	static float _score;
	public static float score {get{return _score;}}

	static int _patientsTeated;
	public static int patientsTreated { get { return _patientsTeated; } }


	static bool _gameOver;
	public static bool gameOver { get { return _gameOver; } }

	GameObject UI;

	static float _effiecency;
	public static float effiecency { get { return _effiecency; } }
	public float EffiecencyModifier = 4;

	public GameObject[] bed;
	int count = 0;

	public static GameManager instance;

	public static event Action updateUI;
	public static event Action endGame;


	private void Awake()
	{
		instance = this;
		_bedPrice = 10000;
		_upgradePrice = 200000;
		_patientsTeated = 0;
		_score = 0;
		_effiecency = 10;
		_gameOver = false;
		_availableFunds = 0f;
	}


	//public void IncMoney(float money)
	//{
	//	Money += money;
	//	Score += money;
	//	treated++;
	//	UI.GetComponent<UI>().UpdateMoney(Money);
	//}
	
	//public void DecMoney(float money)
	//{
	//	Money -= money;
	//}

	public void BuyBed()
	{
		if (count <11)
		{
			if (_availableFunds>_bedPrice)
			{
				bed[count].transform.position += new Vector3(0, 2, 0);
				DecreaseFunds(_bedPrice);
				count++;
			}
		}		
	}

	public void UpgradeBed()
	{
		if (_availableFunds > (_upgradePrice))
		{
			DecreaseFunds(_upgradePrice);

			_effiecency += 4;

			if (_effiecency > 80)
			{
				_effiecency = 80;
				
			}

			_upgradePrice *= 1.1f;
		}
	}

	public void IncreaseFunds(float amount)
	{
		_availableFunds += amount;
		_score += amount;
		_patientsTeated++;
		updateUI?.Invoke();

	}

	public void DecreaseFunds(float amount)
	{
		_availableFunds -= amount;
		updateUI?.Invoke();

	}

	void EndGame()
    {
		Destroy(GameObject.Find("Door"));
		endGame?.Invoke();


	}

	// public statics//

	public static void STATIC_BUYBED()
    {
		instance.BuyBed();
    }
	
	public static void STATIC_UpgradeBed()
    {
		instance.UpgradeBed();
    }

	public static void STATIC_EndGame()
    {
		instance.EndGame();
    }

	public static void STATIC_IncreaseFunds(float amount)
    {
		instance.IncreaseFunds(amount);
    }
}
