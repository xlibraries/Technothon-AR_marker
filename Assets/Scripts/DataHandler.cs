using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;
using System.Reflection;

public class DataHandler : MonoBehaviour
{
    private GameObject furniture;
    [SerializeField] private ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<Items> items;
    [SerializeField] private string label;

    private int current_id = 0;

    private static DataHandler instance;
    public static DataHandler Instance 
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }
    }


    private async void Start()
    {
        items= new List<Items>();
        //LoadItems();
        await Get(label);
        CreateButtons();
    }

    //private void LoadItems()
    //{
    //    var items_obj = Resources.LoadAll("Items", typeof(Items));
    //    foreach (var item in items_obj)
    //    {
    //        this.items.Add(item as Items);
    //    }
    //}

    private void CreateButtons()
    {
        foreach (var item in items)
        {
            ButtonManager btn = Instantiate(buttonPrefab, buttonContainer.transform);
            btn.ItemId= current_id;
            btn.ButtonTexture = item.itemSprite;
            current_id++;
        }
    }

    public void SetFurniture(int id)
    {
        furniture = items[id].itemPrefab;
    }

    public GameObject GetFurniture() 
    { 
        return furniture; 
    }

    public async Task Get(string label)
    {
        var locations = await Addressables.LoadResourceLocationsAsync(label).Task;
        foreach (var location in locations)
        {
            var obj = await Addressables.LoadAssetAsync<Items>(location).Task;
            items.Add(obj);
        }
    }
}
