using UnityEngine;
using System.Collections;

public class CameraRunnerScript : MonoBehaviour 
{
    [SerializeField]
    Transform player;	
	void Update () 
    {
        if(player == null) return;
        transform.position = new Vector3(player.position.x, 0, -1);
	}
}
