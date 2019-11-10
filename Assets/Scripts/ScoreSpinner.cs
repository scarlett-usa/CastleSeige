using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Attach to the spinner object. Rotates the spinner a certain amount
public class ScoreSpinner : MonoBehaviour
{
    private Quaternion rotationStart;
    public float rotationSpeed = 1.0f;
    private bool reset = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rotationStart = transform.rotation; //saves initial rotation
    }

    // Update is called once per frame
    void Update()
    {
        if(reset){
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationStart, Time.deltaTime * rotationSpeed);
            if(Mathf.Round(Mathf.Abs(transform.rotation.z))  == Mathf.Round(Mathf.Abs(rotationStart.z)) )
                reset = false;
        }
    }

    //Rotates the spinner on it's z-axis
    public void IncreaseScore(){
        gameObject.transform.Rotate(new Vector3(0f, 0f, 60f), Space.Self);
    }
    public void ResetSpinner(){
        reset = true;
    }
}
