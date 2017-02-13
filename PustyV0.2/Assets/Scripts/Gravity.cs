using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {


	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<Rigidbody>().AddForce(Physics.gravity * GetComponent<Rigidbody>().mass);
	}
}
