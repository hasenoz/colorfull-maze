using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // degiskenler

    // InputAction yeni bir input alma class� oklar ve wasd �zerinden cal�s�yor
    InputAction moveAction;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        // moveActiona g�re karakteri hareket ettir
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        transform.Translate(moveValue*Time.deltaTime);
        
    }
}
