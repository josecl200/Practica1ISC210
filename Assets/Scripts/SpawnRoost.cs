﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnRoost : MonoBehaviour
{
    public GameObject gallo;
    enum Direction {
	L,
	R,
	U,
	D
    };
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRooster", 0, 1);
    }

    private void SpawnRooster(){
	GameObject newGallo = Instantiate(gallo, new Vector3(-20,-20,-20), Quaternion.identity);
	Array values = Enum.GetValues(typeof(Direction));
	System.Random random = new System.Random();
	Direction randomDir = (Direction)values.GetValue(random.Next(values.Length));
	Vector3 spawnPoint = new Vector3(0, 0, 0);
	Quaternion rotationPoint = new Quaternion(0, 0, 0, 0);
	char dir='L';
	switch(randomDir){
	    case Direction.R:
	        dir = 'R';
	        spawnPoint = new Vector3(-7.26f, -0.7f, 4);
	        break;
	    case Direction.L:
		dir = 'L';
		spawnPoint = new Vector3(7.26f, 0.7f, 4);
		rotationPoint = new Quaternion(0,180,0,1);
		break;
	    case Direction.D:
		dir = 'D';
		spawnPoint = new Vector3(-1, 5, 4);
		rotationPoint = Quaternion.Euler(0,0,270);
		break;
	    case Direction.U:
		dir = 'U';
		spawnPoint = new Vector3(1, -5, 4);
		rotationPoint = Quaternion.Euler(0,0,90);

		break;
	}
       newGallo.transform.position = spawnPoint;
       newGallo.transform.rotation = rotationPoint;
       newGallo.GetComponent<MovRoost>().direction = dir;
       newGallo.GetComponent<MovRoost>().run = true;
    }
}
