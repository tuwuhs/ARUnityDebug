using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackedObjectDebug : MonoBehaviour {
    private GameObject[] _bases = new GameObject[64];
    public Material Mat;

	// Use this for initialization
    void Start()
    {
        for (int i = 0; i < 64; i++) {
            GameObject b = new GameObject();
            b.transform.parent = gameObject.transform;
            b.name = "Base " + i;

            ARTrackedObject t = b.AddComponent<ARTrackedObject>();
            t.MarkerTag = i.ToString();
            t.eventReceiver = t.gameObject;
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);
            cube.transform.position = new Vector3(0f, 0f, -0.04f);
            cube.transform.parent = b.transform;
            cube.layer = LayerMask.NameToLayer("AR foreground");

            cube.GetComponent<Renderer>().material = Mat;
            Color color = cube.GetComponent<Renderer>().material.color;
            color.a = 0.5f;
            cube.GetComponent<Renderer>().material.SetColor("_Color", color);
            Debug.Log("Color " + cube.GetComponent<Renderer>().material.color);

            _bases[i] = b;
        }
    }

	// Update is called once per frame
    void Update()
    {

    }
}
