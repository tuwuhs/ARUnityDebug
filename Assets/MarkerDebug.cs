using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MarkerDebug : MonoBehaviour {
    private ARMarker[] _arMarkers = new ARMarker[64];
    
	// Use this for initialization
	void Start() 
    {
        // Only supports 3x3 marker
        for (int i = 0; i < 64; i++) {
            ARMarker m = gameObject.AddComponent<ARMarker>();
            Debug.Log("Yeah" + m);
            m.MarkerType = MarkerType.SquareBarcode;
            m.Tag = i.ToString();
            m.BarcodeID = i;
            m.PatternWidth = 0.08f;
            m.Load();
            _arMarkers[i] = m;
        }
	}

	// Update is called once per frame
    void Update()
    {

    }
}
