using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour {
    private GameObject target;
    public int missileSpeed;
	// Use this for initialization
	void Start () 
    {
        target = GameObject.FindGameObjectWithTag("Player");
	}
	void Update () 
    {
            //transform.LookAt(target.transform.position);
        	transform.position=Vector2.MoveTowards(transform.position,target.transform.position,missileSpeed*Time.deltaTime);
	}
}
