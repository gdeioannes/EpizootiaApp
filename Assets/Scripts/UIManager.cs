using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager _instance;

	public GameObject mainPanel;
	public GameObject loopPanel;
	public Text loopTxt;
	public int loopNum=1;
	public GameObject timerAccionPanel;
	public GameObject timerInversionPanel;
	public GameObject timerInfluenzaPanel;

	// Use this for initialization
	void Start () {
		openGame();
		changeLoopText();
		if(_instance==null){
			_instance=this;
		}
	}

	private void openGame(){
		closePanels();
		mainPanel.SetActive(true);
		timerAccionPanel.SetActive(true);
	}

	private void closePanels(){
		mainPanel.SetActive(false);
		loopPanel.SetActive(false);
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
