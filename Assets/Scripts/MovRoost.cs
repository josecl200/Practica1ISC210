using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovRoost : MonoBehaviour
{
    public bool run = false;
    public char direction;
    public GameObject semafaro = null;
    private Vector3 movingDirection;
    void Start()
    {

	   
    }

    // Update is called once per frame
    void Update() {
	if(run) {
	    switch(direction){
		case 'U':
	            movingDirection = new Vector3(0,2*Time.deltaTime,0);
	            break;
	        case 'D':
		    movingDirection = new Vector3(0,-2*Time.deltaTime,0);
		    break;
	        case 'L':
		    movingDirection = new Vector3(-2*Time.deltaTime,0,0);
		    break;
	        case 'R':
		    movingDirection = new Vector3(2*Time.deltaTime,0,0);
		    break;
	    }
		gameObject.transform.position += movingDirection;
	}
    }

    private void OnTriggerEnter2D(Collider2D collider) {
	switch(collider.tag){
	    case "Semafaro":
		run = collider.gameObject.GetComponent<ControlSemaphore>().passable;
		if(!run){
		    semafaro = collider.gameObject;
		    semafaro.GetComponent<ControlSemaphore>().misGallos.Add(gameObject);
		}
		break;
	    case "Gallo":
		run = collider.gameObject.GetComponent<MovRoost>().run;
		if(!run){
		    semafaro = collider.gameObject.GetComponent<MovRoost>().semafaro;
		    semafaro.GetComponent<ControlSemaphore>().misGallos.Add(gameObject);
		}
		break;
	    case "Destroyer":
		Destroy(this.gameObject);
		break;
	}
    }
}
