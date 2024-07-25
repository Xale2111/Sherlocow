using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoOnCase : MonoBehaviour
{
    public Vector3 startPlace;
    public Vector2 casePosition;
    [SerializeField] private Vector2 blocSuperpose;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPlace;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = blocSuperpose+casePosition;
    }

}
