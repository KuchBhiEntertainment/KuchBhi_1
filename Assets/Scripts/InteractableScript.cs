using UnityEngine;
using System.Collections;

public class InteractableScript : MonoBehaviour
{//public Transform obj;
    public void RemoveMe()
    {
        //transform.position = new Vector3(0, -4, 0);
        transform.GetComponent<Rigidbody>().useGravity = true;
    }
}
