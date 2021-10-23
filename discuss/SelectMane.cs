using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMane : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SelectWindow;
    public GameObject Arrow;
    
    //Arrowの位置が上ならarrow1、下ならarrow2
    //選択肢は4つまで（ウディタと同じ）
    public Text select;
    public static int windowSelect = 0;
    // windowSelect は0の時標準、１になるとウィンドウを表示、2で表示状態を保存
    // windowSelectを操作することで、「選択肢」が存在することを指示
    public static int windowSelectQuit = 0;
    public static string textSelect = "";

    public int ArrowPos = 1;
    private int ArrowNowPos = 1;
    public static int SelectResult =0;
    //選択した結果をここに格納する

    


    void Start()
    {
        SelectWindow.SetActive(false);
        Arrow.SetActive(false);
        



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (windowSelect ==1)
		{
            SelectWindowSet();
            windowSelect = 2;


        }
        if (windowSelect ==2)
		{

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                SelectResult = ReturnResult();
                SelectWindowQuit();

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (ArrowPos == 4)
                {
                    ArrowPos = 1;
                }
                else
                {
                    ArrowPos++;
                }

            }
            if (ArrowNowPos != ArrowPos)
			{
                ArrowNowPos = ArrowPos;
                Vector3 position = Arrow.GetComponent<RectTransform>().anchoredPosition;
                if (ArrowNowPos == 1)
                {
                    position.y = 100f;
                    Arrow.GetComponent<RectTransform>().anchoredPosition = position;
                }

                else if (ArrowNowPos == 2)
                {
                    position.y = 30f;
                    Arrow.GetComponent<RectTransform>().anchoredPosition = position;
                }
                else if (ArrowNowPos == 3)
                {
                    position.y =-40f;
                    Arrow.GetComponent<RectTransform>().anchoredPosition = position;
                }
                else if (ArrowNowPos == 4)
                {
                    position.y = -110f;
                    Arrow.GetComponent<RectTransform>().anchoredPosition = position;
                }                
            }
            
        }
        
    }

    public void SelectWindowSet()
    {
        SelectWindow.SetActive(true);
        Arrow.SetActive(true);
        select.text = textSelect;
        SelectResult = 0;
        //選択肢を表示するときに、選択結果をリセット


    }
    public void SelectWindowQuit()
    {
        SelectWindow.SetActive(false);
        Arrow.SetActive(false);
        ArrowPos = 1;
        textSelect = "";
        windowSelect = 0;
        winMane.IsSelectWin = 0;
    }

    public int ReturnResult()
	{
       return ArrowNowPos;
	}
}
