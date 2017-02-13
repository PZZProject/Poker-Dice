using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    

    // Use this for initialization
    void Start () {
		
	}

	public void LoadLevel(string name)
	{
		SceneManager.LoadScene(name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
