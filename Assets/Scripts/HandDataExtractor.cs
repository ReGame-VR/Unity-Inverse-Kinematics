using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.ManusVR.Scripts;

public class HandDataExtractor : MonoBehaviour {

    private HandData handData;

	// Use this for initialization
	void Start () {
        handData = GetComponent<HandData>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Average Value Left" + handData.Average(device_type_t.GLOVE_LEFT).ToString());
            Debug.Log("Average Knuckle Left" + handData.FirstJointAverage(device_type_t.GLOVE_LEFT).ToString());
        }
	}
}
