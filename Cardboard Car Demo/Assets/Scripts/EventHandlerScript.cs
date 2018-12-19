using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class EventHandlerScript : MonoBehaviour
{
    // Original color of the yacht's gunwale
    Color originalColor;

    // Renderer component of the yacht object
    Renderer originalRenderer;

    void Start()
    {
        // Obtain reference to originalRenderer
        originalRenderer = GetComponent<Renderer>();

        // Obtain originalColor
        originalColor = originalRenderer.materials[0].color;

        // Reset gunwale's color
        SetGazedAt(false);
    }

    public void SetGazedAt(bool gazedAt)
    {
        // If true is passed set gunwale's color to green; if false is passed set it
        // back to its original color
        originalRenderer.materials[0].color = gazedAt ? Color.green : originalColor;
    }
}