using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager _instance;

	// Use this for initialization
	void Start () {
		if(_instance==null){
			_instance=this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playRollDice(){
		gameObject.GetComponents<AudioSource>()[1].Play();
	}

	public void playMoney(){
		gameObject.GetComponents<AudioSource>()[2].Play();
	}

	public void playChiken(){
		gameObject.GetComponents<AudioSource>()[3].Play();
	}

	public void playAlarm(){
		gameObject.GetComponents<AudioSource>()[4].Play();
	}

	public void playBeep(){
		gameObject.GetComponents<AudioSource>()[5].Play();
	}
}
