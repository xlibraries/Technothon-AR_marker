using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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
}
