using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class result_screen : MonoBehaviour {
    public Text resultText;
    public Text live_word;

    // Use this for initialization
    void Start () {
        resultText = GetComponent<Text>() as Text;
        resultText.text = "Time Completed: " + PlayerPrefs.GetString("Time") + "\n\n" + "Lives Remaining: " + PlayerPrefs.GetString("Lives Remaining: ");
        //print(PlayerPrefs.GetString("Time"));

    }
	
	// Update is called once per frame
	void Update () {
        

    }
    public void ChangeLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("next_level"));

    }
    
}
