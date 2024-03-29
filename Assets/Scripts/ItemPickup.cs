using UnityEngine;

public class ItemPickup : Interactable {

	public Item item;	// Item to put in the inventory if picked up

	// When the player interacts with the item
	public override void Interact()
	{
		base.Interact();
		PickUp();

	}

	// Pick up the item
	void PickUp ()
	{
		Debug.Log("Picking up " + gameObject.name);
		item.setGameObject(gameObject);
		Inventory.instance.Add(item); // Add to inventory
		gameObject.SetActive(false);
		// Destroy(gameObject);	// Destroy item from scene
	}

}