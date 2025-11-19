using UnityEngine;

public class ScrollBackgroundQuad : MonoBehaviour
{
    
    
    private Renderer rend;
    void Start()
    {
        
        rend = GetComponent<Renderer>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * 0.25f;
        rend.sharedMaterials[1].SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
