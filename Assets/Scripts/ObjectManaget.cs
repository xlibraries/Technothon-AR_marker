using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectManaget : MonoBehaviour
{
    public void RotateRight()
    {
        this.transform.Rotate(new Vector3(0, transform.rotation.y + 450.0f, 0) * Time.deltaTime);
    }

    public void RotateLeft()
    {
        this.transform.Rotate(new Vector3(0, transform.rotation.y - 450.0f, 0) * Time.deltaTime);
    }
    public void ScaleUp()
    {
        transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.z + 0.1f, transform.localScale.z + 0.1f);
    }
    public void ScaleDown()
    {
        transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.z - 0.1f, transform.localScale.z - 0.1f);
    }
}
