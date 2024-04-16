using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rbEnemy;
    public SpriteRenderer srEnemySprite;
    public float speed;
    public GameObject player;
    public Vector2 enemyDirection;

    private void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }



    private void Update()
    {
        enemyDirection = player.transform.position - transform.position;

        if (enemyDirection.x > 0)
        {
            srEnemySprite.flipX = false;
        }
        if (enemyDirection.x < 0)
        {
            srEnemySprite.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        rbEnemy.MovePosition(rbEnemy.position + enemyDirection.normalized * speed * Time.deltaTime);
    }

}
