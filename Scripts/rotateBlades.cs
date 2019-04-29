using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBlades : MonoBehaviour {

    public float angle = 0.0f;
    public float rotationRate = 4.2f;

    public List<GameObject> winds;
    public Rigidbody2D windTurbineCollider;

    public bool rotating;

    // Start is called before the first frame update
    void Start() {
        winds = GameObject.Find("Wind Spawner Empty").GetComponent<windSpawner>().winds;
        windTurbineCollider = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update() {
        if(windTurbineCollider.IsTouching(winds[0].GetComponent<BoxCollider2D>())) {
            rotateWindTurbineBlades();
            rotating = true;
        }
        else if(windTurbineCollider.IsTouching(winds[1].GetComponent<BoxCollider2D>())) {
            rotateWindTurbineBlades();
            rotating = true;
        }
        else if(windTurbineCollider.IsTouching(winds[2].GetComponent<BoxCollider2D>())) {
            rotateWindTurbineBlades();
            rotating = true;
        }
        else if(windTurbineCollider.IsTouching(winds[3].GetComponent<BoxCollider2D>())) {
            rotateWindTurbineBlades();
            rotating = true;
        }
        else if(windTurbineCollider.IsTouching(winds[4].GetComponent<BoxCollider2D>())) {
            rotateWindTurbineBlades();
            rotating = true;
        }
        else {
            rotating = false;
        }

    }

    public void rotateWindTurbineBlades() {
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, -angle);
        angle += rotationRate;
        if(angle >= 360.0f) {
            angle = 0.0f;
        }
    }
}
