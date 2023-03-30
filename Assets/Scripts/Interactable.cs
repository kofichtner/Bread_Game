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
				Vector2 breadPlayerCurrentPosition = GameObject.Find("Bread_Player").transform.position; //Bread Player's current position
				Vector2 itemCurrentPosition = GameObject.Find(hit.collider.gameObject.name).transform.position; //Item's current position
				float spriteToItemDist = Vector2.Distance(itemCurrentPosition,breadPlayerCurrentPosition);//gets the distance between the Bread Player and the Item
				if(spriteToItemDist <= 2){
					if((int)hit.collider.gameObject.layer == LayerMask.NameToLayer("Item")){
						// Debug.Log((int)hit.collider.gameObject.layer);
						hit.collider.GetComponent<Interactable>().Interact(); //put item in inventory
					}
						//TODO add else if interactionMask == door, then open minimap...
				}
			}
     	}
 }

 	// This method is meant to be overwritten
	public virtual void Interact ()
	{
		
	}

}
