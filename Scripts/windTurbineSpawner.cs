using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windTurbineSpawner : MonoBehaviour
{
    public List<GameObject> turbines;
    public float currentCharge;

    //public void currentCharge; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update() {

        currentCharge = GameObject.Find("Robot Movement Controller").GetComponentInChildren<batteryBar>().currentCharge;

        if(Input.GetMouseButtonDown(0) && currentCharge > 1.0f) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            turbines.Add(Instantiate(Resources.Load("Wind Turbine")) as GameObject);
            turbines[turbines.Count - 1].transform.position = new Vector3(ray.origin.x + 1.894181f, ray.origin.y - 2.282145f, 0.0f);
            GameObject.Find("Robot Movement Controller").GetComponentInChildren<batteryBar>().subtractOneCurrentCharge();

            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot((AudioClip)Resources.Load("plop wind turbine down"));
            //Debug.Log(ray.origin.x);
            //Debug.Log(ray.origin.y);
        }
    }
}
