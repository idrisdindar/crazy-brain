using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform playerPos = null;
    [SerializeField] private float camZPos = 0;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(0, playerPos.position.y, camZPos);
    }
}
