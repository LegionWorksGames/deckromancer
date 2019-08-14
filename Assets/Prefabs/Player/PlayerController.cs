using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    bool movementCooldown = false;
    [SerializeField] float cooldownTime = 1;
    [SerializeField] float speed = 1;
    
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        MovementCheck();
    }

    void MovementCheck () {
        print("checking input");
        float x = Input.GetAxisRaw ("Horizontal");
        float y = Input.GetAxisRaw ("Vertical");
        if (!movementCooldown) {
            if (x < -0.5f && y > -0.25f && y < 0.25f) {
                // Move Left
                StartCoroutine(Movement(false, false));
                print(" Move Left");
            } else if (x > 0.5f && y > -0.25f && y < 0.25f) {
                // Move right
                StartCoroutine(Movement(false, true));
                print("Move right");
            } else if (y < -0.5f && x > -0.25f && x < 0.25f) {
                // Move down
                StartCoroutine(Movement(true, false));
                print("Move down");
            } else if (y > 0.5f && x > -0.25f && x < 0.25f) {
                // Move up
                StartCoroutine(Movement(true, true));
                
            }
        }
    }

    IEnumerator Movement(bool vertical, bool positive){
        movementCooldown = true;
        float startTime = Time.time;
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos;
        if(vertical && positive)
        {
            endPos = new Vector3(startPos.x, startPos.y + 1, 0);
        }
        else if(vertical && !positive)
        {
            endPos = new Vector3(startPos.x, startPos.y -1, 0);
        }
        else if(!vertical && positive)
        {
            endPos = new Vector3(startPos.x + 1, startPos.y, 0);
        }
        else if(!vertical && !positive)
        {
            endPos = new Vector3(startPos.x - 1, startPos.y, 0);
        }
        

        while(Vector3.Distance(transform.position, endPos) > 0.025f)
        {
            
            // distance moved = time * speed
            float distCovered = (Time.time - startTime) * speed;
            // Fraction of journey completed = current distance divided by total distance.
            float  fracJourny = distCovered / 1;
            print("Move: " + transform.position + " " + startPos + " " + endPos + " " + fracJourny);
            transform.position = Vector3.Lerp(startPos, endPos, fracJourny);
            yield return null;
        }
        transform.position = endPos;   
        movementCooldown = false;
    }

    void EndCoolDown(){
        movementCooldown = false;
    }
}