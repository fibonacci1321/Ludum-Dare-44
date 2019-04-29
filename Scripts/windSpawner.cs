using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windSpawner : MonoBehaviour {

    public List<GameObject> winds;
    public bool reset0 = false;
    public bool reset1 = false;
    public bool reset2 = false;
    public bool reset3 = false;
    public bool reset4 = false;

    // Start is called before the first frame update
    void Start()
    {
        //winds.Add(new GameObject(string.Format("wind{0}", index + 1)));
        winds.Add(Instantiate(Resources.Load("Wind")) as GameObject);
        winds[0].transform.position = new Vector3(Random.Range(-144.0f, -55.0f), Random.Range(-35.0f, -21.0f), -3.0f);

        winds.Add(Instantiate(Resources.Load("Wind")) as GameObject);
        winds[1].transform.position = new Vector3(Random.Range(-144.0f, -55.0f), Random.Range(-20.0f, -7.0f), -3.0f);

        winds.Add(Instantiate(Resources.Load("Wind")) as GameObject);
        winds[2].transform.position = new Vector3(Random.Range(-144.0f, -55.0f), Random.Range(-6.0f, 5.0f), -3.0f);

        winds.Add(Instantiate(Resources.Load("Wind")) as GameObject);
        winds[3].transform.position = new Vector3(Random.Range(-144.0f, -55.0f), Random.Range(7.0f, 19.0f), -3.0f);

        winds.Add(Instantiate(Resources.Load("Wind")) as GameObject);
        winds[4].transform.position = new Vector3(Random.Range(-144.0f, -55.0f), Random.Range(21.0f, 35.0f), -3.0f);

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < winds.Count; i++) {
            if(winds[i].transform.position.x > 73) {
                if(i == 0) {
                    reset0 = true;
                }
                else if(i == 1) {
                    reset1 = true;
                }
                else if(i == 2) {
                    reset2 = true;
                }
                else if(i == 3) {
                    reset3 = true;
                }
                else if(i == 4) {
                    reset4 = true;
                }
            }
        }

        if(reset0) {
            winds[0].transform.position = new Vector3(Random.Range(-144.0f, -55.0f), Random.Range(-35.0f, -21.0f), -3.0f);
            reset0 = false;
        }
        if(reset1) {
            winds[1].transform.position = new Vector3(Random.Range(-144.0f, -55.0f), Random.Range(-20.0f, -7.0f), -3.0f);
            reset1 = false;
        }
        if(reset2) {
            winds[2].transform.position = new Vector3(Random.Range(-144.0f, -55.0f), Random.Range(-6.0f, 5.0f), -3.0f);
            reset2 = false;
        }
        if(reset3) {
            winds[3].transform.position = new Vector3(Random.Range(-144.0f, -55.0f), Random.Range(7.0f, 19.0f), -3.0f);
            reset3 = false;
        }
        if(reset4) {
            winds[4].transform.position = new Vector3(Random.Range(-144.0f, -55.0f), Random.Range(21.0f, 35.0f), -3.0f);
            reset4 = false;
        }


    }
}
