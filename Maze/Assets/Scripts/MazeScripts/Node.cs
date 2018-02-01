using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour{

    public enum WalsDirection { left,top,right,down}
    public bool Visited { get; set; }
    public List<GameObject> neighbours;
    public List<GameObject> neighboursToGo;
    public bool[] wals;


    private void Start()
    {
        neighbours = new List<GameObject>();
        neighboursToGo = new List<GameObject>();
        Visited = false;
        wals = new bool[4]; // 0-left  1-top  2-right   3-down
    }


    public void addNeighbour(GameObject node)
    {
        if (!neighbours.Contains(node))
        {
            neighbours.Add(node);
            node.GetComponent<Node>().addNeighbour(gameObject);
        }
    }

    public void deleteNeighbour(GameObject node)
    {
        if (neighbours.Contains(node))
        {
            neighbours.Remove(node);
            node.GetComponent<Node>().deleteNeighbour(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "tile")
        {
            if (!neighbours.Contains(collision.gameObject))
            {
                neighbours.Add(collision.gameObject);
            }
        }
    }
}
