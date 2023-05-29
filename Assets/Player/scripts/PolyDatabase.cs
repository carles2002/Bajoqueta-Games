using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PolyDatabase : ScriptableObject
{
    public Poly[] polySkin;
    public int polysCount
    {
        get
        {
            return polySkin.Length;
        }
    }
    public Poly GetPoly(int index)
    {
        return polySkin[index];
    }
}
