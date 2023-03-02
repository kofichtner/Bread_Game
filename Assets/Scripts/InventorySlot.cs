using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour {

	public Image icon;
	public Button removeButton;
	public bool InUseItemFunction = false;
	public bool onClickStatus = false;


	Item item;	// Current item in the slot

	void Update () {

		//TODO: need to move this somewhere else since inventory is disabled when we place
		if(InUseItemFunction && Input.GetMouseButtonDown(0)){
			item.Use(Input.mousePosition);
			RemoveItemFromInventory();
			InUseItemFunction = false;
		}


	}

	// Add item to the slot
	public void AddItem (Item newItem)
	{
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
	}

	// Clear the slot
	public virtual void ClearSlot ()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
	}

	// If the remove button is pressed, this function will be called.
	public void RemoveItemFromInventory ()
	{
		Debug.Log("removing item");
		Inventory.instance.Remove(item);
	}

	// Use the item
	public void UseItem ()
	{
		InUseItemFunction = true;
		Debug.Log("using item");
		if (item != null)
		{
			
			
			// Inventory.instance.inventoryUI.Close();
			Debug.Log("UseItemDone");
		}
	}

}