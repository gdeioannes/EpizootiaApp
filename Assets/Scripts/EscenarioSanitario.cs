using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscenarioSanitario : MonoBehaviour {

	public GameObject rollBtn;
	public GameObject rerollBtn;
	private int maxInfluCardCount;
	private int maxEventCadrdCount=1;
	private int maxGobCardCount=1;
	public int cardCount;
	public Text rollTxt;
	public Text rollInfo;
	private List<EventCard> eventCards;
	private List<GobCard> gobCards;
	private List<FluCard> fluCards;
	private bool endGameFlag=false;


	void OnEnable(){
		Debug.Log("Flu Panel Enable");
		maxInfluCardCount=GameDataManager._instance.gameData.fluCardNum;
		changeInfoText();
	}

	// Use this for initialization
	public void Start(){
		setFlueCards();
		setEventCards();
		setGobCards();
		maxInfluCardCount=GameDataManager._instance.gameData.fluCardNum;
		changeInfoText();
	}

	private void setFlueCards(){
		fluCards=new List<FluCard>(GameDataManager._instance.gameData.fluCards);
	}

	private void setEventCards(){
		eventCards=new List<EventCard>(GameDataManager._instance.gameData.eventCards);
	}

	private void setGobCards(){
		gobCards=new List<GobCard>(GameDataManager._instance.gameData.gobCards);
	}

	private void changeInfoText(){
		rollInfo.text="Cartas Influenza: "+(maxInfluCardCount)+"\n";
		rollInfo.text+="Cartas Evento: "+maxEventCadrdCount+"\n";
		rollInfo.text+="Cartas Gobierno: "+maxGobCardCount;
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
		if(cardCount<maxInfluCardCount){

			if(fluCards.Count==0){
				setFlueCards();
				Debug.Log("Rellenar cartas de Flu");
			}
			if(fluCards.Count==0){
				setFlueCards();
			}
			FluCard fluCard=fluCards[Random.Range(0,fluCards.Count)];
			fluCards.Remove(fluCard);
			Debug.Log(fluCards.Count);
			int numRoll=fluCard.rollNum;


			rollInfo+=fluCard.description+"\n";

			for(int roll=0;roll<numRoll;roll++){
				int strength=Random.Range(1,3);
				string column=getComlumLetter();
				string row=""+Random.Range(1,8);


				if(fluCard.cardType=="INFLUENZA"){
					rollInfo+="X ";
				}else if(fluCard.cardType=="SOSPECHA"){
					rollInfo+="? ";
				}else{
					rollInfo+=getTypeOfTrow(strength)+" ";
				}

				rollInfo+=column+" "+row;
				if(roll!=numRoll-1){
					rollInfo+="\n";
				}
			}
				
		}else if(cardCount<maxInfluCardCount+1){
			
			//Carta Evento
			if(eventCards.Count==0){
				setEventCards();
				Debug.Log("Rellenar cartas de event");
			}
			EventCard pickEventCard=eventCards[Random.Range(0,eventCards.Count)];
			rollInfo=pickEventCard.description;
			eventCards.Remove(pickEventCard);

		}else if(cardCount<maxInfluCardCount+2){
			
			//Carta Gobierno
			if(gobCards.Count==0){
				setGobCards();
				Debug.Log("Rellenar cartas de gob");
			}
			GobCard pickGobCard=gobCards[Random.Range(0,gobCards.Count)];
			rollInfo=pickGobCard.description;
			gobCards.Remove(pickGobCard);

		}else if(cardCount<maxInfluCardCount+3){
			
			rollInfo="FIN CICLO\n"+UIManager._instance.loopNum;

		}else if(GameDataManager._instance.gameData.cicleNumFinish==UIManager._instance.loopNum && !endGameFlag){
			rollInfo="FIN JUEGO";
			endGameFlag=true;
		}else{
			changeInfoText();
			reset();
			UIManager._instance.openLoopPanel();
			UIManager._instance.loopSum();
		}
		rollTxt.text=rollInfo;
	}

	private void reset(){
		maxInfluCardCount=GameDataManager._instance.gameData.fluCardNum;
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

	private string getComlumLetter(){
		string letters= "ABCDEFGH";
		return ""+letters[Random.Range(0,letters.Length)];
	}



}
