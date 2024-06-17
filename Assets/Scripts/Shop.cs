using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private CollectableThingUI cheese;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject Rope;
    [SerializeField] private GameObject Accordion;
    [SerializeField] private TextMeshProUGUI _cheeseCount;
    
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
            
            _cheeseCount.text = "x" + cheese.isHave;
            
            if (index == 1)
            {
                DisableRope();
            }
            
            else if (index == 7)
            {
                DisableAccordion();
            }
        }
    }

    public void DisableRope()
    {
        Rope.GetComponent<Button>().interactable = false;
    }

    public void DisableAccordion()
    {
        Accordion.GetComponent<Button>().interactable = false;
    }
}