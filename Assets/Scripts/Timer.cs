using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public int maxTime;
	private int totalTimeSg;
	public Text timerTxt;
	public GameObject playBtn;
	public bool timerStartFlag=false;
	private IEnumerator timerCorutine;
	public string mensajeFinal;

	// Use this for initialization
	void Start () {
		totalTimeSg=maxTime;
		timerCorutine = timerCountDown();
		changeText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnEnable(){
		if(timerStartFlag){
			StartCoroutine(timerCorutine);
		}else{
			changeText();
		}
	}

	public void startTimer(){
		if(!timerStartFlag){
			Debug.Log("Enter StartTime");
			StartCoroutine(timerCorutine);
			timerStartFlag=true;
		}else{
			timerStartFlag=false;
			StopCoroutine(timerCorutine);
		}
	}

	IEnumerator timerCountDown(){
		Debug.Log("Enter Timer");
		while(totalTimeSg>0){
			Debug.Log(totalTimeSg);
			changeText();
			totalTimeSg--;

			yield return new WaitForSeconds(1);

		}
		timerTxt.text=mensajeFinal;
		timerCorutine=timerCountDown();
		totalTimeSg=maxTime;
		timerStartFlag=false;
	}

	private void changeText(){
		//timerTxt.text=""+totalTimeSg;
		string cero="0";
		if(totalTimeSg%60<10){
			cero="0";
		}else if(totalTimeSg==0){
			cero="00";
		}else{
			cero="";
		}
		timerTxt.text=""+((totalTimeSg-(totalTimeSg%60))/60)+":"+cero+totalTimeSg%60;
		if(totalTimeSg<30){
			timerTxt.color=Color.red;
		}else{
			timerTxt.color=Color.white;
		}
		if(totalTimeSg<10 && timerStartFlag){
			SoundManager._instance.playBeep();
		}
	}

	public void reset(){
		totalTimeSg=maxTime;
		timerStartFlag=false;
		StopCoroutine(timerCorutine);
		changeText();
	}

	public void changeTime(int sg){
		
		if(totalTimeSg+sg>1){
			totalTimeSg+=sg;
		}else{
			totalTimeSg=0;
		}
		changeText();
	}


}
