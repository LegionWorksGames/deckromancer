using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : Actors
{
    Animator animator;
    [SerializeField] int maxHealth;
    [SerializeField] Card[] cardDrops;
    [SerializeField] Vector2[] nodes;
    [SerializeField] int speed;
    [SerializeField] float dropChance = 0.5f;
    int activeNode = 0;
    bool hasMoved;
    private int currentHealth;
    Vector2 dir = Vector2.zero;
    //Death Effect

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        float tickSpeed = speed * Time.deltaTime;
        hasMoved = false;
    }

    // Update is called once per frame
    void Update()
    {
        FindNextPosAndGo();
    }

    void FindNextPosAndGo()
    {
        Vector2 currentPosition = transform.position;

        if (nodes.Length > 1)
        {
            if (Vector2.Distance (transform.position, nodes[activeNode]) < 1.1f)
            {
                activeNode = (activeNode < nodes.Length - 1) ? activeNode + 1 : 0;
                hasMoved = false;
            }

            //transform.position = Vector2.MoveTowards(transform.position, nodes[activeNode], tickSpeed);
            dir = nodes[activeNode] - (Vector2)transform.position;
        }
        else
        {
            Debug.LogWarning("hewp mistew obama " + this.name + " can't find nodes uwu");
        }

        if (transform.position.y < nodes[activeNode].y && !hasMoved)
        { 
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + Vector2.up, 1);
            if((Vector2)transform.position == currentPosition + Vector2.up)
            {
                hasMoved = true;
            }
        }

        if (transform.position.x < nodes[activeNode].x && !hasMoved)
        {
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + Vector2.right, 1);
            if ((Vector2)transform.position == currentPosition + Vector2.right)
            {
                hasMoved = true;
            }
        }

        if (transform.position.y > nodes[activeNode].y && !hasMoved)
        {
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + Vector2.left, 1);
            if ((Vector2)transform.position == currentPosition + Vector2.left)
            {
                hasMoved = true;
            }
        }

        if (transform.position.x > nodes[activeNode].x && !hasMoved)
        {
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + Vector2.down, 1);
            if ((Vector2)transform.position == currentPosition + Vector2.down)
            {
                hasMoved = true;
            }
        }
    }

    void Death()
    {
        if(cardDrops.Length > 0)
        {
            float n = Random.Range(0, 1);
            if (n <= dropChance)
            {
                int i = Random.Range(0, cardDrops.Length);
                //Spawn cardDrops[i]
                //Destroy This
            }
        }

    }

    //brett I don't know how the animator works in practice

    void ChangeDirection(float h, float v)
    {
        animator.SetFloat("horizontal", h);
        animator.SetFloat("vertical", v);
    }


}
