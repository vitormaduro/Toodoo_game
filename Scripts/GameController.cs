using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameObject secretDoorFx;
    PuzzleBase puzzleScript;

    private void Start()
    {
        secretDoorFx = Resources.Load<GameObject>("SecretDoorFx");
        puzzleScript = GetComponent<PuzzleBase>();
    }

    public void OpenSecretDoor(GameObject door)
    {
        Instantiate(secretDoorFx, door.transform.position, secretDoorFx.transform.rotation);
        Destroy(door);
    }

    public void MarkEnemyKill(GameObject enemy)
    {
        for(int i = 0; i < puzzleScript.enemies.Count; i++)
        {
            if(puzzleScript.enemies[i].gameObject == enemy)
            {
                puzzleScript.enemies.Remove(enemy);
                puzzleScript.enemyCount--;

                if(puzzleScript.enemyCount == 0)
                {
                    if(puzzleScript.puzzleReward == PuzzleBase.PuzzleReward.SecretDoor)
                    {
                        OpenSecretDoor(puzzleScript.door);
                    }
                }
            }
        }
    }

    public void FinishGame()
    {

    }

}
