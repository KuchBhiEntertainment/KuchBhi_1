using UnityEngine;
using System.Collections;

public class Eliminate_Icecle : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }
    }
}
