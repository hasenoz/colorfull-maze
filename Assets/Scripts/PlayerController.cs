using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // degiskenler

    // Hareket h�z� - [SerializeField] Edit�rde g�r�nmesini sa�lar
    [SerializeField] float moveSpeed = 2f;
    // InputAction yeni bir input alma class� oklar ve wasd �zerinden cal�s�yor
    InputAction moveAction;
    InputAction collectAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        collectAction = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        // moveActiona g�re karakteri hareket ettir
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        transform.Translate(moveValue * Time.deltaTime * moveSpeed);
        CollectKey();

    }

    void CollectKey()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log("Vurdum");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("key") && collectAction.IsPressed())
        {
            collision.transform.parent = transform;
        }
    }
}
