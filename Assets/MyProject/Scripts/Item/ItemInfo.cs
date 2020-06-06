using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Equipment { Null,Extinguisher,Helmet,Outfit }

[CreateAssetMenu(fileName = "Equipment", menuName = "Equipments/Create")]
public class ItemInfo : ScriptableObject
{
    public string nameItem;
    public Equipment currentItem;
    public Equipment previousItem;
    public string errorMessage;
}
