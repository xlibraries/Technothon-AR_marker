using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public Transform selectionPoint;
    public static UIManager instance;

    private GraphicRaycaster _graphicRaycaster;
    private PointerEventData _pointerEventData;
    private EventSystem eventSystem;


    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        _graphicRaycaster= GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
        _pointerEventData = new PointerEventData(eventSystem)
        {
            position = selectionPoint.position
        };
    }

    private void Update()
    {
        
    }

    public bool OnEntered(GameObject button)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        _graphicRaycaster.Raycast(_pointerEventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject == button)
            {
                return true;
            }
        }

        return false;
    }

    #region ARMarker Methods
    public void RotateRight()
    {
        transform.Rotate(new Vector3(0, 45, 90) * Time.deltaTime);
    }

    public void RotateLeft() 
    {
        transform.Rotate(new Vector3(0, -45, 90) * Time.deltaTime);
    }
    public void ScaleUp()
    {
        transform.localScale = new Vector3(transform.localScale.x+ 0.1f, transform.localScale.z + 0.1f, transform.localScale.z + 0.1f);
    }
    public void ScaleDown()
    {
        transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.z - 0.1f, transform.localScale.z - 0.1f);
    }
    #endregion
}
