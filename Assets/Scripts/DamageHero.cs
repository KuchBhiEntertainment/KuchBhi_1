using UnityEngine;
using System.Collections;

public class DamageHero : MonoBehaviour 
{
    public PlayerStats playerStatsScript;
    public int DamageToGive = 10;
    [SerializeField]public int power = 100;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Icecles")
        {
             Debug.Log("Damage Done On HERO");
             playerStatsScript.DamagePlayer(DamageToGive);
             Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "HomingMissile")
        {
            Debug.Log("Damage Done On VILLAIN");
            playerStatsScript.DamagePlayer(DamageToGive);
            Destroy(other.gameObject);
        }
    }
}
