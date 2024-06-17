using UnityEngine;

namespace Kirill.ScriptPlaces
{
    public class OpenShop : MonoBehaviour
    {
        [SerializeField] private GameObject _hintCanvas;
        [SerializeField] private GameObject _shopCanvas;
        
        private bool _isTriggered;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _hintCanvas.SetActive(true);
                _isTriggered = true;
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _hintCanvas.SetActive(false);
                _isTriggered = false;
            }
        }
        
        private void Update()
        {
            if (_isTriggered && Input.GetKeyDown(KeyCode.E))
            {
                OpenShopCanvas();
            }
        }

        private void OpenShopCanvas()
        {
            _shopCanvas.SetActive(true);
        }
    }
}