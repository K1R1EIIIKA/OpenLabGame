using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Shop : MonoBehaviour
{
    [SerializeField] private CollectableThingUI cheese;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject Rope;
    // [SerializeField] private GameObject Accordeon;
    private bool canBuy;
    private int currentCost = 999;

    public void CollectThing(int index)
    {
        if (inventory.GetArray()[index].GetComponent<CollectableThingUI>().cost <= cheese.isHave)
        {
            canBuy = true;
        }
        else
        {
            canBuy = false;
        }

        if (canBuy)
        {
            inventory.Collect(index);
            cheese.isHave -= inventory.GetArray()[index].GetComponent<CollectableThingUI>().cost;
            
            if (index == 1)
            {
                EnableRope();
            }
            // else if (index == 7)
            // {
            //     EnableAccordeon();
            // }
        }
    }
    
    public void EnableRope()
    {
        Rope.SetActive(true);
    }

    // public void EnableAccordeon()
    // {
    //     Accordeon.SetActive(true);
    // }
}