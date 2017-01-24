using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDieValue : MonoBehaviour {
	public List<GameObject> lista;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update() {
		DisplayCurrentDieValue dcdv = GetComponent<DisplayCurrentDieValue>();
		//dcdv.currentValue
		GameManager GM = GetComponent<GameManager>();
		int value = 0;
		/*foreach (var item in lista)
		{
			item
		}
		GM.die.*/
	}
}
