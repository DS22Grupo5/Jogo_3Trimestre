using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite new_sprite;
    public SpriteRenderer spriteRenderer;
    public void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
    } 

    public void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 9)
        {
            spriteRenderer.sprite = new_sprite;
        }
    }
}
