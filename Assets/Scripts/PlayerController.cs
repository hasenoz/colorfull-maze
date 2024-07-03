using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Degiskenler
    Transform keyTransform;
    [SerializeField] float keyOffset = 5f; // Anahtarýn maksimum mesafesi
    [SerializeField] float moveSpeed = 2f; // Hareket hýzý - [SerializeField] Editörde görünmesini saðlar
    InputAction moveAction; // Hareket etme iþlemi
    InputAction interactAction; // Etkileþim iþlemi
    private bool hasKey = false; // Anahtarýn alýnýp alýnmadýðýný kontrol etmek için bayrak
    private bool keyGetable= false;


    // Start, MonoBehaviour oluþturulduktan sonra ilk çerçeveden önce bir kez çaðrýlýr
    void Start()
    {
        // Input sisteminden aksiyonlarý bul
        moveAction = InputSystem.actions.FindAction("Move");
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    // Update her çerçevede bir kez çaðrýlýr
    void Update()
    {
        // Karakteri moveAction'a göre hareket ettir
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        transform.Translate(moveValue * Time.deltaTime * moveSpeed);
    }

    
}
