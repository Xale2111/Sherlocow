using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public ArrowClick up;
    public ArrowClick down;
    public ArrowClick left;
    public ArrowClick right;

    public int patateX;
    public int patateY;
    public bool patateStartPos;
    public bool patateEndPos;
    public GoOnCase goOnCase;
    [SerializeField] private CaseManager manage;
    [SerializeField] private bool doubleHorizontal;
    [SerializeField] private bool canGoOn1Case;
    [SerializeField] private int upValue;
    [SerializeField] private int downValue;
    [SerializeField] private int leftValue;
    [SerializeField] private int rightValue;
    public bool twiceOnStart;
    public bool twiceOnEnd;
    // Start is called before the first frame update
    void Start()
    {
        twiceOnEnd = false;
        twiceOnStart = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(!patateStartPos && !patateEndPos && !twiceOnStart && !twiceOnEnd)
        {
            if (up.clickOn == true)
                    {
                        Debug.Log("click");
                        twiceOnStart = false;
                        twiceOnEnd = false;
                        if ((patateStartPos == false && patateEndPos == false) && patateY < upValue)
                        {
                            patateY += 1;
                        }
                    }
                    if (down.clickOn == true)
                    {
                        Debug.Log("click");
                        twiceOnStart = false;
                        twiceOnEnd = false;
                if ((patateStartPos == false && patateEndPos == false) && patateY > downValue)
                        {
                            patateY -= 1;
                        }
                    }
        }
        
        if (left.clickOn == true && !twiceOnStart)
        {
            Debug.Log("click");
            twiceOnEnd = false;
            if (patateX == 0 && patateY == 0 && canGoOn1Case)
            {
                patateStartPos = true;
                patateY = 1;
                patateX = 3;
            }
            else if (patateEndPos)
            {
                if (manage.cases[2,2].Item2|doubleHorizontal)
                {
                    patateX = 2;
                    patateY = 2;
                    patateEndPos = false;
                }
                
            }
            else if ((patateStartPos == false && patateEndPos == false && patateX > leftValue)|(patateX==1 && patateY==0 && doubleHorizontal))
            {
                if(doubleHorizontal && patateX == 1 && patateY == 0)
                {
                    twiceOnStart = true;
                }
                patateX -= 1;
            }
        }
        if (right.clickOn == true && !twiceOnEnd)
        {
            Debug.Log("click");
            twiceOnStart = false;
            if (patateX == 2 && patateY == 2 && canGoOn1Case)
            {
                patateEndPos = true;
                if(doubleHorizontal)
                {
                    twiceOnEnd = true;
                }
                
                patateY = 0;
                patateX = 3;
            }
            else if (patateStartPos)
            {
                if (manage.cases[0,0].Item2)
                {
                    patateX = 0;
                                    patateY = 0;
                                    patateStartPos = false;
                }
                
            }
            else if ((patateStartPos == false && patateEndPos == false) && patateX < rightValue)
            {
                patateX += 1;
            }
        }
        up.clickOn = false;
        down.clickOn = false;
        left.clickOn = false;
        right.clickOn = false;
    }

}

