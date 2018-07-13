using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager _instance;

	public GameObject loadingPanel;
	public GameObject mainPanel;
	public GameObject loopPanel;
	public GameObject optionPanel;
	public GameObject exitPanel;
	public Text loopTxt;
	public int loopNum=1;
	public GameObject timerAccionPanel;
	public GameObject timerInversionPanel;
	public GameObject timerInfluenzaPanel;
	public GameObject buildScenarioPanel;
	public GameObject marketPayPanel;
	public GameObject endGamePanel;

	// Use this for initialization

	void Start(){
		
		if(_instance==null){
			_instance=this;
		}
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) {
			openExitPanel();
		}
	}



	public void exitApp(){
		Application.Quit();
	}

	public void setPanelData(){
		timerAccionPanel.GetComponent<Timer>().maxTime=GameDataManager._instance.gameData.actionTimeSg;
		timerInversionPanel.GetComponent<Timer>().maxTime=GameDataManager._instance.gameData.investmentTimeSg;
	}

	public void openGame(){
		loadingPanel.SetActive(false);
		changeLoopText();
		closePanels();
		mainPanel.SetActive(true);
		timerAccionPanel.SetActive(true);
		Debug.Log("OPEN GAME");
	}

	private void closePanels(){
		setPanelData();
		mainPanel.SetActive(false);
		loopPanel.SetActive(false);
		optionPanel.SetActive(false);
		exitPanel.SetActive(false);
		closeAllLoopPanels();
	}


	public void closeAllLoopPanels(){
		timerAccionPanel.SetActive(false);
		timerInversionPanel.SetActive(false);
		timerInfluenzaPanel.SetActive(false);
		buildScenarioPanel.SetActive(false);
		marketPayPanel.SetActive(false);
		endGamePanel.SetActive(false);
	}

	public void openExitPanel(){
		exitPanel.SetActive(true);
	}

	public void closeExitPanel(){
		exitPanel.SetActive(false);
	}

	public void openMainPanel(){
		closePanels();
		mainPanel.SetActive(true);
	}

	public void openLoadingPanel(){
		closePanels();
		loadingPanel.SetActive(true);
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

	public void openBuildScenarioPanel(){
		closeAllLoopPanels();
		buildScenarioPanel.SetActive(true);
	}

	public void openMarketPayPanel(){
		closeAllLoopPanels();
		marketPayPanel.SetActive(true);
	}

	public void openEndGamePanel(){
		closeAllLoopPanels();
		endGamePanel.SetActive(true);
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
		
}
