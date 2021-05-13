using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum ItemType
{
    Weapon,
    Armor,
    Default
}

public abstract class ItemObject : ScriptableObject
{
    public int Id;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(15,20)] public string description;
}
