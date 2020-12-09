using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{

    public Image maskImage;
    public Text leftNum;
    public float cooldown = 1;
    public int throwableWeaponNum = 5;
    public KeyCode ability;
    int throwableWeaponMax = 5;
    bool isCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        maskImage.fillAmount = 0;
        leftNum.text = throwableWeaponNum.ToString();
        throwableWeaponMax = throwableWeaponNum;
    }

    // Update is called once per frame
    void Update()
    {
        Ability();
    }

    void Ability()
    {
        if(Input.GetKey(ability) && isCooldown == false && throwableWeaponNum > 0)
        {
            isCooldown = true;
            --throwableWeaponNum;
            leftNum.text = throwableWeaponNum.ToString();
            maskImage.fillAmount = 1;
        }

        if(isCooldown)
        {
            maskImage.fillAmount -= 1 / cooldown * Time.deltaTime;

            if(maskImage.fillAmount <= 0 )
            {
                maskImage.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
