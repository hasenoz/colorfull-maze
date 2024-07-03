using UnityEngine;
using UnityEngine.InputSystem;

public class Key : MonoBehaviour
{
    private bool isPickedUp = false;
    bool inRange = false;
    InputAction inputAction;
    Transform playerTransform;

    private void Start()
    {
        inputAction = InputSystem.actions.FindAction("Interact");
    }

    private void Update()
    {
        if (inRange && !isPickedUp && inputAction.IsPressed())
        {
            transform.parent = playerTransform;
            isPickedUp = true;
        }
        else if(isPickedUp && inputAction.IsPressed())
        {
            transform.parent = null;
            isPickedUp = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
            playerTransform = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
            playerTransform = null;

        }
    }

    public bool IsPickedUp()
    {
        return isPickedUp;
    }
}
