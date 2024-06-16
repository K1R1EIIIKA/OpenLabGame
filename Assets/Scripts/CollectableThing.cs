using System;
using UnityEngine;

public class CollectableThing : MonoBehaviour
{
    [SerializeField] private Inventory InventoryScript;
    [SerializeField] int index;
    [SerializeField] private bool _isCheese;
    [SerializeField] private GameObject _hintCanvas;
    
    private bool _isTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_isCheese)
                CollectItem();
            else
            {
                _hintCanvas.SetActive(true);
                _isTriggered = true;
            }
        }
    }

    private void CollectItem()
    {
        InventoryScript.Collect(index);
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _hintCanvas.SetActive(false);
            _isTriggered = false;
        }
    }

    private void Update()
    {
        if (_isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            CollectItem();
        }
    }
}