using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscenarioSanitario : MonoBehaviour {

	public GameObject rollBtn;
	public GameObject rerollBtn;
	private int maxInfluCardCount=3;
	private int maxEventCadrdCount=1;
	private int maxGobCadrdCount=1;
	public int cardCount;
	public Text rollTxt;
	public Text rollInfo;

	// Use this for initialization
	void Start () {
		changeInfoText();
	}

	private void changeInfoText(){
		rollInfo.text="Cartas Influenza: "+(maxInfluCardCount)+"\n";
		rollInfo.text+="Cartas Evento: "+maxEventCadrdCount+"\n";
		rollInfo.text+="Cartas Gobierno: "+maxGobCadrdCount;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void rollDices(){
		rollTxt.gameObject.SetActive(true);
		rollBtn.SetActive(false);
		rerollBtn.SetActive(true);
		roll();
		cardCount=0;
	}

	public void roll(){
		string rollInfo="";
		SoundManager._instance.playRollDice();
		cardCount++;
		Debug.Log("Max Count:"+maxInfluCardCount);
		Debug.Log("CardCount:"+cardCount);
		if(cardCount<maxInfluCardCount){

			float numRoll=Mathf.Floor(Random.Range(2,4));
			for(int roll=0;roll<numRoll;roll++){
				int strength=Random.Range(1,3);
				int column=Random.Range(1,8);
				int row=Random.Range(1,8);
				rollInfo+=getTypeOfTrow(strength)+" "+getComlumLetter(column)+" "+row;
				if(roll!=numRoll-1){
					rollInfo+="\n";
				}
			}
				
		}else if(cardCount<maxInfluCardCount+1){
			rollInfo="Influenza\n en los Humedales";

		}else if(cardCount<maxInfluCardCount+2){
			rollInfo=" \n Sospechas en las Granjas Aledañas y Humedales";
		}else if(cardCount<maxInfluCardCount+3){
			rollInfo="FIN CICLO\n"+UIManager._instance.loopNum;
		}else{
			//maxInfluCardCount++;
			changeInfoText();
			reset();
			UIManager._instance.openLoopPanel();
			UIManager._instance.loopSum();
		}
		rollTxt.text=rollInfo;
	}

	private void reset(){
		rollTxt.gameObject.SetActive(false);
		rollBtn.SetActive(true);
		rerollBtn.SetActive(false);
		cardCount=0;
	}

	private string getTypeOfTrow(int result){
		if(result==1){
			return "?";
		}else{
			return "X";
		}
	}

	private string getComlumLetter(int result){
		switch (result) {

		default:
			break;
		
		case 1:
			return "A";
			break;

		case 2:
			return "B";
			break;
	
		case 3:
			return "C";
			break;

		case 4:
			return "D";
			break;
		
		case 5:
			return "E";
			break;

		case 6:
			return "F";
			break;

		case 7:
			return "G";
			break;

		case 8:
			return "H";
			break;
		}
		return null;
	}



}
