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

    LevelHandler levelHandler;

    SpriteRenderer itemSpriteRenderer1, itemSpriteRenderer2, itemSpriteRenderer3, itemSpriteRenderer4, itemSpriteRenderer5;

    private int itemQuantity1, itemQuantity2, itemQuantity3, itemQuantity4, itemQuantity5;

    private void Start()
    {
        levelHandler = FindObjectOfType<LevelHandler>();

        itemSpriteRenderer1 = numberIcon1 != null ? numberIcon1.GetComponent<SpriteRenderer>() : null;
        itemSpriteRenderer2 = numberIcon2 != null ? numberIcon2.GetComponent<SpriteRenderer>() : null;
        itemSpriteRenderer3 = numberIcon3 != null ? numberIcon3.GetComponent<SpriteRenderer>() : null;
        itemSpriteRenderer4 = numberIcon4 != null ? numberIcon4.GetComponent<SpriteRenderer>() : null;
        itemSpriteRenderer5 = numberIcon5 != null ? numberIcon5.GetComponent<SpriteRenderer>() : null;

        if (itemRed1 != null) { itemRed1.material = ChangeTransparency(itemQuantity1, itemRed1); }
        if (itemRed2 != null) { itemRed2.material = ChangeTransparency(itemQuantity1, itemRed2); }
        if (itemRed3 != null) { itemRed3.material = ChangeTransparency(itemQuantity1, itemRed3); }
        if (itemRed4 != null) { itemRed4.material = ChangeTransparency(itemQuantity1, itemRed4); }
        if (itemRed5 != null) { itemRed5.material = ChangeTransparency(itemQuantity1, itemRed5); }
    }

    public void ChangeQuantityOnScroll(int orderOnChecklist)
    {
        float scrollDirection = Input.GetAxis("Mouse ScrollWheel");

        if (scrollDirection > 0) { AddItemQuantity(orderOnChecklist); }
        else if (scrollDirection < 0) { ReduceItemQuantity(orderOnChecklist); }
    }

    public void AddItemQuantity(int orderOnChecklist)
    {
        switch (orderOnChecklist)
        {
            case 1:
                if (itemQuantity1 == 9) { return; }
                itemQuantity1++;

                itemAdd1.material = ChangeTransparency(itemQuantity1, itemAdd1);
                if (itemQuantity1 != 9) { itemRed1.material = ChangeTransparency(itemQuantity1, itemRed1); }

                Sprite newQuantitySprite = numbers[itemQuantity1];
                itemSpriteRenderer1.sprite = newQuantitySprite;

                levelHandler.ChangeQuantityOfItemInSlot(orderOnChecklist, itemQuantity1);

                break;
            case 2:
                if (itemQuantity2 == 9) { return; }
                itemQuantity2++;

                itemAdd2.material = ChangeTransparency(itemQuantity2, itemAdd2);
                if (itemQuantity2 != 9) { itemRed2.material = ChangeTransparency(itemQuantity2, itemRed2); }

                Sprite newQuantitySprite2 = numbers[itemQuantity2];
                itemSpriteRenderer2.sprite = newQuantitySprite2;

                levelHandler.ChangeQuantityOfItemInSlot(orderOnChecklist, itemQuantity2);

                break;

            case 3:
                if (itemQuantity3 == 9) { return; }
                itemQuantity3++;

                itemAdd3.material = ChangeTransparency(itemQuantity3, itemAdd3);
                if (itemQuantity3 != 9) { itemRed3.material = ChangeTransparency(itemQuantity3, itemRed3); }

                Sprite newQuantitySprite3 = numbers[itemQuantity3];
                itemSpriteRenderer3.sprite = newQuantitySprite3;

                levelHandler.ChangeQuantityOfItemInSlot(orderOnChecklist, itemQuantity3);

                break;

            case 4:
                if (itemQuantity4 == 9) { return; }
                itemQuantity4++;

                itemAdd4.material = ChangeTransparency(itemQuantity4, itemAdd4);
                if (itemQuantity4 != 9) { itemRed4.material = ChangeTransparency(itemQuantity4, itemRed4); }

                Sprite newQuantitySprite4 = numbers[itemQuantity4];
                itemSpriteRenderer4.sprite = newQuantitySprite4;

                levelHandler.ChangeQuantityOfItemInSlot(orderOnChecklist, itemQuantity4);

                break;
        }
    }

    public void ReduceItemQuantity(int orderOnChecklist)
    {
        switch (orderOnChecklist)
        {
            case 1:
                if (itemQuantity1 == 0) { return; }
                itemQuantity1--;

                itemRed1.material = ChangeTransparency(itemQuantity1, itemRed1);
                if (itemQuantity1 != 0) { itemAdd1.material = ChangeTransparency(itemQuantity1, itemAdd1); }

                Sprite newQuantitySprite = numbers[itemQuantity1];
                itemSpriteRenderer1.sprite = newQuantitySprite;

                levelHandler.ChangeQuantityOfItemInSlot(orderOnChecklist, itemQuantity1);

                break;
            case 2:
                if (itemQuantity2 == 0) { return; }
                itemQuantity2--;

                itemRed2.material = ChangeTransparency(itemQuantity2, itemRed2);
                if (itemQuantity2 != 0) { itemAdd2.material = ChangeTransparency(itemQuantity2, itemAdd2); }

                Sprite newQuantitySprite2 = numbers[itemQuantity2];
                itemSpriteRenderer2.sprite = newQuantitySprite2;

                levelHandler.ChangeQuantityOfItemInSlot(orderOnChecklist, itemQuantity2);

                break;

            case 3:
                if (itemQuantity3 == 0) { return; }
                itemQuantity3--;

                itemRed3.material = ChangeTransparency(itemQuantity3, itemRed3);
                if (itemQuantity3 != 0) { itemAdd3.material = ChangeTransparency(itemQuantity3, itemAdd3); }

                Sprite newQuantitySprite3 = numbers[itemQuantity3];
                itemSpriteRenderer3.sprite = newQuantitySprite3;

                levelHandler.ChangeQuantityOfItemInSlot(orderOnChecklist, itemQuantity3);

                break;

            case 4:
                if (itemQuantity4 == 0) { return; }
                itemQuantity4--;

                itemRed4.material = ChangeTransparency(itemQuantity4, itemRed4);
                if (itemQuantity4 != 0) { itemAdd4.material = ChangeTransparency(itemQuantity4, itemAdd4); }

                Sprite newQuantitySprite4 = numbers[itemQuantity4];
                itemSpriteRenderer4.sprite = newQuantitySprite4;

                levelHandler.ChangeQuantityOfItemInSlot(orderOnChecklist, itemQuantity4);

                break;
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

}



