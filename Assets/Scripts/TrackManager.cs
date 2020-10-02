using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrackManager : MonoBehaviour
{
    [SerializeField] private GameObject borderPrefab = null;
    [SerializeField] private int distanceToAdd = 0;

    private int previousPos = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((int)PlayerController.instance.gameObject.transform.position.y % 10 == 0 && (int)PlayerController.instance.gameObject.transform.position.y != previousPos)
        {
            previousPos = (int)PlayerController.instance.gameObject.transform.position.y;
            Instantiate(borderPrefab, new Vector2(0, distanceToAdd - 10), Quaternion.identity);
            distanceToAdd -= 10;
        }
    }
}
