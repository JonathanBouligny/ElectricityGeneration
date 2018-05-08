using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //power button
    public Button powerButton;
    public Text buttonText;

    //informative text
    public Text informativeText;

    //electricity generated
    public Text electricityGenerated;

    //river speed
    public Slider flowSlider;
    public Text galonsOfWater;
    double flow = 391788.9;
    double Originalflow = 391788.9;

    //turbine controller
    public TurbineController turb;

    //waterfall controller
    public WaterfallController wat;
    public SprayController spray;

    //comparedToHoover text
    public Text comparedToHoover;

    //camera
    public Camera cam;
    //camera positions
    public GameObject[] camPositions = new GameObject[5];

    //slides
    int slides = 1;
    bool testSlideFormat = false;

    //various objects positions
    public GameObject dam;
    public GameObject waterfall;
    public GameObject powerLines;
    public GameObject transformer;
    public Text totalUnits;
    public Text totalCapcaity;

    public TransitionsBetweenPowers trans;

    public Dropdown dd;
    public Text dropdownText;

    public GameObject player;
   

    private void Start()
    {
        Slide1();
    }

    void Update () {

        //player controls
        if(Input.GetKeyDown(KeyCode.RightArrow) && slides<10)
        {
            slides++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && slides > 1)
        {
            slides--;
        }

        if(Input.GetKeyDown(KeyCode.Q) && slides == 10)
        {
            cam.gameObject.SetActive(false);
            player.SetActive(true);
            trans.water.Stop();
        }

        //button listener for turning on the turbines
        powerButton.onClick.AddListener(turbinePower);

        //water level
        wat.level = (int)flowSlider.value;
        
        if(flowSlider.value == 0)
        {
            flow = 0;
        }
        else if(flowSlider.value == 1)
        {
            flow = Originalflow;
        }
        else if (flowSlider.value == 2)
        {
            flow = Originalflow * 2;
        }
        else if (flowSlider.value == 3)
        {
            flow = Originalflow * 3;
        }
        else if (flowSlider.value == 4)
        {
            flow = Originalflow * 4;
        }
        else if (flowSlider.value == 5)
        {
            flow = Originalflow * 5;
        }

         //slider controller
        if (flowSlider.value > 0)
        {
            spray.on = true;
            wat.on = true;
        }
        else
        {
            spray.on = false;
            wat.on = false;
        }

        informativeText.color = Color.red;

        electricityGenerated.text = "Dam Off";
        
        //slides controller
        switch (slides)
        {
            case 1:
                Slide1();
            break;
            case 2:
                Slide2();
                break;
            case 3:
                Slide3();
                break;
            case 4:
                Slide4();
                break;
            case 5:
                Slide5();
                break;
            case 6:
                Slide6();
                break;
            case 7:
                Slide7();
                break;
            case 8:
                Slide8();
                break;
            case 9:
                Slide9();
                break;
            case 10:
                Slide10();
                break;
        }

        //temporary water on for slide 4
        if(slides>=4 && slides != 10)
        {
            spray.on = true;
            wat.on = true;
            flowSlider.value = 1;
        }
        else if(slides != 4 && slides != 10) 
        {
            spray.on = false;
            wat.on = false;
            flowSlider.value = 0;
        }

        //temporary turbines on for slide 6
        if (slides >= 6 && slides != 10)
        {
            turb.on = true;
        }
        else if (slides != 6 && slides != 10) 
        {
            turb.on = false;
        }
        
        if(slides < 10)
        {
            testSlideFormat = false;
        }

        if (slides == 10 && !testSlideFormat)
        {
            totalUnits.text = "";
            totalCapcaity.text = "";
            dropdownText.gameObject.SetActive(true);
            turb.on = false;
            spray.on = false;
            wat.on = false;
            flowSlider.value = 0;
            testSlideFormat = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

    }

    void turbinePower()
    {
        turb.on = !turb.on;

        if (!turb.on)
        {
            buttonText.text = "Dam On";
        }
        else
        {
            buttonText.text = "Dam Off";
        }
    }

    void Slide1()
    {
        testSlideFormat = false;
        cam.transform.position = camPositions[0].transform.position;
        cam.transform.LookAt(dam.transform.position);
        informativeText.text = "This is a dam. It converts the energy of moving water into Mechanical Energy and then our Hydroelectric Generater converts mechanical energy into electricity (Electrical Energy)";
        galonsOfWater.text = "";
        electricityGenerated.text = "";
        comparedToHoover.text = "";
        powerButton.gameObject.SetActive(false);
        flowSlider.gameObject.SetActive(false);
        dropdownText.gameObject.SetActive(false);
        dd.gameObject.SetActive(false);
        totalUnits.text = "";
        totalCapcaity.text = "";
}

    void Slide2()
    {
        testSlideFormat = false;
        cam.transform.position = camPositions[0].transform.position;
        cam.transform.LookAt(dam.transform.position);
        informativeText.text = "We can estimate the max power the dam could create with the equation Power = Head x Flow x Gravity. Head is the distance the water falls to get to the turbines. Flow is the amount of water that comes out of the waterfall.";
        galonsOfWater.text = "";
        electricityGenerated.text = "";
        comparedToHoover.text = "";
        powerButton.gameObject.SetActive(false);
        flowSlider.gameObject.SetActive(false);
        dropdownText.gameObject.SetActive(false);
        spray.on = true;
        wat.on = true;
        dd.gameObject.SetActive(false);
        totalUnits.text = "";
        totalCapcaity.text = "";
    }

    void Slide3()
    {
        testSlideFormat = false;
        cam.transform.position = camPositions[1].transform.position;
        cam.transform.LookAt(waterfall.transform.position);
        informativeText.text = "Our head is 224 meters (measured the hypotenuse of the dam).";
        galonsOfWater.text = "";
        electricityGenerated.text = "";
        comparedToHoover.text = "";
        powerButton.gameObject.SetActive(false);
        flowSlider.gameObject.SetActive(false);
        dropdownText.gameObject.SetActive(false);
        dd.gameObject.SetActive(false);
        totalUnits.text = "";
        totalCapcaity.text = "";
    }

    void Slide4()
    {
        testSlideFormat = false;
        cam.transform.position = camPositions[1].transform.position;
        cam.transform.LookAt(waterfall.transform.position);
        informativeText.text = "Our flow is 391,788.9 L/S (Based on the percentage of our waterfalls size compared to niagra falls times niagra falls output per second). And gravity is 9.8 M/S";
        galonsOfWater.text = "";
        electricityGenerated.text = "";
        comparedToHoover.text = "";
        powerButton.gameObject.SetActive(false);
        flowSlider.gameObject.SetActive(false);
        dropdownText.gameObject.SetActive(false);
        dd.gameObject.SetActive(false);
        totalUnits.text = "";
        totalCapcaity.text = "";
    }

    void Slide5()
    {
        testSlideFormat = false;
        cam.transform.position = camPositions[0].transform.position;
        cam.transform.LookAt(dam.transform.position);
        informativeText.text = "So our max power is " + string.Format("{0:n0}", (224 * 391788.9 * 9.8)) + " Watts";
        galonsOfWater.text = "";
        electricityGenerated.text = "";
        comparedToHoover.text = "";
        powerButton.gameObject.SetActive(false);
        flowSlider.gameObject.SetActive(false);
        dropdownText.gameObject.SetActive(false);
        dd.gameObject.SetActive(false);
        totalUnits.text = "";
        totalCapcaity.text = "";
    }

    void Slide6()
    {
        testSlideFormat = false;
        cam.transform.position = camPositions[2].transform.position;
        cam.transform.LookAt(dam.transform.position);
        informativeText.text = "But most dams can only convert 60% of the power, so our projected power is: " + string.Format("{0:n0}", .6 * (224 * 391788.9 * 9.8) ) + " Watts";
        galonsOfWater.text = "";
        electricityGenerated.text = "";
        comparedToHoover.text = "";
        powerButton.gameObject.SetActive(false);
        flowSlider.gameObject.SetActive(false);
        dropdownText.gameObject.SetActive(false);
        dd.gameObject.SetActive(false);
        totalUnits.text = "";
        totalCapcaity.text = "";
    }

    void Slide7()
    {
        testSlideFormat = false;
        cam.transform.position = camPositions[3].transform.position;
        cam.transform.LookAt(powerLines.transform.position);
        informativeText.text = "These power lines take the electrity generated by the turbines to...";
        galonsOfWater.text = "";
        comparedToHoover.text = "";
        electricityGenerated.text = "";
        powerButton.gameObject.SetActive(false);
        flowSlider.gameObject.SetActive(false);
        dropdownText.gameObject.SetActive(false);
        dd.gameObject.SetActive(false);
        totalUnits.text = "";
        totalCapcaity.text = "";
    }

    void Slide8()
    {
        testSlideFormat = false;
        cam.transform.position = camPositions[4].transform.position;
        cam.transform.LookAt(transformer.transform.position);
        informativeText.text = "The transformer. That electrity is used to power homes or piece of the dam.";
        galonsOfWater.text = "";
        electricityGenerated.text = "";
        comparedToHoover.text = "";
        powerButton.gameObject.SetActive(false);
        flowSlider.gameObject.SetActive(false);
        dropdownText.gameObject.SetActive(false);
        dd.gameObject.SetActive(false);
        totalUnits.text = "";
        totalCapcaity.text = "";
    }

    void Slide9()
    {
        testSlideFormat = false;
        cam.transform.position = camPositions[4].transform.position;
        cam.transform.LookAt(dam.transform.position);
        informativeText.text = "Dams are essential to powering our country. 13% of us power is renewable energy and 46% of the renewable energy is Hydroelectric.";
        galonsOfWater.text = "";
        electricityGenerated.text = "";
        comparedToHoover.text = "";
        powerButton.gameObject.SetActive(false);
        flowSlider.gameObject.SetActive(false);
        dropdownText.gameObject.SetActive(false);
        dd.gameObject.SetActive(false);
        totalUnits.text = "";
        totalCapcaity.text = "";
    }

    void Slide10()
    {
        cam.transform.position = camPositions[0].transform.position;
        cam.transform.LookAt(dam.transform.position);
        informativeText.text = "Thank you for reading! Please enjoy playing with the slider to increase and decrease flow, the button for turning the dam on and off, and see how much flow you can create! Press Q to end.";

        flowSlider.gameObject.SetActive(true);
        galonsOfWater.text = "Current Flow: " + string.Format("{0:n0}", flow) + " L/S";

        if(turb.on)
        {
            electricityGenerated.text = "Power Generated (60% factored in): " + string.Format("{0:n0}", .6 * (224 * flow * 9.8))  + " Watts";
        }
        
        powerButton.gameObject.SetActive(true);
        comparedToHoover.text = "Watts Compared to the Hoover Dam: " + string.Format("{0:n0}", ( (.6 * (224 * flow * 9.8)) / 4000000000) * 100) + "%";

        dd.gameObject.SetActive(true);
    }
}
