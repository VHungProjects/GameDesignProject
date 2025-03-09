using UnityEngine;

public class NotePlaceholder : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color highlightColor = Color.yellow; // Color when hovered over

    private bool isOccupied = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
            spriteRenderer.color = new Color(0, 0, 0, 0); // Invisible initially
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Note") && !isOccupied)
        {
            if (spriteRenderer != null)
                spriteRenderer.color = highlightColor; // Highlight effect
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Note") && !isOccupied)
        {
            if (spriteRenderer != null)
                spriteRenderer.color = new Color(0, 0, 0, 0); // Back to invisible
        }
    }

    public void PlaceNote()
    {
        isOccupied = true;
        if (spriteRenderer != null)
            spriteRenderer.color = Color.white; // Becomes visible
    }
}