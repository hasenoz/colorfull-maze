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

        // E�er etkile�im tu�una bas�ld�ysa ve anahtar varsa
        if (interactAction.WasPressedThisFrame() && hasKey)
        {
            ReleaseKey(); // Anahtar� b�rak
        }
    }

    // OnTriggerStay2D, bir Collider2D nesnesi tetikleyici ile temas halinde oldu�unda s�rekli �a�r�l�r
    private void OnTriggerStay2D(Collider2D collision)
    {
        // E�er �arp��an nesne anahtar etiketine sahipse ve etkile�im tu�una bas�lm��sa ve hen�z bir anahtar toplanmam��sa
        if (collision.gameObject.CompareTag("key") && interactAction.IsPressed() && keyTransform == null)
        {
            keyTransform = collision.transform; // Anahtar�n transformunu kaydet
            keyTransform.parent = transform; // Anahtar�n ebeveynini bu nesne yap
            hasKey = true;//anahtar� ald�

        }
    }

    // Anahtar� b�rakma i�levi
    void ReleaseKey()
    {
        keyTransform.parent = null; // Anahtar�n ebeveyn ba��n� kald�r
        keyTransform = null; // Anahtar�n referans�n� s�f�rla
        hasKey = false; // anahtar� b�rakt�
    }
}
