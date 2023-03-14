using UnityEngine;
using UnityEngine.UI;


public class ItemPlace : MonoBehaviour {
    public Item item;
	

    void Update () {

		//TODO: need to move this somewhere else since inventory is disabled when we place
		if(item.InUseItemFunction && Input.GetMouseButtonDown(0)){
			Debug.Log(item.itemGroup);
			item.Use(Input.mousePosition);
		}


	}

}