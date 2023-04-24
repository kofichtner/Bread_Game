using UnityEngine;
using System;
using System.Collections;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	new public string name = "New Item";	// Name of the item
	public Sprite icon = null;				// Item icon
	public bool showInInventory = true;

	public Queue itemGameObjects= new Queue(); 
	

	public bool InUseItemFunction =false;
	
	public void setGameObject(GameObject g)
	{

		itemGameObjects.Enqueue(g);
		Debug.Log("setGameObject called "+itemGameObjects.Count);
	}

	// Called when the item is pressed in the inventory
	public virtual void Use (Vector3 mousePosition)
	{
		// Use the item
		// Something may happen
		Debug.Log("Item Use Function Called");

		Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		GameObject g = (GameObject)itemGameObjects.Peek();
		g.SetActive(true); 
		g.transform.position = worldPoint;
		g.GetComponent<Renderer>().enabled = true;
		this.InUseItemFunction = false;

		//Dequeue here because we cannot call RemoveFromInventory since inventory is closed
		this.itemGameObjects.Dequeue(); 

	}

	// Call this method to remove the item from inventory
	public void RemoveFromInventory ()
	{
		//Dequeue first game object in list
		//only remove from inventory if last one
		this.itemGameObjects.Dequeue();
		if(itemGameObjects.Count == 0){
			Inventory.instance.Remove(this);
			Inventory.instance.inventoryUI.UpdateUI();
		}
	}

}

