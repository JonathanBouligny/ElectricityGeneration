using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolarVieController : MonoBehaviour {

	int currentStep= 0;
	GameObject view1;
	GameObject view2;
	GameObject view3;
	GameObject view4;
	GameObject view5;
	GameObject view6;
	GameObject mainCam;
    public GameObject player;

    public CustomRestController crc;

	// Use this for initialization
	void Awake () {
		view1= GameObject.FindGameObjectWithTag("view1");
		view2= GameObject.FindGameObjectWithTag("view2");
		view3= GameObject.FindGameObjectWithTag("view3");
		view4= GameObject.FindGameObjectWithTag("view4");
		view5= GameObject.FindGameObjectWithTag("view5");
		view6= GameObject.FindGameObjectWithTag("view6");
		mainCam= GameObject.FindGameObjectWithTag("solarCamera");

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        setCameraPosotion(currentStep);
       // crc = new CustomRestController();
        crc.wipe();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow) && currentStep < 7)
		{
			currentStep++;
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow) && currentStep > 1)
		{
			currentStep--;
		}

        if(currentStep == 6 && Input.GetKeyDown(KeyCode.Q))
        {
            mainCam.SetActive(false);
            player.SetActive(true);
        }

		setCameraPosotion (currentStep);
	}


	void setCameraPosotion(int step){
		Debug.Log ("12");
		if (step == 1) {
			mainCam.transform.position = view1.transform.position;
            crc.wipe();
            //mainCam.transform.LookAt(view1.transform.position);
        }
        else if (step == 2) {
			mainCam.transform.position = view2.transform.position;
            crc.wipe();

            //mainCam.transform.LookAt(view2.transform.position);
        }
        else if (step == 3) {
			mainCam.transform.position = view3.transform.position;
            crc.wipe();

            //mainCam.transform.LookAt(view3.transform.position);
        }
        else if (step == 4) {
			mainCam.transform.position = view4.transform.position;
            crc.wipe();


            //mainCam.transform.LookAt(view4.transform.position);
        }
        else if (step == 5) {
			mainCam.transform.position = view5.transform.position;
            crc.wipe();


            //mainCam.transform.LookAt(view5.transform.position);
        }
        else if (step == 6) {
			mainCam.transform.position = view6.transform.position;
            crc.dd.gameObject.SetActive(true);
            //mainCam.transform.LookAt(view6.transform.position);
        }
    }
}
