using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CaseManager : MonoBehaviour
{
    
    public (Vector2,bool)[,] cases = new (Vector2,bool)[4,3];
    public (Vector2, bool) sq1;
    public (Vector2, bool) sq0;
    public (Vector2, bool) sq2;
    public (Vector2, bool) sq3;
    public (Vector2, bool) sq4;
    public (Vector2, bool) sq5;
    public (Vector2, bool) sq6;
    public (Vector2, bool) sq7;
    public (Vector2, bool) sq8;
    public (Vector2, bool) sq9;
    public (Vector2, bool) sq10;
    public bool sq1Bool;
    public bool sq0Bool;
    public bool sq2Bool;
    public bool sq3Bool;
    public bool sq4Bool;
    public bool sq5Bool;
    public bool sq6Bool;
    public bool sq7Bool;
    public bool sq8Bool;
    public bool sq9Bool;
    public bool sq10Bool;



    // Start is called before the first frame update
    void Start()
    {
        sq1 = (new Vector2(x: 0, y: 0), true);
        sq2 = (new Vector2(x: 3, y: 0), true);
        sq3 = (new Vector2(x: 3, y: 3), true);
        sq4 = (new Vector2(x: 6, y: 0), true);
        sq5 = (new Vector2(x: 6, y: 3), true);
        sq6 = (new Vector2(x: 3, y: 6), true);
        sq7 = (new Vector2(x: 6, y: 6), true);
        sq8 = (new Vector2(x: 0, y: 3), true);
        sq9 = (new Vector2(x: 0, y: 6), true);
        sq0 = (new Vector2(x: -3,y: 0), true);
        sq10 = (new Vector2(x: 9,y: 6), true);
        cases[0,0] = sq1;
        cases[1,0] = sq2;
        cases[1,1] = sq3;
        cases[2,0] = sq4;
        cases[2,1] = sq5;
        cases[1,2] = sq6;
        cases[2,2] = sq7;
        cases[0,1] = sq8;
        cases[0,2] = sq9;
        cases[3, 0] = sq10;
        cases[3, 1] = sq0;
        sq1Bool = cases[0, 0].Item2;
        sq2Bool = cases[1, 0].Item2;
        sq3Bool = cases[1, 1].Item2;
        sq4Bool = cases[2, 0].Item2;
        sq5Bool = cases[2, 1].Item2;
        sq6Bool = cases[1, 2].Item2;
        sq7Bool = cases[2, 2].Item2;
        sq8Bool = cases[0, 1].Item2;
        sq9Bool = cases[0, 2].Item2;
        sq10Bool = cases[3, 0].Item2;
        sq0Bool = cases[3, 1].Item2;

    }

// Update is called once per frame
void Update()
    {
       
    }      

}
