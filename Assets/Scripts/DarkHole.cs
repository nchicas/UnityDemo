using UnityEngine;
using System.Collections;

public class DarkHole : MonoBehaviour {
	
	public DarkHole tunnelHole;
	public bool usingTunnel;
	
	void Update () {
		transform.Rotate(Vector3.down,360*Time.deltaTime);
	}
	
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "BulletBall" && !usingTunnel) {
			tunnelHole.usingTunnel = true;
			collision.gameObject.rigidbody.MovePosition(tunnelHole.transform.position);
		}
	} 
	
	void OnCollisionExit(Collision collision) {
		if(collision.gameObject.tag == "BulletBall") {
			usingTunnel = false;
		}
	} 
	
}
