using UnityEngine;

public class DraggableNote : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip beginDragClip;
    
    private Vector3 startPosition;
    private bool isDragging = false;
    private NotePlaceholder closestPlaceholder;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
    }

    void OnMouseDown()
    {
        if (!isDragging) // Play sound only the first time
        {
            PlaySound(beginDragClip); // Fixed variable name
            isDragging = true;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        if (closestPlaceholder != null)
        {
            closestPlaceholder.PlaceNote();
            RespawnNote();
            Destroy(gameObject);
        }
        else
        {
            transform.position = startPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Placeholder"))
        {
            closestPlaceholder = other.GetComponent<NotePlaceholder>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Placeholder") && closestPlaceholder == other.GetComponent<NotePlaceholder>())
        {
            closestPlaceholder = null;
        }
    }

    void RespawnNote()
    {
        GameObject newNote = Instantiate(gameObject, startPosition, Quaternion.identity);
        Destroy(newNote.GetComponent<AudioSource>()); // Remove extra AudioSource if needed
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
