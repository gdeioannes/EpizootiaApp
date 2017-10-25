using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour {
	private float volume=1f;
	public static SoundManager _instance;
	public Image image;
	public Text soundTxt;

	// Use this for initialization
	void Start () {
		if(_instance==null){
			_instance=this;
		}
	}

	public void changeSoundParameter(){
		if(!GameDataManager._instance.gameData.sound){
			gameObject.GetComponents<AudioSource>()[0].Play();
			GameDataManager._instance.gameData.sound=true;
			soundTxt.text="ON";
			image.color=Color.blue;
		}else{
			gameObject.GetComponents<AudioSource>()[0].Stop();
			GameDataManager._instance.gameData.sound=false;
			soundTxt.text="OFF";
			image.color=Color.red;
		}
		GameDataManager._instance.SaveFile();
	}

	public void fromDataChange(){
		if(GameDataManager._instance.gameData.sound){
			gameObject.GetComponents<AudioSource>()[0].Play();
			soundTxt.text="ON";
			image.color=Color.blue;
		}else{
			gameObject.GetComponents<AudioSource>()[0].Stop();
			soundTxt.text="OFF";
			image.color=Color.red;
		}
	}

	public void playRollDice(){
		playSound(1);
	}

	public void playMoney(){
		playSound(2);
	}

	public void playChiken(){
		playSound(3);
	}

	public void playAlarm(){
		playSound(4);
	}

	public void playBeep(){
		playSound(5);
	}

	public void playSound(int num){
		if(GameDataManager._instance.gameData.sound){
			gameObject.GetComponents<AudioSource>()[num].Play();
		}else{
			Debug.Log("SOUND OFF");
		}
	}
}
