using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // degiskenler

    // InputAction yeni bir input alma classý oklar ve wasd üzerinden calýsýyor
    InputAction moveAction;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        // moveActiona göre karakteri hareket ettir
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        transform.Translate(moveValue*Time.deltaTime);
        
    }
}
