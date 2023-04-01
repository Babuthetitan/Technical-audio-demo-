using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExterminatorMove : MonoBehaviour
{
    Transform player;
    [SerializeField] float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = new Vector2(player.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, playerPos, movementSpeed * Time.deltaTime);

        if (transform.position.x - playerPos.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        else if (transform.position.x - playerPos.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
