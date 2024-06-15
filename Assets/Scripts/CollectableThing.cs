using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableThing : MonoBehaviour
{
    [SerializeField] private Inventory InventoryScript;
    [SerializeField] int index;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InventoryScript.Collect(index);
        }
            
    }
}
