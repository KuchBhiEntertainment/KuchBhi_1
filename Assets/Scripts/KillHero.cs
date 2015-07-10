using UnityEngine;
using System.Collections;

public class KillHero : MonoBehaviour {
    
    public PlayerStats playerStatsScript;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Villain")
        {
            Debug.Log("Damage Done On HERO");
            playerStatsScript.DamagePlayer(999);
            //Destroy(other.gameObject);
        }
    }
}
