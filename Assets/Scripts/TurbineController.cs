using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbineController : MonoBehaviour {

    public bool on;
    public Component[] turbineControllers;

    void Start()
    {
        turbineControllers = GetComponentsInChildren<Turnbine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            foreach (Turnbine turt in turbineControllers)
                turt.on = true;
        }
        else
        {
            foreach (Turnbine turt in turbineControllers)
                turt.on = false;
        }
    }
}
