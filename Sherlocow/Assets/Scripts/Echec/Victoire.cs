using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victoire : MonoBehaviour
{
    [SerializeField] private Vector3 arrivee;
    [SerializeField] private GameObject fin;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position==arrivee)
        {
            Debug.Log("BRAVO!");
            Object.Destroy(fin);
        }
    }
}
