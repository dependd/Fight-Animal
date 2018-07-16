using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioText : MonoBehaviour {
    Text scenarioText;
	// Use this for initialization
	void Awake () {
        scenarioText = GetComponent<Text>();
	}
	
	public void ChengeScenarioText(string text)
    {
        scenarioText.text = text;
    }
}
