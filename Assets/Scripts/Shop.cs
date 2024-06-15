using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private CollectableThingUI cheese;
    [SerializeField] private TextMeshProUGUI cheeseCount;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject Rope;
    private bool canBuy;
    private int currentCost = 999;
    [SerializeField] private Animator animator;

    private void Update()
    {
        cheeseCount.text = $"Ñûð: {cheese.isHave.ToString()}";
    }

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
        }
        else
        {
            animator.SetBool("cantBuy", true);
        }
    }


    public void EnableThing()
    {
        Rope.SetActive(true);
    }

    public void DisableCantBuyAnimator()
    {
        animator.SetBool("cantBuy", false);
    }
}