using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 _direction;
    private Rigidbody2D rb;
    private SpriteRenderer srPlayer;

    [Header("Arrow Settings")]
    public Arrow arrow;
    public float ArrowRate;
    private float ArrowTimer;

    public Vector2 Direction 
    { 
        get => _direction; 
        set => _direction = value; 
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        srPlayer = GetComponent<SpriteRenderer>();
        
    }


    private void Update()
    {
        OnInput();
        SpawnArrow();

    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (_direction.x > 0)
        {
            srPlayer.flipX = false;
        }
        if (_direction.x < 0)
        {
            srPlayer.flipX = true;
        }
    }

    void OnMove()
    {
        rb.MovePosition(rb.position + _direction.normalized * speed * Time.deltaTime);
    }

    #endregion

    #region ArrowGenerator

    void SpawnArrow()
    {
        ArrowTimer += Time.deltaTime;
        if (ArrowTimer > ArrowRate)
        {
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Instantiate(arrow,transform.position, rotation);
            ArrowTimer = 0;
        }
    }

    #endregion
}
