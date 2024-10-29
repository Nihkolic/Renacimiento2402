using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorChangeOnClick : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Coroutine colorChangeCoroutine;
    public int life = 5;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; life = 5;
    }
    void Update()
    {
        if(life<= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnMouseDown()
    {
        Debug.Log("clock");
        if (colorChangeCoroutine != null)
        {
            StopCoroutine(colorChangeCoroutine);
        }
        colorChangeCoroutine = StartCoroutine(ChangeColor());
        life--;
    }

    private IEnumerator ChangeColor()
    {
        spriteRenderer.color = Color.white; // Change color to white
        yield return new WaitForSeconds(0.15f); // Wait for half a second
        spriteRenderer.color = originalColor; // Change back to original color
    }
}