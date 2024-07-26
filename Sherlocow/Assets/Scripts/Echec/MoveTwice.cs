using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTwice: MonoBehaviour
{

    [SerializeField] private CubeManager patate;
    [SerializeField] private GoOnCase goOnCase;
    [SerializeField] private CaseManager manage;
    [SerializeField]private int LatestX;
    [SerializeField]private int LatestY;
    [SerializeField] private bool surStart;
    [SerializeField] private bool surEnd;
    [SerializeField] private int twiceAsX;
    [SerializeField] private int twiceAsY;
    [SerializeField] private int SecondLateX;
    [SerializeField] private int SecondLateY;
    // Start is called before the first frame update
    void Start()
    {
        manage.cases[patate.patateX, patate.patateY].Item2 = false;
        manage.cases[patate.patateX + twiceAsX, patate.patateY + twiceAsY].Item2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (patate.patateStartPos == false && patate.patateEndPos == false)
        {
            surEnd = false;
            surStart = false;
            if(patate.twiceOnStart)
            {
                goOnCase.casePosition = manage.cases[patate.patateX, patate.patateY].Item1;

                manage.cases[LatestX, LatestY].Item2 = true;
                manage.cases[SecondLateX, SecondLateY].Item2 = true;
                manage.cases[patate.patateX, patate.patateY].Item2 = false;
                manage.cases[3, 1].Item2 = false;
                LatestX = patate.patateX;
                LatestY = patate.patateY;
                SecondLateX = 3;
                SecondLateY = 1;
            }
            else if (manage.cases[patate.patateX, patate.patateY].Item2 && manage.cases[patate.patateX+twiceAsX, patate.patateY+twiceAsY].Item2)
            {
                goOnCase.casePosition = manage.cases[patate.patateX, patate.patateY].Item1;
                
                manage.cases[LatestX, LatestY].Item2 = true;
                manage.cases[SecondLateX, SecondLateY].Item2 = true;
                manage.cases[patate.patateX, patate.patateY].Item2 = false;
                manage.cases[patate.patateX + twiceAsX, patate.patateY + twiceAsY].Item2  = false;
                LatestX = patate.patateX;
                LatestY = patate.patateY;
                SecondLateX = patate.patateX + twiceAsX;
                SecondLateY = patate.patateY + twiceAsY;
                
            }
            else if(manage.cases[patate.patateX, patate.patateY].Item2| manage.cases[patate.patateX + twiceAsX, patate.patateY + twiceAsY].Item2)
            {
                if ((manage.cases[patate.patateX + twiceAsX, patate.patateY + twiceAsY] == manage.cases[LatestX, LatestY]) | (manage.cases[patate.patateX, patate.patateY] == manage.cases[SecondLateX, SecondLateY]))
                {
                    goOnCase.casePosition = manage.cases[patate.patateX, patate.patateY].Item1;

                    manage.cases[LatestX, LatestY].Item2 = true;
                    manage.cases[SecondLateX, SecondLateY].Item2 = true;
                    manage.cases[patate.patateX, patate.patateY].Item2 = false;
                    manage.cases[patate.patateX + twiceAsX, patate.patateY + twiceAsY].Item2 = false;
                    LatestX = patate.patateX;
                    LatestY = patate.patateY;
                    SecondLateX = patate.patateX + twiceAsX;
                    SecondLateY = patate.patateY + twiceAsY;

                }
                else
                {
                    patate.patateX = LatestX;
                    patate.patateY = LatestY;
                }
            }
            else
            {
                patate.patateX = LatestX;
                patate.patateY = LatestY;
            }
            

        }
        else if (patate.patateStartPos == true)
        {
            if (surStart == false)
            {
                if (manage.cases[3, 1].Item2)
                {
                    goOnCase.casePosition = manage.sq0.Item1;
                    manage.cases[3, 1].Item2 = false;
                    manage.cases[LatestX, LatestY].Item2 = true;
                    LatestX = 3;
                    LatestY = 1;
                }
                else
                {
                    patate.patateStartPos = false;
                    patate.patateX = LatestX;
                    patate.patateY = LatestY;
                }
            }
            surStart = true;

        }
        else if (patate.patateEndPos == true)
        {
            if (surEnd == false)
            {
                if (manage.cases[3, 0].Item2)
                {
                    goOnCase.casePosition = manage.cases[3, 0].Item1;

                    manage.cases[LatestX, LatestY].Item2 = true;
                    manage.cases[SecondLateX, SecondLateY].Item2 = true;
                    manage.cases[3, 0].Item2 = false;
                    manage.cases[2, 2].Item2 = false;
                    LatestX = patate.patateX;
                    LatestY = patate.patateY;
                    SecondLateX = 2;
                    SecondLateY = 2;
                }
                else
                {
                    patate.patateEndPos = false;
                    patate.patateX = LatestX;
                    patate.patateY = LatestY;
                }
            }
            surEnd = true;

        }
    }
}
