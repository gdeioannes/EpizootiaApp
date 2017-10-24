using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildScenario : MonoBehaviour {

	public Text info;
	private List<ScenarioObj> listScenarioObjs;
	private int easyNum=3;
	private int mediumNum=4;
	private int hardNum=5;
	List<string> pickPos;
	List<string> pos=new List<string>(){"A2","A3","A4","A5","A6","A7",
		"B1","B2","B3","B4","B5","B6","B7","B8",
		"C1","C2","C3","C4","C5","C6","C7","C8",
		"D1","D2","D3","D4","D5","D6","D7","D8",
		"E1","E2","E3","E4","E5","E6","E7","E8",
		"F1","F2","F3","F4","F5","F6","F7","F8",
		"G1","G2","G3","G4","G5","G6","G7","G8",
		"H2","H3","H4","H5","H6","H7"};
	
	private void setScenario(){
		listScenarioObjs=new List<ScenarioObj>(GameDataManager._instance.gameData.scenarioObjs);
	}

	public void easy(){
		setDiff(easyNum);
	}

	public void medium(){
		setDiff(mediumNum);
	}

	public void hard(){
		setDiff(hardNum);
	}

	private void setDiff(int diffNum){
		pickPos=new List<string>(pos);
		setScenario();
		string text="";
		for (int i = 0; i < diffNum; i++) {
			ScenarioObj pickSCenarioObj=listScenarioObjs[i];
			text+=pickSCenarioObj.name+" "+getGridPos();
			if(i!=diffNum-1){
				Debug.Log(i+""+diffNum);
				text+="\n";
			}
		}
		info.text=text;
	}

	private string getGridPos(){
		string pickPosString=pickPos[Random.Range(0,pickPos.Count)];
		pickPos.Remove(pickPosString);
		return pickPosString;
	}
}
