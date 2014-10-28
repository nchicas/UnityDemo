using UnityEngine;
using System.Collections;

public class BouncingBall : MonoBehaviour {
	
	public enum State {
		Normal,
		Touched
	}
	
	public State state;
	
	void Start () {
		Game.OnShootFinished += OnShootFinished;
	}
	
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "BulletBall") {
			state = State.Touched;
			GetComponent<Renderer>().sharedMaterial = GetComponent<Renderer>().materials[0];
		}
		
	}
	
	void OnShootFinished() {
		if(state == State.Touched) {
			StartCoroutine(Remove());
		}
	}
	
	IEnumerator Remove() {
		iTween.ScaleTo(gameObject,transform.localScale * 1.2f,0.3f);
		yield return new WaitForSeconds(0.3f);
		iTween.ScaleTo(gameObject,transform.localScale * 0.5f,0.45f);
		iTween.FadeTo(gameObject,0.1f,0.45f);
		Destroy(gameObject,0.6f);
	}
	
	void OnDestroy() {
		Game.OnShootFinished -= OnShootFinished;
	}
	
}
