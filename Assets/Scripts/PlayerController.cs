using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Degiskenler
    Transform keyTransform;
    [SerializeField] float keyOffset = 5f; // Anahtar�n maksimum mesafesi
    [SerializeField] float moveSpeed = 2f; // Hareket h�z� - [SerializeField] Edit�rde g�r�nmesini sa�lar
    InputAction moveAction; // Hareket etme i�lemi
    InputAction interactAction; // Etkile�im i�lemi
    private bool hasKey = false; // Anahtar�n al�n�p al�nmad���n� kontrol etmek i�in bayrak
    private bool keyGetable= false;


    // Start, MonoBehaviour olu�turulduktan sonra ilk �er�eveden �nce bir kez �a�r�l�r
    void Start()
    {
        // Input sisteminden aksiyonlar� bul
        moveAction = InputSystem.actions.FindAction("Move");
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    // Update her �er�evede bir kez �a�r�l�r
    void Update()
    {
        // Karakteri moveAction'a g�re hareket ettir
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        transform.Translate(moveValue * Time.deltaTime * moveSpeed);
    }

    
}
