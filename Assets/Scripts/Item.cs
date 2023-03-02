using UnityEngine;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	new public string name = "New Item";	// Name of the item
	public Sprite icon = null;				// Item icon
	public bool showInInventory = true;

	public GameObject itemGameObject;
	

	public void setGameObject(GameObject g)
	{
		this.itemGameObject = g;
	}
	// Called when the item is pressed in the inventory
	public virtual void Use (Vector3 mousePosition)
	{
		// Use the item
		// Something may happen
		Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		this.itemGameObject.SetActive(true);
		this.itemGameObject.transform.position = worldPoint;
		Debug.Log(this.itemGameObject);
		Debug.Log(this.itemGameObject.transform.position);
	}

	// Call this method to remove the item from inventory
	public void RemoveFromInventory ()
	{
		Inventory.instance.Remove(this);
		Inventory.instance.inventoryUI.UpdateUI();
	}

}

