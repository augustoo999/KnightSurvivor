using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D rbArrow;
    public float speedArrow;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void FixedUpdate()
    {
        Vector2 direction = transform.position + transform.right * speedArrow * Time.deltaTime;
        rbArrow.MovePosition(direction);
    }

}
