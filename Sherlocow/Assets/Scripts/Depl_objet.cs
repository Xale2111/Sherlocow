using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depl_objet : MonoBehaviour
{
    public Collider2D objet;
    public Vector2 positionZone;
    public Vector2 positionO;
    public bool onZone = false; 

    const string DROP_ZONE_TAG = "DropZone";

    // Start is called before the first frame update
    void Start()
    {
        positionO = transform.position;
        Debug.Log("?");
        onZone = false;
    }
    private void Update() 
    {

    }

    // Update is called once per frame
    private void OnMouseDrag()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        transform.position = worldPos;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DropZone")
        {
            onZone = true;
        }
        positionZone =  collision.transform.position;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "DropZone")
        {
            onZone = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.transform.position);
    }
    private void OnMouseUp()
    {
        if (onZone)
        {
            transform.position = positionZone;
            Debug.Log(transform.position);
        }
        else
        {
            transform.position = positionO;
        }
    }
}
