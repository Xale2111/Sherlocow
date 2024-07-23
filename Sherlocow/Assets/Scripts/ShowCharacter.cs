using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCharacter : MonoBehaviour
{
    public Sprite character;
    public SpriteRenderer container;

    // Start is called before the first frame update
    void Start()
    {
        container = GetComponent<SpriteRenderer>();
        container.sprite = character;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
