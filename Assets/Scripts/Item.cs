using UnityEngine;
using System.Collections;
/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	new public string name = "New Item";	// Name of the item
	public Sprite icon = null;				// Item icon
	public bool showInInventory = true;

	// Called when the item is pressed in the inventory
	public virtual void Use ()
	{
		// Use the item
		// Something may happen
		Inventory.instance.inventoryUI.Close();
		waitForInput(); //not working
		RemoveFromInventory();

	}

	//wait for mouse click -- not working
	public IEnumerator waitForInput(){

		bool done = false;
		while(!done){
			if(Input.GetMouseButtonDown(2)){
				Debug.Log("detected mouse click");
				done = true;
			}
			yield return new WaitForEndOfFrame();
		}
	}

	// Call this method to remove the item from inventory
	public void RemoveFromInventory ()
	{
		Inventory.instance.Remove(this);
		Inventory.instance.inventoryUI.UpdateUI();
	}

}