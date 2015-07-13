using UnityEngine;
using System.Collections;

public class SnowBallController : MonoBehaviour 
{
    Animator anim;
    GameMaster gameMaster;
    public float snowBallSpeed;
    public float damageToGive;
    bool breakBall = false;
    float snowBreakTime = 0f;
    float snowBreakDelay = 0.2f;
    float time = 0f;
	// Use this for initialization
	void Awake () 
    {
        anim = GetComponent<Animator>();
        gameMaster = Object.FindObjectOfType<GameMaster>().GetComponent<GameMaster>();
	}
	
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Penguin" || other.gameObject.name == "Eskimo")
        {
            if (other.gameObject.name == "Penguin") gameMaster.DoDamageToPenguin(damageToGive);
            if (other.gameObject.name == "Eskimo") gameMaster.DoDamageToEskimo(damageToGive);
            anim.SetTrigger("Break");
            breakBall = true;
            snowBreakTime = snowBreakDelay;
        }
    }

	// Update is called once per frame
	void FixedUpdate () 
    {
            snowBreakTime -= Time.deltaTime;
            
            if(breakBall && snowBreakTime <= 0)
            {
                breakBall = false;
                Destroy(gameObject);
            }
            transform.Translate(Vector3.left * snowBallSpeed * Time.deltaTime);
	}
}
