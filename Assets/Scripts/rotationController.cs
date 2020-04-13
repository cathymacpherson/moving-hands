using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class rotationController : MonoBehaviour
{
 
     GameObject csvFile;
     GameObject stimuli1;
    //private string row;

    List<string> stringList = new List<string>(); //this stores the read in lines from the text file

    
    // Start is called before the first frame update
    void Start()
    {

        stimuli1 = GameObject.Find("/Hand_04/R_Arm/R_Forearm/R_Wrist");
         

    }


    void readCSV()
    {
        TextAsset rotationData = Resources.Load<TextAsset>("Test Data"); //loads in data
        string[] data = rotationData.text.Split('\n'); //splits the data into array by row
        for (int i = 0; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(','); //loops through data and splits data into array by comma
            stimuli1.transform.Rotate(stimuli1.transform.rotation.x, stimuli1.transform.rotation.y, float.Parse(row[5]) * Time.deltaTime * 0.25f); //uses the data to get the rotation of the stimuli
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

   
    void FixedUpdate()
    {


        readCSV(); //runs the function every frame 


    }

   
    
}




