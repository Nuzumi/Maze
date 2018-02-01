﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class CharacterControler : MonoBehaviour {

    public GameObject player;
    public GameObject chest;
    

    private void Start()
    {
        player.SetActive(false);
        chest.SetActive(false);
    }

    public void SetChcaractersStartPoints(List<GameObject> gameObjectsList)
    {
        System.Random rand = new System.Random();
        List<Node> nodeList = new List<Node>();
        foreach(GameObject g in gameObjectsList)
        {
            nodeList.Add(g.GetComponent<Node>());
        }

        List<Node> potencialStartNode = nodeList.Where(n => n.neighboursToGo.Count == 1).ToList();
        List<Tuple<Node, float>> distanceList = new List<Tuple<Node, float>>();
        foreach (Node g in nodeList)
        {
            distanceList.Add(new Tuple<Node, float>(g, float.PositiveInfinity));
        }

        Node playerStartNode = potencialStartNode[rand.Next(potencialStartNode.Count)];
        nodeList.Remove(playerStartNode);

        Queue<Node> queue = new Queue<Node>();
        
        queue.Enqueue(playerStartNode);
        int distance = 0;
        distanceList.Where(t => t.Item1 == playerStartNode).FirstOrDefault().Item2 = distance;
        while(queue.Count != 0)
        {
            Node node = queue.Dequeue();
            distance++;
            foreach(GameObject n in node.neighboursToGo)
            {
                Node tmp = n.GetComponent<Node>();
                if(distanceList.Where(t => t.Item1 == tmp).FirstOrDefault().Item2 == float.PositiveInfinity)
                {
                    distanceList.Where(t => t.Item1 == tmp).FirstOrDefault().Item2 = distance;
                    queue.Enqueue(tmp);
                }  
            }

            if (distance > 10000)
            {
                break;
            }
        }

        Node endNode =  distanceList.Where(i => i.Item2 == distanceList.Max(t => t.Item2)).FirstOrDefault().Item1;

        player.transform.position = playerStartNode.gameObject.transform.position;
        player.SetActive(true);
        chest.transform.position = endNode.gameObject.transform.position;
        chest.SetActive(true);

        

       
       
    }

}
