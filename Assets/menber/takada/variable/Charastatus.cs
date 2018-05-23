using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charastatus : MonoBehaviour {

    //キャラクターの変数に関するスクリプト
    public class Chara
    {
        //キャラごとのステータス
        public string Name; //名前
        public double NoteSpeed; //通常攻撃の速度
        public double DeadlyNoteSpeed; //必殺技の速度
        public double NoteLength; //通常攻撃の長さ
        public double DeadlyNoteLength; //必殺技の長さ
        public int OffensivePower; //攻撃力
        public double NoteFrequency; //ノーツの頻度
    }

    public class Animal : Chara
    {
        public int AnimalHp; //勇者陣営のHP
    }

    public class Enemy : Chara
    {
        public int EnemyHp; //敵陣営のHP
    }
     public void Charactor(){

        Animal tokage = new Animal();
        tokage.Name = "トカゲ";
        tokage.NoteSpeed = 0.1;
        tokage.DeadlyNoteSpeed = 0.12;
        tokage.NoteLength = 1;
        tokage.DeadlyNoteLength = 0.5;
        tokage.OffensivePower = 10;

        Animal kame = new Animal();
        kame.Name = "カメ";
        kame.NoteSpeed = 0.05;
        kame.DeadlyNoteSpeed = 0.1;
        kame.NoteLength = 1;
        kame.DeadlyNoteLength = 0.5;
        kame.OffensivePower = 10;

        Animal datyo = new Animal();
        datyo.Name = "ダチョウ";
        datyo.NoteSpeed = 0.12;
        datyo.DeadlyNoteSpeed = 0.15;
        datyo.NoteLength = 1;
        datyo.DeadlyNoteLength = 0.5;
        datyo.OffensivePower = 10;

        Animal momonga = new Animal();
        momonga.Name = "モモンガ";
        momonga.NoteSpeed = 0.1;
        momonga.DeadlyNoteSpeed = 0.12;
        momonga.NoteLength = 1;
        momonga.DeadlyNoteLength = 0.5;
        momonga.OffensivePower = 10;

        Enemy tinpan = new Enemy();
        tinpan.Name = "チンパンジー";
        tinpan.NoteSpeed = 0.1;
        tinpan.DeadlyNoteSpeed = 0;
        tinpan.NoteLength = 1;
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
