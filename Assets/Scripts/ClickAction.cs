using UnityEngine;
using System.Collections;

public class ClickAction : MonoBehaviour 
{    
	void Update () 
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Update Called !");
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(toMouse, out rhInfo, 500.0f);
            if(didHit)
            {
                Debug.Log(rhInfo.collider.name+"  "+ rhInfo.point);
                InteractableScript destScript = rhInfo.collider.GetComponent<InteractableScript>();
                if(destScript)
                {
                    destScript.RemoveMe();
                }
            }
            else
            {
                //Debug.Log("Clicked on Empty Space");
            }
        }
	}
}
