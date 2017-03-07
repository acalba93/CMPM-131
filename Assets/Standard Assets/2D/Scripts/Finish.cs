using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour {
    public string time = "00";
    public Text myText;
    [SerializeField] private string NextLevel="test";
	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>() as Text;
        PlayerPrefs.SetString("next_level", NextLevel);

    }
	
	// Update is called once per frame
	void Update () {
		
	}


void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
            //time = myText.text;
            //PlayerPrefs.SetString("Time", time);
			SceneManager.LoadScene("result_screen");
		}
}
}