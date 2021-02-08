using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static float speed;
    public StateGame state;
    public GameObject[] prefabs;
    public Transform spawner;
    private float spawnDelay = 1.1f;
    private Box box;



    private void OnGameStateChanged(StateGame obj)
    {
        state = obj;

        switch (obj)
        {
            case StateGame.MainMenu:
                break;
            case StateGame.Play:
                break;
            case StateGame.Pause:
                break;
            case StateGame.Lose:
                foreach (Transform child in transform) Destroy(child.gameObject);
                speed = 0f;
                break;
            case StateGame.Setting:
                break;
            default:
                break;
        }
    }

    private void OnEnable()
    {
        GameState.GameStateChanged += OnGameStateChanged;
    }

    private void OnDisable()
    {
        GameState.GameStateChanged -= OnGameStateChanged;
    }

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0.0f, spawnDelay);
    }


    public void Spawn()
    {
        if (state != StateGame.Play)
            return;

        GameObject newBox = Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(spawner.position.x, spawner.position.y, 0), Quaternion.identity);

        Box box = newBox.GetComponent<Box>();
        box.speed = 6f;
        newBox.transform.SetParent(transform);
    }
}

