using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameObject secretDoorFx;
    private PuzzleBase puzzleScript;
    private PlayerCamera playerCamera;

    private void Start()
    {
        secretDoorFx = Resources.Load<GameObject>("SecretDoorFx");
        puzzleScript = GetComponent<PuzzleBase>();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCamera>();
    }

    public void OpenSecretDoor(GameObject door)
    {
        Instantiate(secretDoorFx, door.transform.position, secretDoorFx.transform.rotation);
        Destroy(door);
    }

    public void MarkEnemyKill(GameObject enemy)
    {
        for (int i = 0; i < puzzleScript.enemies.Count; i++)
        {
            if (puzzleScript.enemies[i].gameObject == enemy)
            {
                puzzleScript.enemies.Remove(enemy);
                puzzleScript.enemyCount--;

                if (puzzleScript.enemyCount == 0)
                {
                    if (puzzleScript.puzzleReward == PuzzleBase.PuzzleReward.SecretDoor)
                    {
                        OpenSecretDoor(puzzleScript.door);
                    }
                }
            }
        }
    }

    public IEnumerator FinishGame(bool victory)
    {
        if (!victory)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyBase>().SetHasWon();
            }

            yield return new WaitForSeconds(2);
            playerCamera.FadeTo(0);
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Scenes/main_scene");
        } else
        {
            yield return new WaitForSeconds(2);
            playerCamera.FadeTo(1);
            yield return new WaitForSeconds(1);
        }
    }
}
