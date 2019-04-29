using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController : MonoBehaviour {

    bool upPressed;
    bool leftPressed;
    bool downPressed;
    bool rightPressed;

    public float moveRate = 0.021f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        //reset previous direction(s)
        upPressed = false;
        leftPressed = false;
        downPressed = false;
        rightPressed = false;

        //boundary enforcement
        if(transform.position.x < -39.0f) {
            transform.position += new Vector3(moveRate, 0.0f, 0.0f);
        }
        if(transform.position.x > 36.0f) {
            transform.position += new Vector3(-moveRate, 0.0f, 0.0f);
        }
        if(transform.position.y < -40.0f) {
            transform.position += new Vector3(0.0f, moveRate, 0.0f);
        }
        if(transform.position.y > 41.0f) {
            transform.position += new Vector3(0.0f, -moveRate, 0.0f);
        }

        if(Input.GetKey(KeyCode.UpArrow)) {
            upPressed = true;
        }
        if(Input.GetKey(KeyCode.LeftArrow)) {
            leftPressed = true;
        }
        if(Input.GetKey(KeyCode.DownArrow)) {
            downPressed = true;
        }
        if(Input.GetKey(KeyCode.RightArrow)) {
            rightPressed = true;
        }

        directionSelector();
    }

    void directionSelector() {
        if(upPressed && !leftPressed && !downPressed && !rightPressed) {
            moveUp();
        }
        else if(!upPressed && leftPressed && !downPressed && !rightPressed) {
            moveLeft();
        } 
        else if(!upPressed && !leftPressed && downPressed && !rightPressed) {
            moveDown();
        } 
        else if(!upPressed && !leftPressed && !downPressed && rightPressed) {
            moveRight();
        } 
        else if(upPressed && leftPressed && !downPressed && !rightPressed) {
            moveNW();
        } 
        else if(upPressed && !leftPressed && !downPressed && rightPressed) {
            moveNE();
        } 
        else if(!upPressed && !leftPressed && downPressed && rightPressed) {
            moveSE();
        } 
        else if(!upPressed && leftPressed && downPressed && !rightPressed) {
            moveSW();
        }
    }

    void moveUp() {
        transform.position += new Vector3(0.0f, moveRate, 0.0f);
    }

    void moveLeft() {
        transform.position += new Vector3(-moveRate, 0.0f, 0.0f);
    }

    void moveDown() {
        transform.position += new Vector3(0.0f, -moveRate, 0.0f);
    }

    void moveRight() {
        transform.position += new Vector3(moveRate, 0.0f, 0.0f);
    }

    void moveNW() {
        transform.position += new Vector3(-0.707f * moveRate, 0.707f * moveRate, 0.0f);
    }

    void moveNE() {
        transform.position += new Vector3(0.707f * moveRate, 0.707f * moveRate, 0.0f);
    }

    void moveSE() {
        transform.position += new Vector3(0.707f * moveRate, -0.707f * moveRate, 0.0f);
    } 

    void moveSW() {
        transform.position += new Vector3(-0.707f * moveRate, -0.707f * moveRate, 0.0f);
    } 
}
