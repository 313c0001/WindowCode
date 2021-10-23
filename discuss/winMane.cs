using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class winMane : MonoBehaviour
{
    public GameObject mainwindow;  
        public int windowsta = 0;
    public static int windowOn =0;
    // windowOn は0の時標準、１になるとウィンドウを表示、2で表示状態を保存
    public static int windowOut = 0;
    // windowout は0の時標準、１になるとウィンドウを表示、2で表示状態を保存
    public static int IsSelectWin = 0;
    // IsSelectWinが1のとき、選択肢を表示する。
    // IsSelectWinが1のとき、選択肢が表示されているためmainwinは動作しない。
      
    public static string textMain = "";
    public Canvas window;
    public Text main;

    void Start()
    {
        mainwindow.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
       if  (windowOn == 1)
		{
            windowSet();
            windowOn = 2;
		}
       else if (windowOn == 2)
		{
           if (IsSelectWin == 1)
			{
                SelectMane.windowSelect = 1;
                IsSelectWin = 2;

			}            
           else if (windowOut ==1　&& IsSelectWin ==0)
			{
                windowQuit();
                windowOut = 0;
                windowOn = 0;
            }
            
		}
    }

    public void windowSet()
	{
        mainwindow.SetActive(true);
        main.text = textMain;
        PlayController.gameState = "stop";

    }
    public void windowQuit()
	{
        mainwindow.SetActive(false);
        PlayController.gameState = "playing";
        textMain = "";
    }

    
}
