using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveGameScript : MonoBehaviour {

    void Update () {
		if(Input.GetKeyDown(KeyCode.L))
        {
            Application.Quit();
        }
	}
}
