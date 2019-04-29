using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class batteryBar : MonoBehaviour {

    public List<GameObject> cells; //even = full, odd = empty
    public List<GameObject> turbines;
    public List<bool> rotating;
    public List<bool> batteryCells;

    public float totalCharge = 4.0f;
    public float currentCharge = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        //initial 4 cells set to full and initial 4 cells set to empty that are behind full cells
        cells.Add(Instantiate(Resources.Load("single cell full battery 256x256")) as GameObject);
        cells[0].transform.SetParent(transform);
        cells[0].transform.localPosition = new Vector3(-0.46f, 0.02f, 0.0f);
        cells[0].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        cells.Add(Instantiate(Resources.Load("single cell empty battery 256x256")) as GameObject);
        cells[1].transform.SetParent(transform);
        cells[1].transform.localPosition = new Vector3(-0.46f, 0.02f, 1.0f);
        cells[1].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        cells.Add(Instantiate(Resources.Load("single cell full battery 256x256")) as GameObject);
        cells[2].transform.SetParent(transform);
        cells[2].transform.localPosition = new Vector3(-0.19f, 0.02f, 0.0f);
        cells[2].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        cells.Add(Instantiate(Resources.Load("single cell empty battery 256x256")) as GameObject);
        cells[3].transform.SetParent(transform);
        cells[3].transform.localPosition = new Vector3(-0.19f, 0.02f, 1.0f);
        cells[3].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        cells.Add(Instantiate(Resources.Load("single cell full battery 256x256")) as GameObject);
        cells[4].transform.SetParent(transform);
        cells[4].transform.localPosition = new Vector3(0.08f, 0.02f, 0.0f);
        cells[4].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        cells.Add(Instantiate(Resources.Load("single cell empty battery 256x256")) as GameObject);
        cells[5].transform.SetParent(transform);
        cells[5].transform.localPosition = new Vector3(0.08f, 0.02f, 1.0f);
        cells[5].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        cells.Add(Instantiate(Resources.Load("single cell full battery 256x256")) as GameObject);
        cells[6].transform.SetParent(transform);
        cells[6].transform.localPosition = new Vector3(0.35f, 0.02f, 0.0f);
        cells[6].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        cells.Add(Instantiate(Resources.Load("single cell empty battery 256x256")) as GameObject);
        cells[7].transform.SetParent(transform);
        cells[7].transform.localPosition = new Vector3(0.35f, 0.02f, 1.0f);
        cells[7].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        turbines = GameObject.Find("Wind Turbine Spawner Empty").GetComponent<windTurbineSpawner>().turbines;
    }

    // Update is called once per frame
    void Update()
    {
        // test stuff
       
        //add battery
        if(Input.GetMouseButtonDown(1) && currentCharge > 1.0f) {
            if(cells.Count < 90) {
                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot((AudioClip)Resources.Load("plop wind turbine down"));

                addOneCell();
                subtractOneCurrentCharge();
            }
        }

        /*
       if(Input.GetMouseButtonDown(1)) {
           cells[0].GetComponent<SpriteRenderer>().enabled = false;
       }
       */

        overJuiceCheck();

        rotating.Clear();
        for(int i = 0; i < turbines.Count; i++) {
            if(turbines[i].GetComponentInChildren<rotateBlades>().rotating) {
                rotating.Add(true);
            }
        }
        for(int i = 0; i < rotating.Count; i++) {
            addCharge();
        }

        //Debug.Log(rotating.Count);

        subtractCharge();

        if(outOfJuiceCheck()) {
            // Game over scene
            SceneManager.LoadScene("Game Over");
        }

        updateBatteryBar();

    }

    public void addOneCell() {
        float tempPreviousXPosition = cells[cells.Count - 2].transform.localPosition.x;
        float newXPosition = tempPreviousXPosition + 0.27f;

        cells.Add(Instantiate(Resources.Load("single cell full battery 256x256")) as GameObject);
        cells[cells.Count - 1].transform.SetParent(transform);
        cells[cells.Count - 1].transform.localPosition = new Vector3(newXPosition, 0.02f, 0.0f);
        cells[cells.Count - 1].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        cells.Add(Instantiate(Resources.Load("single cell empty battery 256x256")) as GameObject);
        cells[cells.Count - 1].transform.SetParent(transform);
        cells[cells.Count - 1].transform.localPosition = new Vector3(newXPosition, 0.02f, 1.0f);
        cells[cells.Count - 1].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        transform.position += new Vector3(-0.27f, 0.0f, 0.0f);

        addOneTotalCharge();
    }

    public void addCharge() {
        currentCharge += .008f;
    }

    public void subtractCharge() {
        currentCharge -= .002f;
        //Debug.Log(currentCharge);
    }

    public void subtractOneCurrentCharge() {
        currentCharge -= 1.0f;
    }

    public void addOneTotalCharge() {
        totalCharge += 1.0f;
    }

    public void overJuiceCheck() {
        if(currentCharge > totalCharge) {
            currentCharge = totalCharge;
        }
    }

    public bool outOfJuiceCheck() {
        if(currentCharge < 0.0f) {
            return true;
        }
        else {
            return false;
        }
    }

    public void updateBatteryBar() {

        batteryCells.Clear();

        for(int i = 0; i < cells.Count / 2; i++) { 
            if(currentCharge < i + 1) {
                batteryCells.Add(true);
            }
            else {
                batteryCells.Add(false);
            }
        }

        for(int i = 0, index = 0; i < batteryCells.Count; i++, index += 2) {
            if(batteryCells[i]) {
                cells[index].GetComponent<SpriteRenderer>().enabled = false;
            }
            else {
                cells[index].GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
