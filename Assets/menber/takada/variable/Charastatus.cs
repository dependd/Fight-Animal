using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charastatus : MonoBehaviour {

    //キャラクターの変数に関するスクリプト

    [System.Serializable] //inspectorに表示

    //キャラクターのステータスをstructで管理
    public struct CharaStatus{

        public string Name; //名前
        public int HP; //体力
        public double NoteSpeed; //通常攻撃の速度
        public double DeadlyNoteSpeed; //必殺技の速度
        public double NoteLength; //通常攻撃の長さ
        public double DeadlyNoteLength; //必殺技の長さ
        public int OffensivePower; //攻撃力
        public double MinNoteFrequency; //ノーツの最低頻度
        public double MaxNoteFrequency; //ノーツの最高頻度

    }

    //キャラクターの宣言
    public CharaStatus tokage;
    public CharaStatus kame;
    public CharaStatus datyo;
    public CharaStatus momonga;
    public CharaStatus tinpan;
    public CharaStatus encho;

}
