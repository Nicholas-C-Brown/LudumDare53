using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : AbstractKillable
{
    [SerializeField] GameObject bloodPrefab;
    public override void Perish()
    {
        SoundManager.PlaySound(deathSound);
        Instantiate(bloodPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
