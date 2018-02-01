using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour {

    public GameObject mazeGenerator;
    public float waitTime;

    private bool wasOnce;

	void Start () {
		
	}
	

	void Update () {
		
        if(!wasOnce && Time.timeSinceLevelLoad - waitTime > 0)
        {
            wasOnce = true;
            mazeGenerator.GetComponent<MazeGenerator>().Initialize();
        }
	}
}
