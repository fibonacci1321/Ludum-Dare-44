using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotNearTurbine : MonoBehaviour {

    public List<GameObject> turbines;
    public List<BoxCollider2D> turbineColliders;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D robotBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
