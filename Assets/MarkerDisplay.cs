using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MarkerDisplay : MonoBehaviour
{
    private Button _button;
    private Text _text;
    private AROrigin _arOrigin;
    private ARMarker _baseMarker;
    private GameObject _trackedObject;
    private bool _objectVisible;

    // Use this for initialization
    void Start()
    {
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<Text>();
        _arOrigin = GetComponentInParent<AROrigin>();
        _text.text = "No markers yet.";
        _button.interactable = false;
        _objectVisible = true;
    }

    void OnMarkerFound(ARMarker marker)
    {
        if (_baseMarker == null) {
            _baseMarker = _arOrigin.GetBaseMarker();
            foreach (ARTrackedObject obj in FindObjectsOfType<ARTrackedObject>()) {
                if (obj.MarkerTag == _baseMarker.Tag) {
                    _trackedObject = obj.gameObject;
                    break;
                }
            }
        }

        Debug.Log(_trackedObject);
        _text.text = "Yeay, found!";
        _button.interactable = true;
    }

    void OnMarkerLost(ARMarker marker)
    {
        if (!_baseMarker.Equals(marker)) {
            return;
        }

        _baseMarker = _arOrigin.GetBaseMarker();
        _trackedObject = null;
        if (_baseMarker != null) {
            foreach (ARTrackedObject obj in FindObjectsOfType<ARTrackedObject>()) {
                if (obj.MarkerTag == _baseMarker.Tag) {
                    _trackedObject = obj.gameObject;
                    break;
                }
            }
        }
        Debug.Log(_trackedObject);
        _text.text = "Booooo, no markers!";

        _button.interactable = false;
    }


    void OnMarkerTracked(ARMarker marker) 
    {
        setVisible(_objectVisible);
    }

    void ToggleVisibility()
    {
        _objectVisible = !_objectVisible;
        setVisible(_objectVisible);
    }

    private void setVisible(bool val)
    {
        if (_trackedObject == null) {
            return;
        }

        foreach (Renderer r in _trackedObject.GetComponentsInChildren<Renderer>()) {
            if (r.enabled != val) {
                r.enabled = val;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
