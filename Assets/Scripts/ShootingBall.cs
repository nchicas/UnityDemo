using UnityEngine;
using System.Collections;

public class ShootingBall : MonoBehaviour {

	public enum State {
		Idle,
		Bouncing
	}
	
	public State state;
	
	void Update () {
		if(state == State.Idle && GetComponent<Rigidbody>().velocity.magnitude >= 0.1f) {
			state = State.Bouncing;
		}
		
		if(transform.position.y < -21) {
			Remove();
		}
	}
	
	void Remove() {
		Game.instance.CompleteShoot();
		Destroy(gameObject);
	}
	
}
