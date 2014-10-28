using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	
	public Transform pointer;
	public bool aiming;
	public float shootStrength;
	public int remainingBalls;
	
	GameObject currentBall;

	void Start () {
		Game.OnShootFinished += OnShootFinished;
		StartCoroutine(ChargeShoot());
	}
	
	void Update () {
		
		#if UNITY_IPHONE || UNITY_ANDROID
	
		if(Input.touchCount > 0) {
			
			if(aiming) {
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				touchPosition.z = 0;
				float angle = Vector3.Angle(Vector3.down,touchPosition - transform.position) * Mathf.Sign(Input.GetTouch(0).position.x);
				transform.localRotation = Quaternion.Euler(0,0,angle);
			}
	
			if(Input.GetTouch(0).phase == TouchPhase.Ended && aiming) {
				aiming = false;
				iTween.FadeTo(gameObject,0,1);
				currentBall.GetComponent<Rigidbody>().isKinematic = false;
				currentBall.GetComponent<Rigidbody>().AddForce(pointer.forward * shootStrength,ForceMode.Force);
				currentBall = null;
			}		
	
		}
		
		#else
		
		if(aiming) {
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePosition.z = 0;
			float angle = Vector3.Angle(Vector3.down,mousePosition - transform.position) * Mathf.Sign(mousePosition.x);
			transform.localRotation = Quaternion.Euler(0,0,angle);
		}	
	
		if(Input.GetMouseButtonUp(0) && aiming) {
			aiming = false;
			iTween.FadeTo(gameObject,0,1);
			currentBall.GetComponent<Rigidbody>().isKinematic = false;
			currentBall.GetComponent<Rigidbody>().AddForce(pointer.forward * shootStrength,ForceMode.Force);
			currentBall = null;
		}
		
		#endif
		
	}
	
	void OnShootFinished() {
		if(remainingBalls > 0) {
			StartCoroutine(ChargeShoot());
		}
	}
	
	IEnumerator ChargeShoot() {
		yield return new WaitForSeconds(0.5f);
		remainingBalls--;
		aiming = true;
		iTween.FadeTo(gameObject,1,0.2f);
		currentBall = Instantiate(Resources.Load("YellowBall")) as GameObject;
		currentBall.transform.position = transform.position;
		currentBall.GetComponent<Rigidbody>().isKinematic = true;
	}
	
	void OnDestroy() {
		Game.OnShootFinished -= OnShootFinished;
	}
	
}
