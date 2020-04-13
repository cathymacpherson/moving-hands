

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
        private GameObject sensorA; //used to gain position of sensor A later in code
        private GameObject sensorB; //used to gain position of sensor B later in code

        //Public variables
        public string fileName;

    //Start is called on the frame when a script is enabled just beore any of the Update Methods are called the first time.
        //Like the Awake function, Start is called exactly once in the lifetime of the script.
        private void Start()
        {
            sensorA = GameObject.Find("/Used Knuckles/Knuckle (0)");
            sensorB = GameObject.Find("/Used Knuckles/Knuckle (1)");

        }


        //Update is called every frame, if the MonoBehaviour is enabled.
        //Update is the most commonly used function to implement any kind of game behaviour.
        private void Update()
        {

        }

    //This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    //FixedUpdate should be used instead of Update when dealing with a Rigidbody.
    //For example when adding a force to a rigidbody, you have to apply the force every
    //fixed frame instead FixedUpdate instead of every frame inside Update.
    private void FixedUpdate()

    {
        float[] sensorPosA = new float[] { sensorA.transform.position.x, sensorA.transform.position.y, sensorA.transform.position.z,
                                             sensorA.transform.eulerAngles.x, sensorA.transform.eulerAngles.y, sensorA.transform.eulerAngles.z };
        float[] sensorPosB = new float[] { sensorB.transform.position.x, sensorB.transform.position.y, sensorB.transform.position.z,
                                             sensorB.transform.eulerAngles.x, sensorB.transform.eulerAngles.y, sensorB.transform.eulerAngles.z };
        var line = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}",
                                    DateTime.Now, 
                                    sensorPosA[0], sensorPosA[1], sensorPosA[2], sensorPosA[3], sensorPosA[4], sensorPosA[5],
                                    sensorPosB[0], sensorPosB[1], sensorPosB[2], sensorPosB[3], sensorPosB[4], sensorPosB[5]);
            var name = fileName + ".txt";
            StreamWriter writer = new StreamWriter(name, true);
            writer.WriteLine(line);
            {
                if (writer != null)
                    writer.Close(); //CHECK WHETHER THIS IS CLOSING AND RE-OPENING AFTER EVERY LINE
            }

        }
        
    }



