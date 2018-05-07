using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionsBetweenPowers : MonoBehaviour {

    public GameObject player;
    public GameObject damCamera;
    public GameObject solarCamera;
    public GameObject windCamera;

    public AudioSource electric;
    public AudioSource wind;
    public AudioSource water;

    public float distanceDam;
    public float distanceSolar;
    public float distanceWind;

    void Update () {
		if(Vector3.Distance(damCamera.transform.position,player.transform.position) <= distanceDam && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("test");
            player.SetActive(false);
            damCamera.SetActive(true);
            water.Play();
        }

        else if (Vector3.Distance(solarCamera.transform.position, player.transform.position) <= distanceSolar && Input.GetKeyDown(KeyCode.Return))
        {
            player.SetActive(false);
            solarCamera.SetActive(true);
            electric.Play();
        }

        else if (Vector3.Distance(windCamera.transform.position, player.transform.position) <= distanceWind && Input.GetKeyDown(KeyCode.Return))
        {
            player.SetActive(false);
            windCamera.SetActive(true);
            wind.Play();
        }
    }
}
