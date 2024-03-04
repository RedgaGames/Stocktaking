using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// This class holds every basic level configs and collects data.
/// </summary>

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private string _itemOnChecklistSlot1, _itemOnChecklistSlot2, _itemOnChecklistSlot3, _itemOnChecklistSlot4, _itemOnChecklistSlot5;

    private ItemType itemType1, itemType2, itemType3, itemType4, itemType5;

    public int ItemQuantityTomato { get; private set; }
    public int ItemQuantityMilk { get; private set; }
    public int ItemQuantityMeat { get; private set; }
    public int ItemQuantityCheese { get; private set; }



    private void Start()
    {
        if (_itemOnChecklistSlot1 != null) { itemType1 = GetEnum(_itemOnChecklistSlot1); }
        if (_itemOnChecklistSlot2 != null) { itemType2 = GetEnum(_itemOnChecklistSlot1); }
        if (_itemOnChecklistSlot3 != null) { itemType3 = GetEnum(_itemOnChecklistSlot1); }
        if (_itemOnChecklistSlot4 != null) { itemType4 = GetEnum(_itemOnChecklistSlot1); }
        if (_itemOnChecklistSlot5 != null) { itemType5 = GetEnum(_itemOnChecklistSlot1); }
    }

    public void ChangeQuantityOfItemInSlot(int orderOnChecklist, int newValue)
    {
        if (orderOnChecklist == 1) { SetQuantityByType(itemType1, newValue); }
        if (orderOnChecklist == 2) { SetQuantityByType(itemType2, newValue); }
        if (orderOnChecklist == 3) { SetQuantityByType(itemType3, newValue); }
        if (orderOnChecklist == 4) { SetQuantityByType(itemType4, newValue); }
        if (orderOnChecklist == 5) { SetQuantityByType(itemType5, newValue); }
    }

    private void SetQuantityByType(ItemType itemType, int newValue)
    {
        switch (itemType)
        {
            case ItemType.tomato:
                ItemQuantityTomato = newValue;
                Debug.Log("ItemQuantityTomato = " + ItemQuantityTomato);
                break;
        }

    }







    // Unity doenst support enums in the hierachy??!
    private ItemType GetEnum(string itemName)
    {
        ItemType itemType;
        if (itemName == "Tomato") { itemType = ItemType.tomato; }
        else if (itemName == "Milk") { itemType = ItemType.milk; }
        else if (itemName == "Meat") { itemType = ItemType.meat; }
        else if (itemName == "Cheese") { itemType = ItemType.cheese; }
        else { itemType = ItemType.empty; }

        return itemType;
    }

    // Enum of all available Items in this game
    public enum ItemType
    {
        tomato,
        milk,
        meat,
        cheese,
        empty
    }

}
