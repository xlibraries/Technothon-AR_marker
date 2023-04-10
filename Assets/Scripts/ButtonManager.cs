using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    private Button button;
    [SerializeField]private RawImage buttonImage;

    private int _itemId;
    private Sprite _buttonTexture;

    public int ItemId
    {
        set => _itemId = value;
    }
    public Sprite ButtonTexture 
    {
        set 
        {
            _buttonTexture = value;
            buttonImage.texture = _buttonTexture.texture;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.Instance.OnEntered(gameObject))
        {
            transform.DOScale(Vector3.one * 2, 0.3f);
            //transform.localScale = Vector3.one * 1.5f;
        }
        else
        {
            transform.DOScale(Vector3.one, 0.3f);
            //transform.localScale = Vector3.one;
        }
    }

    private void SelectObject()
    {
        DataHandler.Instance.SetFurniture(_itemId);
    }
}
