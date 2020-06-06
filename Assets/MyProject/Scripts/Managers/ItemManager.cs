using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    private Stack<ItemInfo> items= new Stack<ItemInfo>();

    // Update is called once per frame
    void Update()
    {
        Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(myray, out hit))
        {
            if (hit.distance < 2f && hit.transform.GetComponent<Item>())
            {
                
                Item item = hit.transform.GetComponent<Item>();
                UIManager.Instance.SetPickUpTextInfo(item.ItemInfo.nameItem+"\n lewy przycisk myszy!");
                if (Input.GetMouseButtonDown(0))
                {
                    if (items.Count == 0 && item.ItemInfo.currentItem == Equipment.Outfit ||
                        items.Count > 0 && items.Peek().currentItem==item.ItemInfo.previousItem)
                    {
                        item.Action();
                        items.Push(item.ItemInfo);
                        UIManager.Instance.SetErrorPickUpMessage("");
                    }
                    else UIManager.Instance.SetErrorPickUpMessage(item.ItemInfo.errorMessage);
                } 
            }
            else UIManager.Instance.SetPickUpTextInfo("");
        }
    }
}
