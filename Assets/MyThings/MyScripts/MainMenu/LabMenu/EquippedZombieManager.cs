using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EquippedZombieManager : MonoBehaviour
{
    private Transform zombieTemplate;
    private Transform[] zombieSlots;
    private readonly int offsetAmount = 350;
    private int index;

    private int maxZombieSlots;

    private void Start()
    {
        Inventory.instance.OnZombieSelect += Inventory_DisplayZombieEquipment;
        zombieTemplate = transform.Find("EquippedZombie");
        zombieTemplate.gameObject.SetActive(false);

        
        maxZombieSlots = Inventory.instance.zombieInventoryMaxCapacity; //determine the capacity of the array
        zombieSlots = new Transform[maxZombieSlots]; // Initialize the array

        //instantiate 3 empty slots to be filled
        for (int i = 0; i < maxZombieSlots; i++)
        {
            Transform zombieTransform = Instantiate(zombieTemplate.transform, transform);
            zombieTransform.gameObject.SetActive(true);
            zombieTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * i, 0);
            zombieSlots[i] = zombieTransform;
        }

    }

    public void Inventory_DisplayZombieEquipment(object sender, Inventory.OnZombieSelectEventArgs e)
    {
            
            //
            //zombieSlots[index] = zombieTransform;
            //Change text
            //zombieTransform.Find("ZombieName").GetComponent<TextMeshProUGUI>().SetText(e.equippedzombie.namestring);
            //Get image
            //zombieTransform.Find("Image").GetComponent<Image>().sprite = zombie.image;
            index++;
    }
}
