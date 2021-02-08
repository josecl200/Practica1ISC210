using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class UiControl : MonoBehaviour
{
    public Button halfSpeed;
    public Button normalSpeed;
    public Button doubleSpeed;
    public Button customSpeed;
    public float speedAndTime = 1;
    public InputField customSpeedText;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        normalSpeed.GetComponent<Image>().color = Color.blue;
	halfSpeed.onClick.AddListener(setSlowSpeed);
       	normalSpeed.onClick.AddListener(setNormalSpeed);
	doubleSpeed.onClick.AddListener(setDoubleSpeed);
	customSpeed.onClick.AddListener(setCustomSpeed);
    }

    void setSlowSpeed(){
	speedAndTime = 0.5f;
        halfSpeed.GetComponent<Image>().color = Color.blue;
        normalSpeed.GetComponent<Image>().color = Color.white;
        doubleSpeed.GetComponent<Image>().color = Color.white;
	customSpeed.GetComponent<Image>().color = Color.white;
	camera.GetComponent<CameraScript>().changeTimeScale(speedAndTime);
    }

    void setNormalSpeed(){
	speedAndTime = 1;
	halfSpeed.GetComponent<Image>().color = Color.white;
        normalSpeed.GetComponent<Image>().color = Color.blue;
        doubleSpeed.GetComponent<Image>().color = Color.white;
	customSpeed.GetComponent<Image>().color = Color.white;
	camera.GetComponent<CameraScript>().changeTimeScale(speedAndTime);

    }

    void setDoubleSpeed(){
	speedAndTime = 2;
	halfSpeed.GetComponent<Image>().color = Color.white;
        normalSpeed.GetComponent<Image>().color = Color.white;
        doubleSpeed.GetComponent<Image>().color = Color.blue;
	customSpeed.GetComponent<Image>().color = Color.white;
	camera.GetComponent<CameraScript>().changeTimeScale(speedAndTime);
	
    }

    void setCustomSpeed(){
	string customSpeedString = customSpeedText.text;
	float customNumber = float.Parse(customSpeedString, CultureInfo.InvariantCulture);
	if(customNumber<=0){
	    setNormalSpeed();
	    return;
	}
	speedAndTime = customNumber;
	halfSpeed.GetComponent<Image>().color = Color.white;
        normalSpeed.GetComponent<Image>().color = Color.white;
        doubleSpeed.GetComponent<Image>().color = Color.white;
	customSpeed.GetComponent<Image>().color = Color.blue;
       	camera.GetComponent<CameraScript>().changeTimeScale(speedAndTime);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
