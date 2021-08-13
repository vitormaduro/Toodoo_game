using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBase : MonoBehaviour
{
    GameController gc;

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MovObj"))
        {
            gc.OpenSecretDoor(GameObject.FindGameObjectWithTag("SecretDoor"));
        }
    }
}
