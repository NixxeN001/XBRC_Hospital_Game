using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
	GameObject GM;
	public Text Currency;
	public Text TUpgradeCost;
	public Text TBedCost;
	public Text Score;
	public Text Treated;

	public Text FinalScore;
	public Text FinalTreated;

	public Button UpgradeButton;
	public Button ExitButton;
	public Button RestartButton;


	public float UpgradeCost = 200000;
	public float BedCost = 10000;

	private void Start()
	{
		GM = GameObject.Find("Game Manager");
		Currency.text = "$ = 0";


	}

	private void Update()
	{
		TUpgradeCost.text = "= $ "+UpgradeCost.ToString();
		TBedCost.text = "= $ " + BedCost.ToString();
		Currency.text = "$ = " + GM.GetComponent<Manager>().Money.ToString();
		Score.text = "Score = " + GM.GetComponent<Manager>().Score.ToString();
		Treated.text = "Treated = " + GM.GetComponent<Manager>().treated.ToString();
	}

	public void UpdateMoney(float money)
	{
		Currency.text = "$ = " + money.ToString();
	}

	public void BuyBed()
	{
		GM.GetComponent<Manager>().BuyBed();
	}

	public void UpgradeBed()
	{
		GM.GetComponent<Manager>().UpgradeEffiecency();

	}

	public void DisableUpgrade()
	{

		UpgradeButton.interactable = false;
	}

	public GameObject panel;

	public void DisplayScore()
	{
		panel.gameObject.SetActive(true);
		FinalScore.text = "Score = " + GM.GetComponent<Manager>().Score.ToString();
		FinalScore.text = "Patients Treated = " + GM.GetComponent<Manager>().treated.ToString();
	}

	public void Restart()
	{

		SceneManager.LoadScene("TestScene");
	}

	public void ExitGame()
	{

		Application.Quit();
	}



}
