using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Test");

        if (collision.CompareTag("key") && !collision.GetComponent<Key>().IsPickedUp())
        {
            Debug.Log("Sildi");
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }
}
