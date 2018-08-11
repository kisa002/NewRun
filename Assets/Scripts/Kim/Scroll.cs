using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    public Image[] bttn;
    public int productName;
    private bool dragging = false;
    public int posi;

    public Text setText;
    public Text buyText;
    public Text skinText;
    public Button buyBtn;
    public Button setBtn;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SetProduct();
        }
    }

    void SetProduct()
    {
        Debug.Log(productName);
        if (productName == 1)
        {
            posi = 540;
            SetProductPosition();
            SetProductScale(0);
            SetProductButton(0);
            SetText_Go(1);
        }
        else if (productName == 2)
        {
            posi = 115;
            SetProductPosition();
            SetProductScale(1);
            SetProductButton(1);
            SetText_Go(2);
        }
        else if (productName == 3)
        {
            posi = -310;
            SetProductPosition();
            SetProductScale(2);
            SetProductButton(2);
            SetText_Go(3);
        }
        else if (productName == 4)
        {
            posi = -735;
            SetProductPosition();
            SetProductScale(3);
            SetProductButton(3);
            SetText_Go(4);
        }
        else if (productName == 5)
        {
            posi = -1160;
            SetProductPosition();
            SetProductScale(4);
            SetProductButton(4);
            SetText_Go(5);
        }
        else
        {
            posi = -1585;
            SetProductPosition();
            SetProductScale(5);
            SetProductButton(5);
            SetText_Go(6);
        }
    }

    void SetProductPosition()
    {
        int asdf = posi;
        Vector3 pos = new Vector3(asdf, 1030, 0);
        bttn[0].transform.position = Vector3.Lerp(bttn[0].transform.position, pos, 1f);
        asdf += 425;
        pos = new Vector3(asdf, 1030, 0);
        bttn[1].transform.position = Vector3.Lerp(bttn[1].transform.position, pos, 1f);
        asdf += 425;
        pos = new Vector3(asdf, 1030, 0);
        bttn[2].transform.position = Vector3.Lerp(bttn[2].transform.position, pos, 1f);
        asdf += 425;
        pos = new Vector3(asdf, 1030, 0);
        bttn[3].transform.position = Vector3.Lerp(bttn[3].transform.position, pos, 1f);
        asdf += 425;
        pos = new Vector3(asdf, 1030, 0);
        bttn[4].transform.position = Vector3.Lerp(bttn[4].transform.position, pos, 1f);
        asdf += 425;
        pos = new Vector3(asdf, 1030, 0);
        bttn[5].transform.position = Vector3.Lerp(bttn[5].transform.position, pos, 1f);
    }

    void SetProductScale(int ie)
    {
        bttn[ie].transform.localScale = new Vector3(1.8f, 1.8f, 1f);

        for (int i = 0; i <= 5; i++)
        {
            if (i == ie)
            {
                continue;
            }

            bttn[i].transform.localScale = new Vector3(1.3f, 1.3f, 1f);
        }
    }

    public void SetProductButton(int ie)
    {
        if (ie == 0)
        {
            buyBtn.interactable = false;

            if (GameManager.Instance.currentSkin == 1)
            {
                setBtn.interactable = false;
            }
        }
        else if (ie == 1)
        {
            if (UserStatic.muji == false)
            {
                if (GameManager.Instance.endrophin < 150)
                {
                    buyBtn.interactable = false;
                    return;
                }
                buyBtn.interactable = true;
            }
            else
            {
                buyBtn.interactable = false;
            }

            if (GameManager.Instance.currentSkin == 2)
            {
                setBtn.interactable = false;
            }
        }
        else if (ie == 2)
        {
            if (UserStatic.egg == false)
            {
                if (GameManager.Instance.endrophin < 200)
                {
                    buyBtn.interactable = false;
                    return;
                }
                buyBtn.interactable = true;
            }
            else
            {
                buyBtn.interactable = false;
            }

            if (GameManager.Instance.currentSkin == 3)
            {
                setBtn.interactable = false;
            }
        }
        else if (ie == 3)
        {
            if (UserStatic.star == false)
            {
                if (GameManager.Instance.endrophin < 250)
                {
                    buyBtn.interactable = false;
                    return;
                }
                buyBtn.interactable = true;
            }
            else
            {
                buyBtn.interactable = false;
            }

            if (GameManager.Instance.currentSkin == 4)
            {
                setBtn.interactable = false;
            }
        }
        else if (ie == 4)
        {
            if (UserStatic.sun == false)
            {
                if (GameManager.Instance.endrophin < 300)
                {
                    buyBtn.interactable = false;
                    return;
                }
                buyBtn.interactable = true;
            }
            else
            {
                buyBtn.interactable = false;
            }

            if (GameManager.Instance.currentSkin == 5)
            {
                setBtn.interactable = false;
            }
        }
        else if (ie == 5)
        {
            if (UserStatic.aboka == false)
            {
                if (GameManager.Instance.endrophin < 350)
                {
                    buyBtn.interactable = false;
                    return;
                }
                buyBtn.interactable = true;
            }
            else
            {
                buyBtn.interactable = false;
            }

            if (GameManager.Instance.currentSkin == 6)
            {
                setBtn.interactable = false;
            }
        }
    }

    void SetText_Go(int ie)
    {
        if (ie == 1)
        {
            setText.text = "";
            skinText.text = "뉴런";
            buyText.text = "장착";
        }
        else if (ie == 2)
        {
            skinText.text = "무지개 뉴런";
            if (UserStatic.muji == false)
            {
                setText.text = "150";
                buyText.text = "구매";
            }
            else
            {
                setText.text = "";
                buyText.text = "장착";
            }
        }
        else if (ie == 3)
        {
            skinText.text = "계란 뉴런";
            if (UserStatic.egg == false)
            {
                setText.text = "200";
                buyText.text = "구매";
            }
            else
            {
                setText.text = "";
                buyText.text = "장착";
            }
        }
        else if (ie == 4)
        {
            skinText.text = "별똥별 뉴런";
            if (UserStatic.star == false)
            {
                setText.text = "250";
                buyText.text = "구매";
            }
            else
            {
                setText.text = "";
                buyText.text = "장착";
            }
        }
        else if (ie == 5)
        {
            skinText.text = "태양 뉴런";
            if (UserStatic.sun == false)
            {
                setText.text = "300";
                buyText.text = "구매";
            }
            else
            {
                setText.text = "";
                buyText.text = "장착";
            }
        }
        else if (ie == 6)
        {
            skinText.text = "아보카도 뉴런";
            if (UserStatic.aboka == false)
            {
                setText.text = "350";
                buyText.text = "구매";
            }
            else
            {
                setText.text = "";
                buyText.text = "장착";
            }
        }
    }

    public void BuySkinBtn()
    {
        if (productName == 2)
        {
            UserStatic.muji = true;
            GameManager.Instance.endrophin -= 150;
        }
        else if (productName == 3)
        {
            UserStatic.egg = true;
            GameManager.Instance.endrophin -= 200;
        }
        else if (productName == 4)
        {
            UserStatic.star = true;
            GameManager.Instance.endrophin -= 250;
        }
        else if (productName == 5)
        {
            UserStatic.sun = true;
            GameManager.Instance.endrophin -= 300;
        }
        else if (productName == 6)
        {
            UserStatic.aboka = true;
            GameManager.Instance.endrophin -= 350;
        }
        SetProduct();
    }

    public void SetSkinBtn()
    {
        if(productName == 1)
        {
            GameManager.Instance.currentSkin = 1;
        }
        else if (productName == 2)
        {
            GameManager.Instance.currentSkin = 2;
        }
        else if (productName == 3)
        {
            GameManager.Instance.currentSkin = 3;
        }
        else if (productName == 4)
        {
            GameManager.Instance.currentSkin = 4;
        }
        else if (productName == 5)
        {
            GameManager.Instance.currentSkin = 5;
        }
        else if (productName == 6)
        {
            GameManager.Instance.currentSkin = 6;
        }
        SetProduct();
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }
}