using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderHandler : MonoBehaviour
{
    [SerializeField] private bool addObstacle = false;
    [SerializeField] private List<GameObject> zombiePrefabs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (addObstacle)
        {
            int count = Random.Range(4, 9);
            for (int i = 0; i < count; i++)
            {
                Instantiate(zombiePrefabs[Random.Range(0, zombiePrefabs.Count)], new Vector2(Random.Range(-2.3f, 2.3f), Random.Range(transform.position.y-5, transform.position.y+5)), Quaternion.identity);
            }
            print("Zombi üretildi");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(PlayerController.instance.gameObject.transform.position.y - gameObject.transform.position.y) > 20)
        {
            Destroy(gameObject);
        }
    }
}
