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
		Debug.Log("AddItem called");
		item = newItem;
		itemDuplicateCounter.text = item.itemGameObjects.Count.ToString();
		
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
		//Update displayed item number if it is not fully removed
		if(item.itemGameObjects.Count > 1){
			itemDuplicateCounter.text = (item.itemGameObjects.Count-1).ToString();
		}

		item.RemoveFromInventory();

	}

	// Use the item
	public void UseItem ()
	{
		
		if (item != null)
		{
			Debug.Log("UseItem called");
			item.InUseItemFunction = true;
			GameObject g = (GameObject)item.itemGameObjects.Peek();
			g.SetActive(true); 
			g.GetComponent<Renderer>().enabled = false;
			
			//remove item before closing inventory if count will be 0 after placed
			if(item.itemGameObjects.Count == 1){
				Inventory.instance.Remove(item);
				Inventory.instance.inventoryUI.UpdateUI();
			}

			Inventory.instance.inventoryUI.Close();
		}
	}

}