using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class holds every basic level configs and collects data.
/// </summary>

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private string _itemOnChecklistSlot1, _itemOnChecklistSlot2, _itemOnChecklistSlot3, _itemOnChecklistSlot4, _itemOnChecklistSlot5;

    private ItemType itemType1, itemType2, itemType3, itemType4, itemType5; 

    public int CurrentLevel { get; private set; }

    public int ItemQuantityTomato { get; private set; }
    public int ItemQuantityMilk { get; private set; }
    public int ItemQuantityMeat { get; private set; }
    public int ItemQuantityCheese { get; private set; }

    public int ItemCountOnSceneTomato { get; private set; }
    public int ItemCountOnSceneMilk { get; private set; }
    public int ItemCountOnSceneMeat { get; private set; }
    public int ItemCountOnSceneCheese { get; private set; }

    public int ResultAllItemsCountOnScene { get; private set; }
    public int ResultAllItemsCountOnChecklist { get; private set; }

    private bool isTomatoOnScene, isMilkOnScene, isCheeseOnScene, isMeatOnScene = false;

    private void Start()
    {
        if (_itemOnChecklistSlot1 != null) { itemType1 = GetEnum(_itemOnChecklistSlot1); }
        if (_itemOnChecklistSlot2 != null) { itemType2 = GetEnum(_itemOnChecklistSlot2); }
        if (_itemOnChecklistSlot3 != null) { itemType3 = GetEnum(_itemOnChecklistSlot3); }
        if (_itemOnChecklistSlot4 != null) { itemType4 = GetEnum(_itemOnChecklistSlot4); }
        if (_itemOnChecklistSlot5 != null) { itemType5 = GetEnum(_itemOnChecklistSlot5); }

        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("CurrentLevel = " + CurrentLevel);
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
                break;
            case ItemType.milk:
                ItemQuantityMilk = newValue;
                break;
            case ItemType.meat:
                ItemQuantityMeat = newValue;
                break;
            case ItemType.cheese:
                ItemQuantityCheese = newValue;
                break;
        }
    }

    // Counts every Object in the scene which is relevant for the endscreen
    public void CountAllItems()
    {
        if (isTomatoOnScene)
        {
            GameObject[] tomatoes = GameObject.FindGameObjectsWithTag("Tomato");
            ItemCountOnSceneTomato = tomatoes.Length;
        }
        if (isMilkOnScene)
        {
            GameObject[] milks = GameObject.FindGameObjectsWithTag("Milk");
            ItemCountOnSceneMilk = milks.Length;
        }
        if (isCheeseOnScene)
        {
            GameObject[] cheeses = GameObject.FindGameObjectsWithTag("Cheese");
            ItemCountOnSceneCheese = cheeses.Length;
        }
        if (isMeatOnScene)
        {
            GameObject[] meats = GameObject.FindGameObjectsWithTag("Meat");
            ItemCountOnSceneMeat = meats.Length;
        }

        CountAllItemsOnScene();
        CountAllItemsOnChecklist();
    }   

    private void CountAllItemsOnScene()
    {
        ResultAllItemsCountOnScene =
            ItemCountOnSceneTomato +
            ItemCountOnSceneMilk +
            ItemCountOnSceneMeat +
            ItemCountOnSceneCheese;
        
        Debug.Log("Tomatos on Scene: " + ItemCountOnSceneTomato);
        Debug.Log("Milk on Scene: " + ItemCountOnSceneMilk);
        Debug.Log("Meat on Scene: " + ItemCountOnSceneMeat);
        Debug.Log("Cheese on Scene: " + ItemCountOnSceneCheese);
    }

    private void CountAllItemsOnChecklist()
    {
        ResultAllItemsCountOnChecklist =
            ItemQuantityTomato +
            ItemQuantityMilk +
            ItemQuantityMeat +
            ItemQuantityCheese;
    }

    // Unity doenst support enums in the hierachy??!
    private ItemType GetEnum(string itemName)
    {
        ItemType itemType;
        if (itemName == "Tomato") { itemType = ItemType.tomato; isTomatoOnScene = true; }
        else if (itemName == "Milk") { itemType = ItemType.milk; isMilkOnScene = true; }
        else if (itemName == "Meat") { itemType = ItemType.meat; isMeatOnScene = true; }
        else if (itemName == "Cheese") { itemType = ItemType.cheese; isCheeseOnScene = true; }
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
