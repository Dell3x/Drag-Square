using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Box : MonoBehaviour
{

    private GameState gameState;
    [SerializeField]private Vector2 direction;
    public float speed;
    [SerializeField] private Rigidbody2D rigidbody2d;

    private void OnEnable()
    {
        GameState.GameStateChanged += OnGameStateChanged;
    }

    private void OnGameStateChanged(StateGame obj)
    {
        switch (obj)
        {
            case StateGame.MainMenu:
                break;
            case StateGame.Play:
                speed = 5f;
                break;
            case StateGame.Pause:
                break;
            case StateGame.Lose:
                speed = 0f;
                break;
            case StateGame.Setting:
                break;
            default:
                break;
        }
    }

    private void OnDisable()
    {
        GameState.GameStateChanged -= OnGameStateChanged;
    }

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        gameState = FindObjectOfType<GameState>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("FinishLine"))
        {
            Destroy(gameObject);
            gameState.LostHealth();
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(direction.normalized * speed);
    }
}
