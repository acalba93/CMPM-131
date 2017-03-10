using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {
    public Text counterText;
    public Text time_word;
    public float seconds, minutes;


	// Use this for initialization
void Start () {
        counterText = GetComponent<Text>() as Text;
        time_word = GetComponent<Text>() as Text;

    }
	
	// Update is called once per frame
	void Update () {
        minutes = (int)(Time.timeSinceLevelLoad / 60f);
        seconds = (int)(Time.timeSinceLevelLoad % 60f);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        PlayerPrefs.SetString("Time", counterText.text);

    }
}
