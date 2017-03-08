using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class result_screen : MonoBehaviour {
    public Text resultText;

    // Use this for initialization
    void Start () {
        resultText = GetComponent<Text>() as Text;
		resultText.text = PlayerPrefs.GetString("Time Completed: ")+"\n\n"+PlayerPrefs.GetString("Lives Remaining: ");
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
