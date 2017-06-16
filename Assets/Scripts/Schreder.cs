using UnityEngine;
using System.Collections;

public class Schreder : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D trigger){
		Destroy(trigger.gameObject);
	}
}
