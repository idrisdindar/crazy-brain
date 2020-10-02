using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    internal static PlayerController instance = null;

    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float rotSpeed = 0f;
    [SerializeField] private AudioSource audioSource = null;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.instance.gameOver && UIHandler.instance.gameStarted)
        {
            if (TouchButtonHandler.direction == Direction.Right)
            {
                transform.Rotate(Vector3.forward * rotSpeed);
            }
            else if(TouchButtonHandler.direction == Direction.Left)
            {
                transform.Rotate(-Vector3.forward * rotSpeed);
            }

            transform.Translate(-Vector2.up * Time.deltaTime * moveSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Zombie" || collision.gameObject.tag == "Border")
        {
            LevelManager.instance.gameOver = true;
            UIHandler.instance.GameOver();
            audioSource.Play();
            moveSpeed = 0;
            rotSpeed = 0;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
