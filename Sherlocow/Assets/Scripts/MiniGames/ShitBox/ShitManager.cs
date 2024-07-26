using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class ShitManager : MonoBehaviour
{
    [SerializeField] GameObject shitBoxe1;
    [SerializeField] GameObject shitBoxe2;
    [SerializeField] GameObject shitBoxe3;
    
    VisualShits[] shitboxes1;
    VisualShits[] shitboxes2;
    VisualShits[] shitboxes3;
    int wrongBoxe;

    private bool allboxesAreFull;

    public bool BoxesNotEmpty
    {
        get { return allboxesAreFull; }
    }


    public int WrongBoxeId
    {
        get { return wrongBoxe; }
    }


    private void Awake()
    {
        shitboxes1 = shitBoxe1.GetComponentsInChildren<VisualShits>();
        shitboxes2 = shitBoxe2.GetComponentsInChildren<VisualShits>();
        shitboxes3 = shitBoxe3.GetComponentsInChildren<VisualShits>();        
        wrongBoxe = Random.Range(0,3); //=> 0 / 1 / 2        
    }

    private void Update()
    {        
        AllBoxesHasShit();
    }

    public int[] GetNumberAllVisibleShits() 
    { 
        int[] numberOfVisibleShits = new int[3];

        numberOfVisibleShits[0] = GetNumberOfShitsInBoxe(shitboxes1);
        numberOfVisibleShits[1] = GetNumberOfShitsInBoxe(shitboxes2);
        numberOfVisibleShits[2] = GetNumberOfShitsInBoxe(shitboxes3);
        return numberOfVisibleShits;
    }

    private void AllBoxesHasShit() 
    {
        int[] allBoxes = GetNumberAllVisibleShits();
        if (allBoxes[0] != 0 && allBoxes[1] != 0 && allBoxes[2] != 0)
        {
            allboxesAreFull = true;
        }
        else
        {
            allboxesAreFull = false;
        }
    }


    public void DestroyAllShitCollider()
    {
        DestroyShitCollider(shitBoxe1);
        DestroyShitCollider(shitBoxe2);
        DestroyShitCollider(shitBoxe3);
    }

    private void DestroyShitCollider(GameObject shitboxe)
    {
        foreach (var collider in shitboxe.GetComponentsInChildren<BoxCollider2D>())
        {
            Destroy(collider);
        }
    }

    private int GetNumberOfShitsInBoxe(VisualShits[] shitbox)
    {
        int shitInBoxe = 0;
        foreach (var shit in shitbox)
        {
            if (shit.IsActive)
            {
                shitInBoxe++;
            }
        }

        return shitInBoxe;
    }
}

