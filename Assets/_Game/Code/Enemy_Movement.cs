using System;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public float patrolDistance = 5f;

    private float startPos;
    private bool movingRight = true;

    [SerializeField] private SpriteRenderer SlimeSpriteRenderer;

    
    
    void Start()
    {
        startPos = transform.position.x;
        
    }

    void Update()
    {
        SlimeSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= startPos + patrolDistance)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= startPos - patrolDistance)
                movingRight = true;
        }
        if(transform.position.x <= 5)
        {
            SlimeSpriteRenderer.flipX = false;
        }
        else
        {
            SlimeSpriteRenderer.flipX = true;
        }
    }
}

