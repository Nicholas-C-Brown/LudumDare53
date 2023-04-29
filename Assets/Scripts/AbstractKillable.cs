using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractKillable : MonoBehaviour
{

    [SerializeField] protected AudioClip deathSound;
    [SerializeField] protected int points;
    [SerializeField] protected float mass;
    
    public abstract void Perish();

    public float GetMass()
    {
        return mass;
    }

    public int GetPoints()
    {
        return points;
    }



}
