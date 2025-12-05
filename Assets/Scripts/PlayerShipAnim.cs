using UnityEngine;
using System.Collections;

public class PlayerShipAnim : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites; // Assign your sprites in the Inspector
    private int currentSpriteIndex = 0;
    [SerializeField] float seconds;
    


    void Start()
    {
        // Get the SpriteRenderer component if not assigned in Inspector
        
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        StartCoroutine(ChangeSpriteRoutine());


    }

    IEnumerator ChangeSpriteRoutine()
    {
        while (true) // Loop indefinitely
        {
            spriteRenderer.sprite = sprites[currentSpriteIndex];
            currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length; // Cycle through sprites
        

            yield return new WaitForSeconds(seconds);

        }
    }
}
