using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameObjectMovement : MonoBehaviour
{
    public Vector3 speedNDir;

    private void Update()
    {
        transform.Translate(speedNDir, Space.Self);
    }
}
