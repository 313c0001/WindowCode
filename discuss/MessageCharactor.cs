using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MessageCharactor : FieldObjectBase
{

    // セリフ : Unityのインスペクタ(UI上)で会話文を定義する 
    // （次項 : インスペクタでscriptを追加して、設定をする で説明）
    [SerializeField]
    private List<string> messages;

    // 親クラスから呼ばれるコールバックメソッド (接触 & ボタン押したときに実行)
    protected override IEnumerator OnAction()
    {

        for (int i = 0; i < messages.Count; ++i)
        {
            // 1フレーム分 処理を待機(下記説明1)
            yield return null;

            // 会話をwindowのtextフィールドに表示
            showMessage(messages[i]);

            // キー入力を待機 (下記説明1)
            yield return new WaitUntil(() => Input.anyKeyDown);
        }

        yield break;
    }
}