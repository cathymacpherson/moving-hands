    using UnityEngine;
    using System.Collections;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.ComponentModel;

//This script outputs the position and rotation of sensor A and sensor B

    public class readSensorPosition : MonoBehaviour 
    {
        //Private variables
        private GameObject sensorA; 
        private GameObject sensorB; 

        //Public variables
        public string fileName;

  
    private void Start()
    {
         sensorA = GameObject.Find("/Used Sensors/Knuckle (0)");
         sensorB = GameObject.Find("/Used Sensors/Knuckle (1)");
     }


    private void Update()
    {

    }

  
    private void FixedUpdate()

    {
        float[] sensorPosA = new float[] { sensorA.transform.position.x, sensorA.transform.position.y, sensorA.transform.position.z,
                                             sensorA.transform.eulerAngles.x, sensorA.transform.eulerAngles.y, sensorA.transform.eulerAngles.z };
        float[] sensorPosB = new float[] { sensorB.transform.position.x, sensorB.transform.position.y, sensorB.transform.position.z,
                                             sensorB.transform.eulerAngles.x, sensorB.transform.eulerAngles.y, sensorB.transform.eulerAngles.z };
        //Other positions previously read - Quaterions and localEulerAngles
        var line = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}",
                                    DateTime.Now, 
                                    sensorPosA[0], sensorPosA[1], sensorPosA[2], sensorPosA[3], sensorPosA[4], sensorPosA[5],
                                    sensorPosB[0], sensorPosB[1], sensorPosB[2], sensorPosB[3], sensorPosB[4], sensorPosB[5]);
            var name = fileName + ".txt";
            StreamWriter writer = new StreamWriter(name, true);
            writer.WriteLine(line);
            {
                if (writer != null)
                    writer.Close(); //Check whether this is closing and re-opening the file after every line
            }

        }
        
    }