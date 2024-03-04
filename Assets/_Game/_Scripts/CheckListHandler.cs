using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// This Class handels all basic checklist interactions.
/// Those actions are called via event trigger.
/// </summary>

public class CheckListHandler : MonoBehaviour
{
    [SerializeField] List<Sprite> numbers;
    [SerializeField] GameObject numberIcon1, numberIcon2, numberIcon3, numberIcon4, numberIcon5;
    [SerializeField] SpriteRenderer itemAdd1, itemAdd2, itemAdd3, itemAdd4, itemAdd5;
    [SerializeField] SpriteRenderer itemRed1, itemRed2, itemRed3, itemRed4, itemRed5;

    SpriteRenderer itemSpriteRenderer1, itemSpriteRenderer2, itemSpriteRenderer3, itemSpriteRenderer4, itemSpriteRenderer5;

    private int itemQuantity1, itemQuantity2, itemQuantity3, itemQuantity4, itemQuantity5;

    private void Start()
    {
        itemSpriteRenderer1 = numberIcon1 != null ? numberIcon1.GetComponent<SpriteRenderer>() : null;
        itemSpriteRenderer2 = numberIcon2 != null ? numberIcon2.GetComponent<SpriteRenderer>() : null;
        itemSpriteRenderer3 = numberIcon3 != null ? numberIcon3.GetComponent<SpriteRenderer>() : null;
        itemSpriteRenderer4 = numberIcon4 != null ? numberIcon4.GetComponent<SpriteRenderer>() : null;
        itemSpriteRenderer5 = numberIcon5 != null ? numberIcon5.GetComponent<SpriteRenderer>() : null;

        if (itemSpriteRenderer1 == null) { Debug.Log("Kein Sprite Renderer gefunden"); }
    }

    public void AddItemQuantity(String itemName)
    {
        ItemType itemType = GetEnum(itemName);



        if (itemType == ItemType.tomato)
        {
            if (itemQuantity1 == 9) { return; } //Sound

            itemQuantity1++;
            itemAdd1.material = ChangeTransparency(itemQuantity1, itemAdd1);

            // item icon ändern
            Sprite newQuantitySprite = numbers[itemQuantity1];
            itemSpriteRenderer1.sprite = newQuantitySprite;
        }
    }

    private Material ChangeTransparency(int currentQuantity, SpriteRenderer currentSpriteRenderer)
    {
        Material material = currentSpriteRenderer.material;
        Color color = material.color;

        if (currentQuantity == 0 || currentQuantity == 9) { color.a = 0.5f; }
        else { color.a = 1f; }

        material.color = color;

        return material;
    }

    // Unity doenst support enums in the hierachy??!
    private ItemType GetEnum(string itemName)
    {
        ItemType itemType;
        if (itemName == "Tomato") { itemType = ItemType.tomato; }
        else if (itemName == "Milk") { itemType = ItemType.tomato; }
        else if (itemName == "Meat") { itemType = ItemType.tomato; }
        else if (itemName == "Cheese") { itemType = ItemType.tomato; }
        else { itemType = ItemType.empty; }

        return itemType;
    }
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