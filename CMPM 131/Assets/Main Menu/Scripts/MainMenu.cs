using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public Texture backgroundTexture;
    void onGUI()
    {
        //display background texture
        GUI.DrawTexture(new Rect(100, 100, Screen.width, Screen.height), backgroundTexture);
        if(GUI.Button(new Rect(Screen.width * .5f, Screen.height * .5f, Screen.width * .5f,Screen.height *.1f), "Play"))
        {

        }

    }
}
