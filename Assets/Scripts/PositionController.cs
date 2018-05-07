using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionController : MonoBehaviour
{
    Text efficiency, diameter, velocity,power;
    Text eff_warning, dia_warning, vel_warning;
    Text infoText;

    public GameObject player;
    public GameObject solarCam;

    //For rotation
    GameObject pivot,windTurbine,panel;

    public GameObject boxInternals;

    //camera
    Camera cam;

    //camera positions
    public GameObject[] camPositions = new GameObject[11];

    //slides
    int slides, dia, vel;
    float eff;

    bool turbineOn;

    double pow;

    // Use this for initialization
    void Start()
    {
        slides = 1;
        eff = 0.3f;
        dia = 31;
        vel = 3;

        turbineOn = false;

        //For rotation of blades
        pivot = GameObject.FindWithTag("Pivot");

        //Get turbine reference
        windTurbine = GameObject.FindWithTag("WindTurbine");

        //Get Panel reference
        panel = GameObject.FindWithTag("myPanel");

        //Value Based Text
        efficiency = GameObject.FindWithTag("Eff").GetComponent<Text>();
        diameter = GameObject.FindWithTag("Dia").GetComponent<Text>();
        velocity = GameObject.FindWithTag("Vel").GetComponent<Text>();
        power = GameObject.FindWithTag("power").GetComponent<Text>();

        //Warning Texts
        eff_warning = GameObject.FindWithTag("warn1").GetComponent<Text>();
        dia_warning = GameObject.FindWithTag("warn2").GetComponent<Text>();
        vel_warning = GameObject.FindWithTag("warn3").GetComponent<Text>();

        eff_warning.text = "";
        dia_warning.text = "";
        vel_warning.text = "";

        infoText= GameObject.FindGameObjectWithTag("Info").GetComponent<Text>();

        //Cam
        cam = GameObject.FindGameObjectWithTag("WindCam").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(turbineOn)
            TurbineUpdate();

        //player controls
        if (Input.GetKeyDown(KeyCode.RightArrow) && slides < 11)
        {
            slides++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && slides > 1)
        {
            slides--;
        }

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

            case 11:
                Slide11();
                break;
        }

        if(slides == 11 && Input.GetKeyDown(KeyCode.Q))
        {
            solarCam.SetActive(false);
            player.SetActive(true);
        }

    }

    public void Incr_eff()
    {
        eff = float.Parse(efficiency.text);
        if (eff >= 0.30f && eff <= 0.44f)
        {
            eff_warning.text = "";
            eff = eff + 0.01f;
            efficiency.text = eff.ToString();
        }

        if(eff >= 0.45f)
        {
            eff_warning.text = "Max. Efficiency reached!!!";
            eff_warning.GetComponent<Text>();
        }
    }

    public void Decr_eff()
    {
        eff = float.Parse(efficiency.text);
        if (eff <= 0.45f && eff > 0.30f)
        {
            eff_warning.text = "";
            eff = eff - 0.01f;
            efficiency.text = eff.ToString();
        }

        if (eff <= 0.31f)
        {
            eff_warning.text = "Min. Efficiency reached!!!";
        }
    }

    public void Incr_dia()
    {
        dia = int.Parse(diameter.text);
        if (dia >= 30 && dia < 47)
        {
            dia_warning.text = "";
            dia++;
            diameter.text = dia.ToString();
        }

        if (dia == 47)
        {
            dia_warning.text = "Max. diameter reached!!!";

        }
    }

    public void Decr_dia()
    {
        dia = int.Parse(diameter.text);
        if (dia <= 47 && dia > 31)
        {
            dia_warning.text = "";
            dia--;
            diameter.text = dia.ToString();
        }

        if (dia == 31)
        {
            dia_warning.text = "Min. diameter reached!!!";

        }
    }

    public void Incr_vel()
    {
        vel = int.Parse(velocity.text);
        if (vel >= 3 && vel < 25)
        {
            vel_warning.text = "";
            vel++;
            velocity.text = vel.ToString();
            turbineOn = true;
        }

        if (vel == 25)
        {
            vel_warning.text = "Max. cut-out velocity reached!!!";
            turbineOn = false;
            //CAll turbineUpdate(int)

        }
    }

    public void Decr_vel()
    {
        vel = int.Parse(velocity.text);
        if (vel <= 25 && vel > 3)
        {
            vel_warning.text = "";
            vel--;
            velocity.text = vel.ToString();
            turbineOn = true;

        }

        if (vel == 3)
        {
            vel_warning.text = "Min. cut-in velocity reached!!!";
            turbineOn = false;

        }
    }

    public void TurbineUpdate()
    {
        pivot.transform.Rotate(new Vector3(0, 0, -vel/ 5f)); //Time.deltaTime
    }

    public void CalculatePower()
    {
        pow = (1.0f / 8.0f) * eff * (1.2f) * Mathf.PI * Mathf.Pow(dia, 2) * Mathf.Pow(vel, 3);
        pow = pow / 1000;
        pow= System.Math.Round(pow, 3);
        power.text = pow.ToString();
    }

    void Slide1()
    {
        cam.transform.position = camPositions[0].transform.position;
        //cam.transform.LookAt(dam.transform.position);

        windTurbine.SetActive(true);
        //Deactivate Box internals
        boxInternals.SetActive(false);

        //Deactivate Panel
        panel.SetActive(false);
        infoText.text = "This is a wind turbine, it converts the velocity of air into Mechanical Energy and then Generater converts mechanical energy into electricity (Electrical Energy)";

    }

    void Slide2()
    {
        windTurbine.SetActive(false);
        boxInternals.SetActive(true);
        panel.SetActive(false);
        cam.transform.position = camPositions[1].transform.position;
        infoText.text = "This is internal structure of the box, that generates the electricity";

    }

    void Slide3()
    {
        boxInternals.SetActive(true);
        panel.SetActive(false);
        cam.transform.position = camPositions[2].transform.position;

        infoText.text = "Low Speed Shaft: Spins along the rotor and turns the high-speed shaft using the gear";
    }

    void Slide4()
    {
        boxInternals.SetActive(true);
        panel.SetActive(false);
        cam.transform.position = camPositions[3].transform.position;

        infoText.text = "High Speed Shaft: Transfers the spin of the low-speed shaft to the generator at a much higher RPM (1000-1800)";

    }

    void Slide5()
    {
        boxInternals.SetActive(true);
        panel.SetActive(false);
        cam.transform.position = camPositions[4].transform.position;
        infoText.text = "Brake: Stops the rotor in case of emergency or high winds";
    }

    void Slide6()
    {
        boxInternals.SetActive(true);
        panel.SetActive(false);
        cam.transform.position = camPositions[5].transform.position;
        infoText.text = "Generator: produces electricity using the turning motion of the highspeed shaft and electromagnetic induction.";
    }

    void Slide7()
    {
        boxInternals.SetActive(true);
        panel.SetActive(false);
        cam.transform.position = camPositions[6].transform.position;
        infoText.text = "Controller:  Starts and stops the turbine so it only operates at the desirable wind speeds - between 8 and 55 mph generally.";
    }

    void Slide8()
    {
        boxInternals.SetActive(true);
        panel.SetActive(false);
        cam.transform.position = camPositions[7].transform.position;
        infoText.text = "Anemometer: Measures the speed of the wind and transmits this data to controller";
    }

    void Slide9()
    {
        boxInternals.SetActive(true);
        panel.SetActive(false);
        cam.transform.position = camPositions[8].transform.position;
        infoText.text = "Wind Vane: Measures the wind direction and transmits this information to Yaw Drive";
    }

    void Slide10()
    {
        boxInternals.SetActive(true);
        panel.SetActive(false);
        cam.transform.position = camPositions[9].transform.position;
        infoText.text = "Yaw Drive:  Correctly orients the turbine with respect to the wind using data from the wind vane";
    }

    void Slide11()
    {
        windTurbine.SetActive(true);
        panel.SetActive(true);
        boxInternals.SetActive(false);
        infoText.text = "Press Q to quit.";
        cam.transform.position = camPositions[10].transform.position;
    }
}
