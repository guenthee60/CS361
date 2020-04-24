using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pacman : MonoBehaviour
{

    public float speed = 4f;
    private Vector2 direction = Vector2.zero;


    private NodePellets currentNode;


    void Start ()
    {
        NodePellets node = GetNodeAtPosition(transform.localPosition);

        if (node != null) 
        {
            currentNode = node;
            Debug.Log(currentNode); 

           
        }
        else
        {
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkInput();
       // move();
        changeOrientation();



    }


    void checkInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            direction = Vector2.right;
            MoveToNode(direction);
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            direction = Vector2.left;
            MoveToNode(direction);
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            direction = Vector2.up;
            MoveToNode(direction);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            direction = Vector2.down;
            MoveToNode(direction);
        }

    }


    void move ()
    {
        transform.localPosition += (Vector3)(direction * speed) * Time.deltaTime;
    }


    void MoveToNode(Vector2 d)
    {
        NodePellets moveToNode = CanMove(d);
        if (moveToNode != null)
        {
            transform.localPosition = moveToNode.transform.position;
            currentNode = moveToNode;
        }
    }

    void changeOrientation ()
    {

        if (direction == Vector2.right)
        {
            transform.localScale = new Vector3 (.9f, .9f, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Vector2.left)
        {
            transform.localScale = new Vector3(-.9f, -.9f, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Vector2.up)
        {
            transform.localScale = new Vector3(.9f, .9f, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (direction == Vector2.down)
        {
            transform.localScale = new Vector3(.9f, .9f, 1);
            transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
    }


    NodePellets CanMove(Vector2 d)
    {
        NodePellets moveToNode = null;

        for(int i = 0;  i < currentNode.neighbors.Length; i++)
        {
            if(currentNode.validDirections[i] == d)
            {
                moveToNode = currentNode.neighbors[i];
                break;
            }
        }

        return moveToNode;
    }


    NodePellets GetNodeAtPosition (Vector2 position)
    {
        GameObject tile = GameObject.Find("Game").GetComponent<Gameboard>().board[(int)position.x, (int)position.y];
        if (tile != null) 
        {
            return tile.GetComponent<NodePellets> ();

        }

        return null;
    }
}

