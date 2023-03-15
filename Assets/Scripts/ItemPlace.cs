using UnityEngine;
using UnityEngine.UI;


public class ItemPlace : MonoBehaviour {
    public Item item;
	

    void Update () {

		if(item.InUseItemFunction && Input.GetMouseButtonDown(0)){
			item.Use(Input.mousePosition);
		}

	}

}