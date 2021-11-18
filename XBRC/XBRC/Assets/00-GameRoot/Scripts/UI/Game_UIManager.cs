using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_UIManager : UIManager
{

    bool _showGameUI = true;
    bool _showPauseScreen, _showSettingsMenu, _gameOver = false;

    [SerializeField]
    TextMeshProUGUI txtAvailableFunds, txtScore, txtAmountOfPatientsTreated, txtBuyBed, txtUpgradeBed, txtFinalScore, txtFinalAmountOfPatients;

    public override void SetUI()
    { /*
        _childPanels[0] : Pause menu
        _childPanels[1] : Settings menu

      */
        _childPanels[0].SetActive(_showGameUI); 
        _childPanels[1].SetActive(_showPauseScreen);
        _childPanels[2].SetActive(_showSettingsMenu);
        _childPanels[3].SetActive(_gameOver);
    }

    private void Start()
    {
        GameManager.updateUI += DisplayStats;
        GameManager.endGame += DisplayFinalStats;
        DisplayStats();
    }

    #region gameplay

    public void BuyBed()
    {
        GameManager.STATIC_BUYBED();
    }

    public void UpgradeBed()
    {
        GameManager.STATIC_UpgradeBed();
    }

    public void DisplayStats()
    {
        txtAvailableFunds.text = "R" + GameManager.availableFunds.ToString();
        txtScore.text = "Score : " + GameManager.score.ToString();
        txtAmountOfPatientsTreated.text = "Treated : " + GameManager.patientsTreated.ToString();
        txtBuyBed.text = "Buy Bed - " + GameManager.bedPrice.ToString();
        txtUpgradeBed.text = "Upgrade Bed - " + GameManager.upgradePrice.ToString();
    }
    public void DisplayFinalStats()
    {
        txtFinalScore.text = "Score :" + GameManager.score.ToString();
        txtFinalAmountOfPatients.text = "Treated : " + GameManager.patientsTreated.ToString();
        _gameOver = true;
        SetUI();
    }

    #endregion
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    public void Pause()
    {
        _showGameUI = false;
        _showSettingsMenu = false;
        _showPauseScreen = true;
        Time.timeScale = 0;
        SetUI();
    }
    public void Play()
    {
        _showGameUI = true;
        _showPauseScreen = false;
        Time.timeScale = 1;
        SetUI();
    }

    public void ShowSettingsMenu()
    {
        _showPauseScreen = false;
        _showSettingsMenu = true;
        SetUI();
    }

}
