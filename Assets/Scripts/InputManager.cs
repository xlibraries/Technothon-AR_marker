using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.OpenXR.Input;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera arCamera;
    [SerializeField] private ARRaycastManager arRaycastManager;
    [SerializeField] private GameObject crosshair;

    private Touch touch;
    private List<ARRaycastHit> _hist = new List<ARRaycastHit>();
    private UnityEngine.Pose pose;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        CrosshairCalculation();
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        }
        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began)
        {
            return;
        }

        if (IsPointerOverUI(touch))
        {
            return;
        }

        Instantiate(DataHandler.Instance.GetFurniture(), pose.position, pose.rotation);
    }

    private bool IsPointerOverUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    private void CrosshairCalculation()
    {
        Vector3 originn = arCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0.5f));
        Ray ray = arCamera.ScreenPointToRay(originn);

        if (arRaycastManager.Raycast(ray, _hist))
        {
            pose = _hist[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(90, 0, 0);
        }
    }
}