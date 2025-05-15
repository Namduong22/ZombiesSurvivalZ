using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 movementDirection;

    //void Start()
    //{
    //    Destroy(gameObject, 3f);
    //}

    void Update()
    {
        if (movementDirection == Vector3.zero) return;
        transform.position += movementDirection * Time.deltaTime;
    }

    public void SetMovementDiretion(Vector3 direction) 
    { 
        movementDirection = direction;
    }
}
