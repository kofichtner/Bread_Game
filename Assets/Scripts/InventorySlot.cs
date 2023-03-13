using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour {

	public Image icon;
	public Button removeButton;
	public Text itemDuplicateCounter;
	//public int itemCounter;


	Item item;	// Current item in the slot


	// Add item to the slot
	public void AddItem (Item newItem)
	{
		item = newItem;
		itemDuplicateCounter.text = item.itemCounter.ToString();
		
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
		itemDuplicateCounter.text = "";
		
	}

	// If the remove button is pressed, this function will be called.
	public void RemoveItemFromInventory ()
	{
		Debug.Log("removing item");
		item.itemCounter--;
		if(item.itemCounter==0){
			itemDuplicateCounter.text = "";
			Inventory.instance.Remove(item);
		}

	}

	// Use the item
	public void UseItem ()
	{
		Debug.Log("using item");
		if (item != null)
		{
			item.InUseItemFunction = true;
			item.itemGameObject.SetActive(true);
			item.itemGameObject.GetComponent<Renderer>().enabled = false;

			RemoveItemFromInventory();
			Inventory.instance.inventoryUI.Close();
		}
	}

}