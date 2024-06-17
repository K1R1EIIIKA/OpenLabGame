using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject[] collectableThings;

    public void Collect(int index, int count = 1)
    {
        collectableThings[index].GetComponent<CollectableThingUI>().isHave += count;
    }

    public GameObject[] GetArray()
    {
        return collectableThings;
    }
}