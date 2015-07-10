using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {

    int score = 0;
    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 40, 50, 80, 30), "YOU WIN");
        GUI.Label(new Rect(Screen.width / 2 - 40, 300, 800, 30), "Score :" + score);

        if (GUI.Button(new Rect(Screen.width / 2 - 53, 350, 100, 30), "PLAY AGAIN?"))
        {
            Application.LoadLevel(0);
        }
    }
}
