using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnCase : MonoBehaviour
{

    [SerializeField] private CubeManager patate;
    [SerializeField] private GoOnCase goOnCase;
    [SerializeField] private CaseManager manage;
    [SerializeField]private int LatestX;
    [SerializeField]private int LatestY;
    [SerializeField] private bool surStart;
    [SerializeField] private bool surEnd;
    // Start is called before the first frame update
    void Start()
    {
        manage.cases[patate.patateX, patate.patateY].Item2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (patate.patateStartPos == false && patate.patateEndPos == false)
        {
            surEnd = false;
            surStart = false;
            if(manage.cases[patate.patateX, patate.patateY].Item2)
            {
                Debug.Log("Hé");
                goOnCase.casePosition = manage.cases[patate.patateX, patate.patateY].Item1;
                manage.cases[patate.patateX, patate.patateY].Item2 = false;
                manage.cases[LatestX, LatestY].Item2 = true;
                LatestX = patate.patateX;
                LatestY = patate.patateY;
            }
            else
            {
                patate.patateX = LatestX;
                patate.patateY = LatestY;
                foreach((Vector2,bool) tuple in manage.cases)
                {
                    if(tuple.Item2==true)
                    {
                        Debug.Log(tuple.Item1);
                    }
                }
            }
            

        }





        else if (patate.patateStartPos == true)
        {
            if (surStart == false)
            {
                if (manage.cases[3,1].Item2)
                            {
                                goOnCase.casePosition = manage.sq0.Item1;
                                manage.cases[3,1].Item2 = false;
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
            if(surEnd == false)
            {
                if (manage.cases[3,0].Item2)
                            {
                                goOnCase.casePosition = manage.sq10.Item1;
                                manage.cases[3,0].Item2 = false;
                                manage.cases[LatestX, LatestY].Item2 = true;
                                LatestX = 3;
                                LatestY = 0;
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
