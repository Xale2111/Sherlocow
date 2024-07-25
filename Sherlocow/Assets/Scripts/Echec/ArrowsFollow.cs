using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform rightArr;
    public Transform leftArr;
    public Transform upArr;
    public Transform downArr;
    public Vector3 positionA;
    public Vector3 moveArrow;
    public Vector3 diffRight;
    public Vector3 diffLeft;
    public Vector3 diffUp;
    public Vector3 diffDown;

    // Start is called before the first frame update
    void Start()
    {
        diffRight = (transform.position - rightArr.position)*-1;
        diffLeft = (transform.position - leftArr.position)*-1;
        diffUp = (transform.position - upArr.position)*-1;
        diffDown = (transform.position - downArr.position)*-1;

    }

    // Update is called once per frame
    void Update()
    {
        rightArr.position = diffRight + transform.position;
        leftArr.position = diffLeft + transform.position;
        upArr.position = diffUp + transform.position;
        downArr.position = diffDown + transform.position;
    }

}
