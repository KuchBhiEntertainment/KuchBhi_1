using UnityEngine;
using System.Collections;

public class DeadPool : MonoBehaviour 
{
    float time;
    float gameOverDelay = 0.2f;
    bool triggerGameOver = false;
    GameMaster gameMasterScript;
    PenguinController penguin;
    void Awake()
    {
        gameMasterScript = Object.FindObjectOfType<GameMaster>().GetComponent<GameMaster>();
        penguin = Object.FindObjectOfType<PenguinController>().GetComponent<PenguinController>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (triggerGameOver) return;
        if(other.gameObject.name == "Penguin")
        {
            penguin.ChangeMyColor();
            time = gameOverDelay;
            triggerGameOver = true;
        }
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0 && triggerGameOver)
        {
            triggerGameOver = false;
            gameMasterScript.KillPlayer();
        }
    }
}
