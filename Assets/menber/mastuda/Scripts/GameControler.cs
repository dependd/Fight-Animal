
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameControler : MonoBehaviour{
    //カウントダウンをするためオブジェクト、スクリプトを入れるの変数
    [SerializeField]
    GameObject countDownText;
    [SerializeField]
    CountDown countDown;
    //乱数を入れる変数
    int random;
    //ノーツの親オブジェクトを入れる変数
    Transform partyNoteParent;
    Transform enemyNoteParent;
    //ノーツのゲームオブジェクトを入れる変数
    GameObject note1;
    GameObject note2;
    GameObject note3;
    GameObject note4;
    GameObject enemyNote1;
    GameObject enemyNote2;
    GameObject enemyNote3;
    GameObject deadlyNote1;
    GameObject deadlyNote2;
    GameObject deadlyNote3;
    GameObject deadlyNote4;
    //hpスクリプトに参照するための変数
    GameObject notes;
    hp hp;
    //noteスクリプトに参照するための変数
    GameObject partyNote;
    note note;
    //enemynoteスクリプトに参照するための変数
    GameObject enemyNote;
    enemynote enemynote;
    //Charastatusスクリプトに参照するための変数
    Charastatus CharaStatus;
    //ScenarioTextスクリプトに参照するための変数
    GameObject text;
    ScenarioText scenarioText;
    //
    GameObject chara;
    ScinarioChara scenarioChara;
    //各キャラのCharaAnimationスクリプトに参照するための変数
    [SerializeField]
    CharaAnimation datyoAnimation;
    [SerializeField]
    GameObject datyo;
    [SerializeField]
    CharaAnimation tokageAnimation;
    [SerializeField]
    GameObject tokage;
    [SerializeField]
    CharaAnimation momongaAnimation;
    [SerializeField]
    GameObject momonga;
    [SerializeField]
    CharaAnimation kameAnimation;
    [SerializeField]
    GameObject kame;
    [SerializeField]
    CharaAnimation tinpanAnimation;
    [SerializeField]
    GameObject tinpan;
    [SerializeField]
    GameObject datyoAttack;
    [SerializeField]
    CharaAnimation datyoAttackScript;
    [SerializeField]
    GameObject tokageAttack;
    [SerializeField]
    CharaAnimation tokageAttackScript;
    [SerializeField]
    GameObject momongaAttack;
    [SerializeField]
    CharaAnimation momongaAttackScript;
    [SerializeField]
    GameObject kameAttack;
    [SerializeField]
    CharaAnimation kameAttackScript;
    [SerializeField]
    GameObject tinpanAttack;
    [SerializeField]
    CharaAnimation tinpanAttackScript;
    //BGMを入れる変数
    AudioSource audioSource;
    //SEを入れる変数
    [SerializeField]
    AudioClip datyoATK;
    [SerializeField]
    AudioClip tokageATK;
    [SerializeField]
    AudioClip momongaATK;
    [SerializeField]
    AudioClip kameATK;
    [SerializeField]
    AudioClip enemyATK;
    //tutorialControler
    [SerializeField]
    TutorialFlagManager tutorialFlagManager;
    
    //NoteFrequencyスクリプトに参照する
    NoteFrequency noteFrequency;
    //判定ラインにオブジェクトが乗っているかの判定をする
    public bool enemyLine1 = false;
    public bool enemyLine2 = false;
    public bool enemyLine3 = false;
    public bool datyoLine = false;
    public bool tokageLine = false;
    public bool momongaLine = false ;
    public bool kameLine = false;
    //TouchHanteiスクリプトに参照する
    TouchHantei touchHantei;

    void Awake(){

        partyNoteParent = GameObject.Find("PartyNote").transform;
        enemyNoteParent = GameObject.Find("EnemyNote").transform;
        //それぞれの変数にオブジェクトを格納する
        //enemySliderのhpスクリプトを取得
        notes = GameObject.Find("enemySlider");
        hp = notes.GetComponent<hp>();
        //CharaStatusスクリプトを取得
        CharaStatus = GetComponent<Charastatus>();
        //partyNoteのnoteスクリプトを取得
        partyNote = GameObject.Find("PartyNote");
        note = partyNote.GetComponent<note>();
        //Frequencyスクリプト取得
        noteFrequency = partyNote.GetComponent<NoteFrequency>();
        //TouchHanteiスクリプト取得
        touchHantei = GetComponent<TouchHantei>();
        //enemyNoteのenemynoteスクリプトを取得
        enemyNote = GameObject.Find("EnemyNote");
        enemynote = enemyNote.GetComponent<enemynote>();
        //ScenairoTextのScenarioTextスクリプトを取得
        text = GameObject.Find("ScenarioText");
        scenarioText = text.GetComponent<ScenarioText>();
        //ScenarioCharaのScenarioCharaスクリプトを取得
        chara = GameObject.Find("Image");
        scenarioChara = chara.GetComponent<ScinarioChara>();
        //BGMスタート
        audioSource = GetComponent<AudioSource>();
        
    }
    /*
    void Update(){

        //Touch myTouch = Input.GetTouch(0);
        
        Touch[] myTouches = Input.touches;
        //マルチタッチに対応する処理
        for (int i = 0; i < Input.touchCount; i++)
        {
            //enemyNoteにオブジェクトがある場合、対応するオブジェクトを格納
            if (enemyNoteParent.childCount > 0)
            {
                InputNoteObject();
            }

            Vector3 ray = Camera.main.WorldToScreenPoint(Input.touches[i].position);
        }
        
        //クリックの取得
        if (Input.GetMouseButtonDown(0)) {
            //enemyNoteにオブジェクトがある場合、対応するオブジェクトを格納
            if (enemyNoteParent.childCount > 0)
            {
                InputNoteObject();
            }
            //クリック位置をワールド座標に変換
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            //敵の攻撃を防ぐ処理
            Debug.Log("クリックした座標は" + ray);
            if (ray.x >= -6.3 && ray.x <= -4.1){
                if (ray.y >= -1.5 && ray.y <= 2.7){
                    if(GameObject.Find("enemyNote1") == true ){
                        if (enemyLine1){
                            DamageCut(enemyNote1, true);
                            tinpanAttackScript.AttackEffect("tinpan");
                            AllCharaPartyDamage();
                            noteFrequency.NoteCreateFrequency("enemyNote1");
                            //audioSource.PlayOneShot(enemyATK, 0.7f);
                        }
                        else if (enemyNote1.transform.position.x > -4 && enemyNote1.transform.position.x < -5 || enemyNote1.transform.position.x < -3 && enemyNote1.transform.position.x > -2){
                            DamageCut(enemyNote1, false);
                            tinpanAttackScript.AttackEffect("tinpan");
                            noteFrequency.NoteCreateFrequency("enemyNote1");
                            //audioSource.PlayOneShot(enemyATK, 0.7f);
                        }
                    }


                    if(GameObject.Find("enemyNote2") == true)
                    {
                        if (enemyLine2){
                            DamageCut(enemyNote2, true);
                            tinpanAttackScript.AttackEffect("tinpan");
                            noteFrequency.NoteCreateFrequency("enemyNote2");
                            AllCharaPartyDamage();
                            //audioSource.PlayOneShot(enemyATK, 0.7f);
                        }
                        else if (enemyNote2.transform.position.x > -4 && enemyNote2.transform.position.x < -5 || enemyNote2.transform.position.x < -3 && enemyNote2.transform.position.x > -2){
                            DamageCut(enemyNote2, false);
                            tinpanAttackScript.AttackEffect("tinpan");
                            noteFrequency.NoteCreateFrequency("enemyNote2");
                            //audioSource.PlayOneShot(enemyATK, 0.7f);
                        }
                    }
                    if(GameObject.Find("enemyNote3") == true)
                    {
                        if (enemyLine3){
                            DamageCut(enemyNote3, true);
                            tinpanAttackScript.AttackEffect("tinpan");
                            noteFrequency.NoteCreateFrequency("enemyNote3");
                            AllCharaPartyDamage();
                            //audioSource.PlayOneShot(enemyATK, 0.7f);
                        }
                        else if (enemyNote3.transform.position.x > -4 && enemyNote3.transform.position.x < -5 || enemyNote3.transform.position.x < -3 && enemyNote3.transform.position.x > -2){
                            DamageCut(enemyNote3, false);
                            tinpanAttackScript.AttackEffect("tinpan");
                            noteFrequency.NoteCreateFrequency("enemyNote3");
                            //audioSource.PlayOneShot(enemyATK, 0.7f);
                        }
                    }
                }
            }
            if(partyNoteParent.childCount > 0){
                InputNoteObject();
            }
            //1番目の勇者が攻撃する処理
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= 2.4 && ray.y <= 3.6){
                    if (GameObject.Find("datyonote") == true){
                        if (datyoLine){
                            AttackAnimal("ダチョウ",note1, true, CharaStatus.datyo.OffensivePower, false);
                            datyoAnimation.AttackAnimation();
                            datyoAttackScript.AttackEffect("datyo");
                            noteFrequency.NoteCreateFrequency("datyonote");
                            audioSource.PlayOneShot(datyoATK, 0.7f);
                        }
                        else if (note1.transform.position.x > 4 && note1.transform.position.x < 5 || note1.transform.position.x < 3 && note1.transform.position.x > 2){
                            AttackAnimal("ダチョウ",note1, false, CharaStatus.datyo.OffensivePower, false);
                            noteFrequency.NoteCreateFrequency("datyonote");
                        }
                    }
                }
            }
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= 2.4 && ray.y <= 3.6){
                    if(GameObject.Find("datyodeadlyNote") == true){
                        if (datyoLine){
                            AttackAnimal("ダチョウ",deadlyNote1, true, CharaStatus.datyo.OffensivePower, true);
                            datyoAnimation.AttackAnimation();
                            tokageAttackScript.AttackEffect("datyo");
                            noteFrequency.NoteCreateFrequency("datyonote");
                            audioSource.PlayOneShot(datyoATK, 0.7f);
                        }
                        else if (deadlyNote1.transform.position.x > 3.8f && deadlyNote1.transform.position.x < 5 || deadlyNote1.transform.position.x < 3.2f && deadlyNote1.transform.position.x > 2){
                            AttackAnimal("ダチョウ",deadlyNote1, false, CharaStatus.datyo.OffensivePower, true);
                            noteFrequency.NoteCreateFrequency("datyonote");
                        }
                    }
                }
            }
            //2番目の勇者が攻撃する時の処理
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= 1 && ray.y < 2.2){
                    if (GameObject.Find("tokagenote") == true){
                        if (tokageLine){
                            AttackAnimal("トカゲ",note2, true, CharaStatus.tokage.OffensivePower, false);
                            tokageAnimation.AttackAnimation();
                            tokageAttackScript.AttackEffect("tokage");
                            noteFrequency.NoteCreateFrequency("tokagenote");
                            audioSource.PlayOneShot(tokageATK,0.7f);
                        }
                        else if (note2.transform.position.x > 4 && note2.transform.position.x < 5 || note2.transform.position.x < 3 && note2.transform.position.x > 2){
                            AttackAnimal("トカゲ",note2, false, CharaStatus.tokage.OffensivePower, false);
                            noteFrequency.NoteCreateFrequency("tokagenote");
                        }
                    }
                }
            }
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= 1 && ray.y < 2.2){
                    if (GameObject.Find("tokagedeadlyNote") == true){
                        if (tokageLine){
                            AttackAnimal("トカゲ",deadlyNote2, true, CharaStatus.tokage.OffensivePower, true);
                            tokageAnimation.AttackAnimation();
                            tokageAttackScript.AttackEffect("tokage");
                            noteFrequency.NoteCreateFrequency("tokagenote");
                            audioSource.PlayOneShot(tokageATK, 0.7f);
                        }
                        else if (deadlyNote2.transform.position.x > 4 && deadlyNote2.transform.position.x < 5 || deadlyNote2.transform.position.x < 3 && deadlyNote2.transform.position.x > 2){
                            AttackAnimal("トカゲ",deadlyNote2, false, CharaStatus.tokage.OffensivePower, true);
                            noteFrequency.NoteCreateFrequency("tokagenote");
                        }
                    }
                }
            }
            //3番目の勇者が攻撃するときの処理
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= -0.4 && ray.y <= 0.6){
                    if(GameObject.Find("momonganote") == true){
                        if (momongaLine){
                            AttackAnimal("モモンガ",note3, true, CharaStatus.momonga.OffensivePower, false);
                            momongaAnimation.AttackAnimation();
                            momongaAttackScript.AttackEffect("momonga");
                            noteFrequency.NoteCreateFrequency("momonganote");
                            audioSource.PlayOneShot(momongaATK, 0.7f);
                        }
                        else if (note3.transform.position.x > 4 && note3.transform.position.x < 5 || note3.transform.position.x < 3 && note3.transform.position.x > 2){
                            AttackAnimal("モモンガ",note3, false, CharaStatus.momonga.OffensivePower, false);
                            noteFrequency.NoteCreateFrequency("momonganote");
                        }
                    }
                }
            }
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= -0.4 && ray.y <= 0.6){
                    if(GameObject.Find("momongadeadlyNote") == true){
                        if (momongaLine){
                            AttackAnimal("モモンガ",deadlyNote3, true, CharaStatus.momonga.OffensivePower, true);
                            momongaAnimation.AttackAnimation();
                            momongaAttackScript.AttackEffect("momonga");
                            noteFrequency.NoteCreateFrequency("momonganote");
                            audioSource.PlayOneShot(momongaATK, 0.7f);
                        }
                        else if (deadlyNote3.transform.position.x > 4 && deadlyNote3.transform.position.x < 5 || deadlyNote3.transform.position.x < 3 && deadlyNote3.transform.position.x > 2){
                            AttackAnimal("モモンガ",deadlyNote3, false, CharaStatus.momonga.OffensivePower, true);
                            noteFrequency.NoteCreateFrequency("momonganote");
                        }
                    }
                }
            }
            //4番目の勇者が攻撃するときの処理
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= -2.3 && ray.y <= -1.0){
                    if (GameObject.Find("kamenote") == true){
                        if (kameLine){
                            AttackAnimal("カメ",note4, true, CharaStatus.kame.OffensivePower, false);
                            kameAnimation.AttackAnimation();
                            kameAttackScript.AttackEffect("kame");
                            noteFrequency.NoteCreateFrequency("kamenote");
                            audioSource.PlayOneShot(kameATK, 0.7f);
                        }
                        else if (note4.transform.position.x > 4 && note4.transform.position.x < 5 || note4.transform.position.x < 3 && note4.transform.position.x > 2){
                            AttackAnimal("カメ",note4, false, CharaStatus.kame.OffensivePower, false);
                            noteFrequency.NoteCreateFrequency("kamenote");
                        }
                    }
                }
            }
            if (ray.x >= 4.1 && ray.x <= 6.1){
                if (ray.y >= -2.3 && ray.y <= -1.0){
                    if(GameObject.Find("kamedeadlyNote") == true){
                        if (kameLine){
                            AttackAnimal("カメ",deadlyNote4, true, CharaStatus.kame.OffensivePower, true);
                            kameAnimation.AttackAnimation();
                            kameAttackScript.AttackEffect("kame");
                            noteFrequency.NoteCreateFrequency("kamenote");
                            audioSource.PlayOneShot(kameATK, 0.7f);
                        }
                        else if (deadlyNote4.transform.position.x > 4 && deadlyNote4.transform.position.x < 5 || deadlyNote4.transform.position.x < 3 && deadlyNote4.transform.position.x > 2){
                            AttackAnimal("カメ",deadlyNote4, false, CharaStatus.kame.OffensivePower, true);
                            noteFrequency.NoteCreateFrequency("kamenote");

                        }
                    }
                }
            }
        }
    }
    */
	public void PlayOnShot(){
		audioSource.PlayOneShot(enemyATK, 0.7f);
	}
    //enemyNoteをタップしたときの軽減があるかどうかの判定をする関数
    public void DamageCut(GameObject notes,bool i){
        //ノーツの削除
        Destroy(notes);
        //防御成功か
        if(i == true){
            scenarioText.ChengeScenarioText("防御成功");
        } else {
            scenarioText.ChengeScenarioText("防御失敗");
        }
        int attakePower = 0;
        switch (BattleManager.Instance.nowBattleScene)
        {
            case 0:
                attakePower = CharaStatus.tinpan.OffensivePower;
                break;
            case 1:
                attakePower = CharaStatus.tinpan.OffensivePower;
                break;
            case 2:
                attakePower = CharaStatus.encho.OffensivePower;
                break;
            default:
                break;
                
        }
        hp.DownPartyHp(i, attakePower);
    }
    //勇者が攻撃する関数
    public void AttackAnimal(string animalName,GameObject notes,bool hantei,int power,bool deadly){
        Destroy(notes);
        //攻撃成功かどうかの判定
        if(hantei == true){
            //必殺ノーツかどうかの判定
            if(deadly == true){
                power = power * 2;
                scenarioText.ChengeScenarioText(animalName + "必殺技\n" + power + "ダメージを与えた");
                //scenarioChara.PopUpChara(animalName);
            } else　{
                scenarioText.ChengeScenarioText(animalName + "攻撃\n" + power + "ダメージを与えた");
            }
            hp.DownEnemyHp(power);
            tinpanAnimation.DamegeAnimation();
        } else {
            scenarioText.ChengeScenarioText(animalName + "攻撃失敗\n");
        }
    }
    //防御成功時の全員の防御アニメーション
    public void AllCharaPartyDamage()
    {
        datyoAnimation.DefenceAnimation();
        tokageAnimation.DefenceAnimation();
        momongaAnimation.DefenceAnimation();
        kameAnimation.DefenceAnimation();
    }
    //ノーツを探し、格納する
    public void InputNoteObject(){
        if (GameObject.Find("datyonote") == true){
            touchHantei.note1 = GameObject.Find("datyonote");
        }
        if (GameObject.Find("tokagenote") == true){
            touchHantei.note2 = GameObject.Find("tokagenote");
        }
        if (GameObject.Find("momonganote") == true){
            touchHantei.note3 = GameObject.Find("momonganote");
        }
        if (GameObject.Find("kamenote") == true){
            touchHantei.note4 = GameObject.Find("kamenote");
        }
        if (GameObject.Find("enemyNote1") == true){
            touchHantei.enemyNote1 = GameObject.Find("enemyNote1");
        }
        if (GameObject.Find("enemyNote2") == true){
            touchHantei.enemyNote2 = GameObject.Find("enemyNote2");
        }
        if (GameObject.Find("enemyNote3") == true){
            touchHantei.enemyNote3 = GameObject.Find("enemyNote3");
        }
        if (GameObject.Find("datyodeadlyNote") == true){
            touchHantei.deadlyNote1 = GameObject.Find("datyodeadlyNote");
        }
        if (GameObject.Find("tokagedeadlyNote") == true){
            touchHantei.deadlyNote2 = GameObject.Find("tokagedeadlyNote");
        }
        if (GameObject.Find("momongadeadlyNote") == true){
            touchHantei.deadlyNote3 = GameObject.Find("momongadeadlyNote");
        }
        if (GameObject.Find("kamedeadlyNote") == true){
            touchHantei.deadlyNote4 = GameObject.Find("kamedeadlyNote");
        }
    }
}
