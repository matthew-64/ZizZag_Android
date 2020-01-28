using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Called when an object exits the trigger
	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Ball") {

			//Invoke helps us call a function after a certain ammount of time
			//(Name of function, how many seconds to wait)
			Invoke("FallDown", 0.1f);
		}
	}

	void FallDown() {
		//The gravits function gets caled and latform falls down
		GetComponentInParent<Rigidbody> ().useGravity = true;

		//Will cause platforms to fall down
		GetComponentInParent<Rigidbody> ().isKinematic = false;

		//(parent game object, time
		Destroy(transform.parent.gameObject, 2f);
	}
}
