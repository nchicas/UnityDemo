using UnityEngine;
using System;
using System.Collections;

public class Game : MonoBehaviour {
	
	public static Game instance;
	public static Action OnShootFinished;
	
	void Awake() {
		instance = this;
	}
	
	void Update() {
		if(Input.GetKeyUp(KeyCode.Escape)) {
			Application.Quit();
		}
	}
	
	public void CompleteShoot() {
		if(OnShootFinished != null) {
			OnShootFinished();
		}
	}
	
}
