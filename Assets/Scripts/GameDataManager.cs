using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
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
	public SoundManager soundManager;
	string fileUrl="Data/gameData";



	// Use this for initialization
	void Start () {
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
			uiManager.openLoadingPanel();
			TextAsset dataTextAsset=Resources.Load<TextAsset>(fileUrl);
			Debug.Log(dataTextAsset.text);
			fileJson = dataTextAsset.text;
			gameData=JsonUtility.FromJson<GameData>(fileJson);
			changeText();
			soundManager.fromDataChange();
			uiManager.openGame();
		}else{
			Debug.LogError("No Data File Found");
		}
	}

	public void SaveFile(){
		string path="Assets/Resources/"+fileUrl+".txt";
		using(StreamWriter writer=new StreamWriter(path)){
		//UIManager._instance.openLoadingPanel();
		saveDataToObject();
		string saveData=JsonUtility.ToJson(gameData);
		//File.WriteAllText("Assets/Resources/"+fileUrl+".txt",saveData);
			Debug.Log("Check:"+saveData);
			writer.WriteLine(saveData);
		}
		Debug.Log("Finish");
	}

}
