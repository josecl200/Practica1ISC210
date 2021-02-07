using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ControlSemaphore : MonoBehaviour
{
    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;
    public float delay;
    public bool passable = false;
    public ArrayList misGallos = new ArrayList();
    
    void Start()
    {
        redLight.GetComponent<Renderer>().enabled = true;
        yellowLight.GetComponent<Renderer>().enabled = false;
	greenLight.GetComponent<Renderer>().enabled = false;
	Invoke("SemafaroCall", delay);
    }

    void Update()
    {
    }

    void SemafaroCall(){
	StartCoroutine(Semafaro());
    }

    IEnumerator Semafaro(){
	float timeMod = GameObject.Find("Canvas").GetComponent<UiControl>().speedAndTime;
	while(true){
	    timeMod = GameObject.Find("Canvas").GetComponent<UiControl>().speedAndTime;
	    passable=false;
	    redLight.GetComponent<Renderer>().enabled=true;
	    yellowLight.GetComponent<Renderer>().enabled=false;
	    greenLight.GetComponent<Renderer>().enabled=false;
	    yield return new WaitForSeconds(10 / timeMod);
	    passable=true;
	    CarsCanPass();
	    redLight.GetComponent<Renderer>().enabled=false;
	    yellowLight.GetComponent<Renderer>().enabled=false;
	    greenLight.GetComponent<Renderer>().enabled=true;
	    yield return new WaitForSeconds(7 / timeMod);
	    redLight.GetComponent<Renderer>().enabled=false;
	    yellowLight.GetComponent<Renderer>().enabled=true;
	    greenLight.GetComponent<Renderer>().enabled=false;
	    yield return new WaitForSeconds(3 / timeMod);
	    StopCoroutine(MoveCars());
	}
    }

   IEnumerator MoveCars(){
        while (misGallos.Count > 0){
	    GameObject gallo = misGallos[0] as GameObject;
	    gallo.GetComponent<MovRoost>().run = true;
	    gallo.GetComponent<MovRoost>().semafaro = null;
	    misGallos.Remove(gallo);
	}
	yield return new WaitForSeconds(0);
    }

   async void CarsCanPass(){
       GameObject triggerStreet = GameObject.Find("TriggerStreet");
       while(triggerStreet.GetComponent<StreetCounter>().objs > 0){
	   await Task.Yield();
       }
       StartCoroutine(MoveCars());
   }
}
