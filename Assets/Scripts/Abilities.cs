using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{

    public Image shoeImage;
    public Image maskImage;
    public Image recoverImage;
    public Text leftNum;
    public float cooldown = 1;
    public float recoverTime = 10;
    public int throwableWeaponNum = 5;
    public KeyCode ability;
    int throwableWeaponMax = 5;
    bool isCooldown = false;
    bool isRecovering = false;

    // Start is called before the first frame update
    void Start()
    {
        maskImage.fillAmount = 0;
        shoeImage.fillAmount = 0;
        recoverImage.fillAmount = 0;
        leftNum.text = throwableWeaponNum.ToString();
        throwableWeaponMax = throwableWeaponNum;
    }

    // Update is called once per frame
    void Update()
    {
        leftNum.text = throwableWeaponNum.ToString();
        Ability();
        Recover();
    }

    void Ability()
    {
        if(Input.GetKey(ability) && isCooldown == false && throwableWeaponNum > 0)
        {
            isCooldown = true;
            isRecovering = false;
            recoverImage.fillAmount = 0;
            --throwableWeaponNum;
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

    void Recover()
    {
        if(throwableWeaponNum < throwableWeaponMax && isRecovering == false)
        {
            isRecovering = true;
            recoverImage.fillAmount = 0;
        }
        
        if(isRecovering)
        {
            recoverImage.fillAmount += 1 / recoverTime * Time.deltaTime;
            if(recoverImage.fillAmount >= 1 )
            {
                recoverImage.fillAmount = 0;
                ++throwableWeaponNum;
                isRecovering = false;
            }
        }
    }
}
