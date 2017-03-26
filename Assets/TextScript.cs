using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int width;
        int height;
        int pixelSize;
        string pixelFormatString;

        PluginFunctions.arwGetVideoParams(out width, out height, out pixelSize, out pixelFormatString);

        Text t = GetComponent<Text>();
        t.text = width.ToString() + " x " + height.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
