using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameDataManager : MonoBehaviour {

	public static GameDataManager _instance;
	public UIManager uiManager;
	public GameData gameData= new GameData();
	public InputField cicleNumInput;
	public InputField actionTimeInput;
	public InputField investmentTimeInput;
	public InputField fluCardNumInput;
	string fileUrl;


	// Use this for initialization
	void Start () {
		fileUrl="Data/gameData";
		Debug.Log(fileUrl);
		if(_instance==null){
			_instance=this;
		}
		readFile();
	}

	public void changeText(){
		cicleNumInput.text=""+gameData.cicleNumFinish;
		actionTimeInput.text=""+gameData.actionTimeSg;
		investmentTimeInput.text=""+gameData.investmentTimeSg;
		fluCardNumInput.text=""+gameData.fluCardNum;
	}

	private void saveDataToObject(){
		gameData.cicleNumFinish=int.Parse(cicleNumInput.text);
		gameData.actionTimeSg=int.Parse(actionTimeInput.text);
		gameData.investmentTimeSg=int.Parse(investmentTimeInput.text);
		gameData.fluCardNum=int.Parse(fluCardNumInput.text);
	}

	private void readFile(){
		string fileJson="";
		if(Resources.Load<TextAsset>(fileUrl)!=null){
			TextAsset dataTextAsset=Resources.Load<TextAsset>(fileUrl);
			Debug.Log(dataTextAsset.text);
			fileJson = dataTextAsset.text;
			gameData=JsonUtility.FromJson<GameData>(fileJson);
			Debug.Log(gameData);
			changeText();
			uiManager.openGame();
		}else{
			Debug.LogError("No Data File Found");
		}
	}

	public void SaveFile(){
		saveDataToObject();
		string saveData=JsonUtility.ToJson(gameData);
		File.WriteAllText("Assets/Resources/"+fileUrl+".txt",saveData);
	}

}
