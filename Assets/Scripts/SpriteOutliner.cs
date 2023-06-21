using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOutliner : MonoBehaviour
{
    Material originalMat;
    SpriteRenderer spriteRenderer;
    [SerializeField] private Material outlineMat;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        originalMat = spriteRenderer.material;
    }

    private void OnMouseEnter()
    {
        spriteRenderer.material = outlineMat;
    }

    private void OnMouseExit()
    {
        spriteRenderer.material = originalMat;
    }
}
