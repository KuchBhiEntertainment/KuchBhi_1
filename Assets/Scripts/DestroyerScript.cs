using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Penguin") Application.LoadLevel(1);
        if (other != null) Destroy(other.gameObject);
    }  
}
