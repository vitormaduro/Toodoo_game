using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBase : MonoBehaviour
{
    public enum PuzzleType
    {
        KillEnemies,
        PlaceObject
    }

    public enum PuzzleReward
    {
        SecretDoor
    }

    GameController gc;

    public PuzzleType puzzleType;
    public PuzzleReward puzzleReward;
    public GameObject door;
    public GameObject key;
    public List<GameObject> enemies;

    public int enemyCount;

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        enemyCount = enemies.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == key)
        {
            gc.OpenSecretDoor(door);
        }
    }
}
