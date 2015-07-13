using UnityEngine;
using System.Collections;

public class SnowBallTrigger : MonoBehaviour 
{
    GameObject Parent;
    bool added = false;

    void Awake()
    {
        Parent = transform.parent.gameObject;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (added) return;
        if (other.gameObject.name == "Penguin")
        {
            Debug.Log("added");
            Parent.AddComponent<SnowBallController>();
            added = true;
        }
    }
}
