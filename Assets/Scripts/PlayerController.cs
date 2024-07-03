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

        // Eðer etkileþim tuþuna basýldýysa ve anahtar varsa
        if (interactAction.WasPressedThisFrame() && hasKey)
        {
            ReleaseKey(); // Anahtarý býrak
        }
    }

    // OnTriggerStay2D, bir Collider2D nesnesi tetikleyici ile temas halinde olduðunda sürekli çaðrýlýr
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Eðer çarpýþan nesne anahtar etiketine sahipse ve etkileþim tuþuna basýlmýþsa ve henüz bir anahtar toplanmamýþsa
        if (collision.gameObject.CompareTag("key") && interactAction.IsPressed() && keyTransform == null)
        {
            keyTransform = collision.transform; // Anahtarýn transformunu kaydet
            keyTransform.parent = transform; // Anahtarýn ebeveynini bu nesne yap
            hasKey = true;//anahtarý aldý

        }
    }

    // Anahtarý býrakma iþlevi
    void ReleaseKey()
    {
        keyTransform.parent = null; // Anahtarýn ebeveyn baðýný kaldýr
        keyTransform = null; // Anahtarýn referansýný sýfýrla
        hasKey = false; // anahtarý býraktý
    }
}
