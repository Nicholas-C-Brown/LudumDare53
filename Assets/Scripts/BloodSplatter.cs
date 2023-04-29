using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatter : MonoBehaviour
{

    [SerializeField] SpriteRenderer spriteRenderer;
    private float timePassed;
    private float deathTime = 5f;
    
    void Start()
    {
        timePassed = 0f;
        Destroy(gameObject, deathTime);
    }

    private void Update()
    {
        spriteRenderer.color = spriteRenderer.color = new Color(1, 1, 1, 1 - (timePassed / deathTime));
        timePassed += Time.deltaTime;
    }


}
