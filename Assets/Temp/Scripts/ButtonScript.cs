using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private string item;
    private bool isSelected = false;
    private Image image;

    private void Start()
    {
        image = this.GetComponent<Image>();
    }
    public void itemselect()
    {
        GameManager.Instance.buttontemp();
        GameManager.Instance.SetItemSelect(item);
        if (isSelected)
            image.color = Color.gray;
        else
            image.color = Color.white;
        isSelected = !isSelected;
    }

   
}
