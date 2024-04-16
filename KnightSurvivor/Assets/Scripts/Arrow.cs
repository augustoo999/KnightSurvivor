using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rbArrow;
    public float speedArrow;

    void Start()
    {
        rbArrow = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveArrow();
    }

    void MoveArrow()
    {
        Vector2 direction = transform.position + transform.right * speedArrow * Time.deltaTime;
        rbArrow.MovePosition(direction);
    }

}
