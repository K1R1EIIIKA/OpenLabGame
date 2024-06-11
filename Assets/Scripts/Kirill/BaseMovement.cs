using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        Move();
    }
    
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * (speed * Time.deltaTime);
        transform.Translate(movement, Space.World);
    }
}
