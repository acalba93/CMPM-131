using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {
	[SerializeField] private string NextLevel="test";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			SceneManager.LoadScene(NextLevel);
		}
}
}