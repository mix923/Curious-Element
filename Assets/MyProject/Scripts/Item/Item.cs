using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemInfo itemInfo;
    public ItemInfo ItemInfo
    {
        get
        {
            return itemInfo;
        }
    }

    public void Action()
    {
        if (itemInfo.currentItem == Equipment.Extinguisher)
        {
            UIManager.Instance.HidePanelErrorPickUpMessage();
            GameObject.Find("Extinguisher").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("Extinguisher").GetComponent<Extinguisher>().IsActive = true;
            GameObject.FindObjectOfType<Player>().HasExtinguisher = true;
        }
        Destroy(this.gameObject);
    }

}
