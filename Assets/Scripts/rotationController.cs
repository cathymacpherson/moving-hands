using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;
using UnityEngine.UI;

public class rotationController : MonoBehaviour
{

    GameObject csvFile;
    GameObject leftHandLight;
    GameObject rightHandLight;
    GameObject rightStickLight;
    GameObject leftStickLight;
    GameObject leftHandDark;
    GameObject rightHandDark;
    GameObject rightStickDark;
    GameObject leftStickDark;
    //Slider mySlider;
    List<string> stringList = new List<string>(); //stores the read in lines from the text file
     public int currentLine = 0;
     private string[] data;
     public string[] row;

       
void Start()
{
    
   leftStickLight = GameObject.Find("/L_Stick_Light/L_Rotator");
    rightStickLight = GameObject.Find("/R_Stick_Light/R_Rotator");

      leftHandLight = GameObject.Find("/L_Hand_Light/L_Arm/L_Forearm/L_Wrist");
        rightHandLight = GameObject.Find("/R_Hand_Light/R_Arm/R_Forearm/R_Wrist"); 

        leftStickDark = GameObject.Find("/L_Stick_Dark/L_Rotator");
        rightStickDark = GameObject.Find("/R_Stick_Dark/R_Rotator");


    leftHandDark = GameObject.Find("/L_Hand_Dark/L_Arm/L_Forearm/L_Wrist");
     rightHandDark = GameObject.Find("/R_Hand_Dark/R_Arm/R_Forearm/R_Wrist");

        //mySlider = GameObject.Find("Slider").GetComponent<Slider>();
       // mySlider.gameObject.SetActive(false);


        readCSV();
}


    void readCSV()
    {
        TextAsset rotationData = Resources.Load<TextAsset>("medium"); //loads in data
        data = rotationData.text.Split('\n'); //splits the data into array by row
    }

void runMovement()
    {
        currentLine++; //increases the line
       // if (currentLine >= data.Length)
        //    currentLine = 0; //loop the animation if it reaches the end
        row = data[currentLine].Split(','); //loops through data and splits data into array by comma
        
        for (int i = 0; i < data.Length - 1; i++)
        {
            rightStickLight.transform.eulerAngles = new Vector3(rightStickLight.transform.eulerAngles.x, rightStickLight.transform.eulerAngles.y, float.Parse(row[0])*20);
            leftStickLight.transform.eulerAngles = new Vector3(leftStickLight.transform.eulerAngles.x, leftStickLight.transform.eulerAngles.y, 0 - float.Parse(row[1])*20); 

         //   rightHandLight.transform.eulerAngles = new Vector3(rightHandLight.transform.eulerAngles.x, rightHandLight.transform.eulerAngles.y, 90 + float.Parse(row[0])*20);
          //  leftHandLight.transform.eulerAngles = new Vector3(leftHandLight.transform.eulerAngles.x, leftHandLight.transform.eulerAngles.y, 270 + float.Parse(row[1])*20);

          //  rightStickDark.transform.eulerAngles = new Vector3(rightStickDark.transform.eulerAngles.x, rightStickDark.transform.eulerAngles.y, float.Parse(row[0]) * 20);
          //  leftStickDark.transform.eulerAngles = new Vector3(leftStickDark.transform.eulerAngles.x, leftStickDark.transform.eulerAngles.y, 0 - float.Parse(row[1]) * 20);

           // rightHandDark.transform.eulerAngles = new Vector3(rightHandDark.transform.eulerAngles.x, rightHandDark.transform.eulerAngles.y, 90 + float.Parse(row[0]) * 20);
          //  leftHandDark.transform.eulerAngles = new Vector3(leftHandDark.transform.eulerAngles.x, leftHandDark.transform.eulerAngles.y, 270 + float.Parse(row[1]) * 20); 
        }
    }



void Update()
{
        
}

   
void FixedUpdate()
{
    runMovement(); 
}
}