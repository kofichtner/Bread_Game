using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

/*	
	This component is for all objects that the player can
	interact with such as enemies, items etc. It is meant
	to be used as a base class.
*/

public class Interactable : MonoBehaviour {
	
	public LayerMask interactionMask;	// Everything we can interact with

	
 // Update is called once per frame
 	void Update () {

     	if(Input.GetMouseButtonDown(0)){

            //Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, interactionMask);

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name); //print the item we hit
				hit.collider.GetComponent<Interactable>().Interact(); //put item in inventory
			}

     	}
 }

 	// This method is meant to be overwritten
	public virtual void Interact ()
	{
		
	}

}
