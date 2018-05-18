using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charastatus : MonoBehaviour {

    //キャラクターの変数に関するスクリプト
    class Chara
    {
        //キャラごとのステータス
        public string Name; //名前
        public float NoteSpeed; //通常攻撃の速度
        public float DeadlyNoteSpeed; //必殺技の速度
        public float NoteLength; //通常攻撃の長さ
        public float DeadlyNoteLength; //必殺技の長さ
        public int OffensivePower; //攻撃力
    }

    class Animal : Chara
    {
        public int AnimalHp; //勇者陣営のHP
    }

    class Enemy : Chara
    {
        public int EnemyHp; //敵陣営のHP
    }
     public void Charactor(){

        Animal tokage = new Animal();
        tokage.Name = "トカゲ";
        tokage.NoteSpeed = 0;
        tokage.DeadlyNoteSpeed = 0;
        tokage.NoteLength = 0;
        tokage.DeadlyNoteLength = 0;
        tokage.OffensivePower = 10;

        Animal kame = new Animal();
        kame.Name = "カメ";
        kame.NoteSpeed = 0;
        kame.DeadlyNoteSpeed = 0;
        kame.NoteLength = 0;
        kame.DeadlyNoteLength = 0;
        kame.OffensivePower = 10;

        Animal datyo = new Animal();
        datyo.Name = "ダチョウ";
        datyo.NoteSpeed = 0;
        datyo.DeadlyNoteSpeed = 0;
        datyo.NoteLength = 0;
        datyo.DeadlyNoteLength = 0;
        datyo.OffensivePower = 10;

        Animal momonga = new Animal();
        momonga.Name = "モモンガ";
        momonga.NoteSpeed = 0;
        momonga.DeadlyNoteSpeed = 0;
        momonga.NoteLength = 0;
        momonga.DeadlyNoteLength = 0;
        momonga.OffensivePower = 10;

        Enemy tinpan = new Enemy();
        tinpan.Name = "チンパンジー";
        tinpan.NoteSpeed = 0;
        tinpan.DeadlyNoteSpeed = 0;
        tinpan.NoteLength = 0;
        tinpan.DeadlyNoteLength = 0;
        tinpan.OffensivePower = 10;
        tinpan.EnemyHp = 800;

        Enemy encho = new Enemy();
        encho.Name = "園長";
        encho.NoteSpeed = 0;
        encho.DeadlyNoteSpeed = 0;
        encho.NoteLength = 0;
        encho.DeadlyNoteLength = 0;
        encho.OffensivePower = 10;
        encho.EnemyHp = 800;

     }
}
