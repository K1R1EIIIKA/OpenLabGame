using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject[] collectableThings;

    public void Collect(int index)
    {
        collectableThings[index].GetComponent<CollectableThingUI>().isHave = true;
    }
}
