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

			//Debug.Log("test 1");

			// Shoot out a ray
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// If we hit
			 // Cast a ray straight down.
       	 	//RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
			if (Physics.Raycast(ray, out hit)){
				Item itemHit = hit.collider.GetComponent<Item>();
			}
	    	// Cast a ray straight down.
        	//RaycastHit2D hit2 = Physics2D.Raycast(ray, out hit);

        	// If it hits something...
        	//if (hit2.collider != null)
				//{
				//Debug.Log("hit");
				//Interact(itemHit);

				//}

			Debug.Log("test 2");

     	}
 }

 	// This method is meant to be overwritten
	public virtual void Interact ()
	{
		
	}

}
