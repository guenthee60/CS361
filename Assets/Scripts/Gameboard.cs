using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameboard : MonoBehaviour
{
   
    private static int boardWidth = 28;
    private static int boardHeight = 36;




    public GameObject[,] board = new GameObject[boardWidth, boardHeight];

    // Start is called before the first frame update
    void Start()
    {
        Object[] objects = GameObject.FindObjectsOfType(typeof(GameObject));

        //iterate over each item in array
        foreach (GameObject i in objects)
        {
            Vector2 position = i.transform.position;

            if (i.name != "PacMan")
            {
                board[(int)position.x, (int)(position.y)] = i;
            }
            else
            {
                Debug.Log("Found Pac-Man at " + position);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
