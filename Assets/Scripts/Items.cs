using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item1", menuName = "AddItem/ Item")]
public class Items : ScriptableObject
{
    public float price;
    public GameObject itemPrefab;
    public Sprite itemSprite;
}
