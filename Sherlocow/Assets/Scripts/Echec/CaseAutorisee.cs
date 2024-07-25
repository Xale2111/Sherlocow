using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseAutoriseeScript : MonoBehaviour
{
    public Vector2 positionO;
    public Vector2 tailleGrille;
    public bool debut = true;
    
    // Start is called before the first frame update
    void Start()
    {
        debut = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(debut && collision.tag == "DropZone")
        {
            positionO = collision.transform.position;
            tailleGrille = collision.transform.localScale;
            debut = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(positionO.x + tailleGrille.x + 1 < transform.position.x | positionO.y + tailleGrille.y + 1 <= transform.position.y)
        {
            transform.position = positionO;
        }
    }
}
