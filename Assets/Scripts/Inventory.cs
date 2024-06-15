using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject[] collectableThings;

    public void Collect(int index)
    {
        collectableThings[index].GetComponent<CollectableThingUI>().isHave += 1;
    }

    public GameObject[] GetArray()
    {
        return collectableThings;
    }
}