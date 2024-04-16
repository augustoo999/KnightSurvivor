using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject Explosion;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameObject exp = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(exp, 1f);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
