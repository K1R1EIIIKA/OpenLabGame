using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kirill.ScriptPlaces
{
    public class ThrowableRock : MonoBehaviour
    {
        [SerializeField] private Inventory _inventoryScript;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                CollectItem();
            }
        }
        
        private void CollectItem()
        {
            _inventoryScript.Collect(0);
            Destroy(gameObject);
        }
    }
}