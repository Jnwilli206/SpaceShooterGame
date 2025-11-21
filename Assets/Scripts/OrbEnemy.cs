
using UnityEngine;
using System.Collections;

public class OrbEnemy : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites; // Assign your sprites in the Inspector
    private int currentSpriteIndex = 0;
    [SerializeField] float seconds;
    private CircleCollider2D circleCollider;


    void Start()
    {
        // Get the SpriteRenderer component if not assigned in Inspector
        circleCollider = GetComponent<CircleCollider2D>();
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

            if (currentSpriteIndex == 3 || currentSpriteIndex == 4)
            {
                circleCollider.radius = (0.65f);
            }
            else
            {
                circleCollider.radius = 0.25f;
            }
        

            yield return new WaitForSeconds(seconds);

        }
    }
}
