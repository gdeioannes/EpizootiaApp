﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager _instance;

	public GameObject mainPanel;
	public GameObject loopPanel;
	public GameObject optionPanel;
	public Text loopTxt;
	public int loopNum=1;
	public GameObject timerAccionPanel;
	public GameObject timerInversionPanel;
	public GameObject timerInfluenzaPanel;

	// Use this for initialization

	void Start(){
		if(_instance==null){
			_instance=this;
		}
	}

	public void setPanelData(){
		timerAccionPanel.GetComponent<Timer>().maxTime=GameDataManager._instance.gameData.actionTimeSg;
		timerInversionPanel.GetComponent<Timer>().maxTime=GameDataManager._instance.gameData.investmentTimeSg;
	}

	public void openGame(){
		changeLoopText();
		setPanelData();
		closePanels();
		mainPanel.SetActive(true);
		timerAccionPanel.SetActive(true);
	}

	private void closePanels(){
		setPanelData();
		mainPanel.SetActive(false);
		loopPanel.SetActive(false);
		optionPanel.SetActive(false);
		closeAllLoopPanels();
	}

	public void closeAllLoopPanels(){
		timerAccionPanel.SetActive(false);
		timerInversionPanel.SetActive(false);
		timerInfluenzaPanel.SetActive(false);
	}

	public void openMainPanel(){
		closePanels();
		mainPanel.SetActive(true);
	}

	public void openLoopPanel(){
		closePanels();
		timerAccionPanel.SetActive(true);
		loopPanel.SetActive(true);
	}

	public void openOptionPanel(){
		closePanels();
		optionPanel.SetActive(true);
	}

	public void actionFase(){
		SoundManager._instance.playChiken();
		closeAllLoopPanels();
		timerAccionPanel.SetActive(true);
	}

	public void inversionFase(){
		SoundManager._instance.playMoney();
		closeAllLoopPanels();
		timerInversionPanel.SetActive(true);
	}

	public void escenarioSanitarionFase(){
		SoundManager._instance.playAlarm();
		closeAllLoopPanels();
		timerInfluenzaPanel.SetActive(true);
	}

	public void loopSum(){
		loopNum++;
		changeLoopText();
	}

	public void looprest(){
		if(loopNum>1){
			loopNum--;
			changeLoopText();
		}
	}

	private void changeLoopText(){
		loopTxt.text=""+loopNum;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
