using UnityEngine;
using System.Collections;

public class SnowBallController : MonoBehaviour 
{
    Animator anim;
    public float snowBallSpeed;
    bool breakBall = false;
    float snowBreakTime = 0f;
    float snowBreakDelay = 0.3f;
    float time = 0f;
	// Use this for initialization
	void Awake () 
    {
        anim = GetComponent<Animator>();
	}
	
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Penguin" || other.gameObject.name == "Eskimo")
        {
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
                Destroy(gameObject);
            }
            transform.Translate(Vector3.left * snowBallSpeed * Time.deltaTime);
	}
}
