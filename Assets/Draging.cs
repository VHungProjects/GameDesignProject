using UnityEngine;

public class DraggableNote : MonoBehaviour
{
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
        isDragging = true;
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
        Instantiate(gameObject, startPosition, Quaternion.identity);
    }
}
