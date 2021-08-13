using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameObject secretDoorFx;

    private void Start()
    {
        secretDoorFx = Resources.Load<GameObject>("SecretDoorFx");
    }

    public void OpenSecretDoor(GameObject door)
    {
        Instantiate(secretDoorFx, door.transform.position, secretDoorFx.transform.rotation);
        Destroy(door);
    }

}
