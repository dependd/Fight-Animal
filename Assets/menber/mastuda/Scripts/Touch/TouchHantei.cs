using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHantei : MonoBehaviour {
    [HideInInspector]public bool toucjFlag = true;

    [SerializeField]
    GameControler gameControler;
    //ノーツの親オブジェクトを入れる変数
    [SerializeField]
    Transform partyNoteParent;
    [SerializeField]
    Transform enemyNoteParent;
    //ノーツのゲームオブジェクトを入れる変数
    [HideInInspector]
    public GameObject note1;
    [HideInInspector]
    public GameObject note2;
    [HideInInspector]
    public GameObject note3;
    [HideInInspector]
    public GameObject note4;
    [HideInInspector]
    public GameObject enemyNote1;
    [HideInInspector]
    public GameObject enemyNote2;
    [HideInInspector]
    public GameObject enemyNote3;
    [HideInInspector]
    public GameObject deadlyNote1;
    [HideInInspector]
    public GameObject deadlyNote2;
    [HideInInspector]
    public GameObject deadlyNote3;
    [HideInInspector]
    public GameObject deadlyNote4;
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
	[SerializeField]
	AudioClip enemyDefence;
    //tutorialControler
    [SerializeField]
    TutorialFlagManager tutorialFlagManager;

    //NoteFrequencyスクリプトに参照する
    NoteFrequency noteFrequency;


    //PlayMovieコンポーネント
    [SerializeField]
    PlayMovie tokagePlayMovie;
    [SerializeField]
    GameObject tokageEF;
    [SerializeField]
    PlayMovie datyoPlayMovie;
    [SerializeField]
    GameObject datyoEF;
    [SerializeField]
    PlayMovie momongaPlayMovie;
    [SerializeField]
    GameObject momongaEF;
    [SerializeField]
    PlayMovie kamePlayMovie;
    [SerializeField]
    GameObject kameEF;
    [SerializeField]
    PlayMovie enemyPlayMovie;
    [SerializeField]
    GameObject enemyEF;

    [SerializeField]
    GameObject countDownText;
    [SerializeField]
    CountDown countDown;
    // Use this for initialization
    void Start () {
        gameControler = GetComponent<GameControler>();

        //partyNoteParent = GameObject.Find("PartyNote").transform;
        //enemyNoteParent = GameObject.Find("EnemyNote").transform;
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
        if (BattleManager.Instance.nowBattleScene == 0) return;

        countDown = countDownText.GetComponent<CountDown>();
        StartCoroutine(countDown.CountdownCoroutine());
        
        tokagePlayMovie = tokageEF.GetComponent<PlayMovie>();
        datyoPlayMovie = datyoEF.GetComponent<PlayMovie>();
        momongaPlayMovie = momongaEF.GetComponent<PlayMovie>();
        kamePlayMovie = kameEF.GetComponent<PlayMovie>();
        enemyPlayMovie = enemyEF.GetComponent<PlayMovie>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!toucjFlag) return;
        //Touch myTouch = Input.GetTouch(0);

        Touch[] myTouches = Input.touches;
        //マルチタッチに対応する処理
        for (int i = 0; i < Input.touchCount; i++)
        {
            //enemyNoteにオブジェクトがある場合、対応するオブジェクトを格納
            if (enemyNoteParent.childCount > 0)
            {
                gameControler.InputNoteObject();
            }

            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
        }
        
        //クリックの取得
        if (Input.GetMouseButtonDown(0))
        {
            //enemyNoteにオブジェクトがある場合、対応するオブジェクトを格納
            if (enemyNoteParent.childCount > 0)
            {
                gameControler.InputNoteObject();
            }
            //クリック位置をワールド座標に変換
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            //敵の攻撃を防ぐ処理
            Debug.Log("クリックした座標は" + ray);
            if (ray.x >= -6.3 && ray.x <= -2.6)
            {
                if (ray.y >= -1.5 && ray.y <= 2.7)
                {
                    if (GameObject.Find("enemyNote1") == true)
                    {
                        if (gameControler.enemyLine1)
                        {
                            gameControler.DamageCut(enemyNote1, true);
                            tinpanAttackScript.AttackEffect("tinpan");
                            noteFrequency.NoteCreateFrequency("enemyNote1");
							audioSource.PlayOneShot(enemyDefence, 0.7f);
                            StartCoroutine(enemyPlayMovie.PlayOnMovie());
                        }
                        else if (enemyNote1.transform.position.x > -4 && enemyNote1.transform.position.x < -5 || enemyNote1.transform.position.x < -3 && enemyNote1.transform.position.x > -2)
                        {
                            gameControler.DamageCut(enemyNote1, false);
                            tinpanAttackScript.AttackEffect("tinpan");
                            noteFrequency.NoteCreateFrequency("enemyNote1");
                            audioSource.PlayOneShot(enemyATK, 0.7f);
                            StartCoroutine(enemyPlayMovie.PlayOnMovie());
                        }
                    }


                    if (GameObject.Find("enemyNote2") == true)
                    {
                        if (gameControler.enemyLine2)
                        {
                            gameControler.DamageCut(enemyNote2, true);
                            tinpanAttackScript.AttackEffect("tinpan");
                            noteFrequency.NoteCreateFrequency("enemyNote2");
							audioSource.PlayOneShot(enemyDefence, 0.7f);
                            StartCoroutine(enemyPlayMovie.PlayOnMovie());
                        }
                        else if (enemyNote2.transform.position.x > -4 && enemyNote2.transform.position.x < -5 || enemyNote2.transform.position.x < -3 && enemyNote2.transform.position.x > -2)
                        {
                            gameControler.DamageCut(enemyNote2, false);
                            tinpanAttackScript.AttackEffect("tinpan");
                            noteFrequency.NoteCreateFrequency("enemyNote2");
                            audioSource.PlayOneShot(enemyATK, 0.7f);
                            StartCoroutine(enemyPlayMovie.PlayOnMovie());
                        }
                    }
                    if (GameObject.Find("enemyNote3") == true)
                    {
                        if (gameControler.enemyLine3)
                        {
                            gameControler.DamageCut(enemyNote3, true);
                            tinpanAttackScript.AttackEffect("tinpan");
                            noteFrequency.NoteCreateFrequency("enemyNote3");
							audioSource.PlayOneShot(enemyDefence, 0.7f);
                            StartCoroutine(enemyPlayMovie.PlayOnMovie());
                        }
                        else if (enemyNote3.transform.position.x > -4 && enemyNote3.transform.position.x < -5 || enemyNote3.transform.position.x < -3 && enemyNote3.transform.position.x > -2)
                        {
                            gameControler.DamageCut(enemyNote3, false);
                            tinpanAttackScript.AttackEffect("tinpan");
                            noteFrequency.NoteCreateFrequency("enemyNote3");
                            audioSource.PlayOneShot(enemyATK, 0.7f);
                            StartCoroutine(enemyPlayMovie.PlayOnMovie());
                        }
                    }
                }
            }
            if (partyNoteParent.childCount > 0)
            {
                gameControler.InputNoteObject();
            }
            //1番目の勇者が攻撃する処理
            if (ray.x >= 2.6 && ray.x <= 6.1)
            {
                if (ray.y >= 2.4 && ray.y <= 3.6)
                {
                    if (GameObject.Find("datyonote") == true)
                    {
                        if (gameControler.datyoLine)
                        {
                            gameControler.AttackAnimal("ダチョウ", note1, true, CharaStatus.datyo.OffensivePower, false);
                            datyoAnimation.AttackAnimation();
                            datyoAttackScript.AttackEffect("datyo");
                            noteFrequency.NoteCreateFrequency("datyonote");
                            audioSource.PlayOneShot(datyoATK, 0.7f);
                            StartCoroutine(datyoPlayMovie.PlayOnMovie());
                        }
                        else if (note1.transform.position.x > 4 && note1.transform.position.x < 5 || note1.transform.position.x < 3 && note1.transform.position.x > 2)
                        {
                            gameControler.AttackAnimal("ダチョウ", note1, false, CharaStatus.datyo.OffensivePower, false);
                            noteFrequency.NoteCreateFrequency("datyonote");
                        }
                    }
                }
            }
            if (ray.x >= 2.6 && ray.x <= 6.1)
            {
                if (ray.y >= 2.4 && ray.y <= 3.6)
                {
                    if (GameObject.Find("datyodeadlyNote") == true)
                    {
                        if (gameControler.datyoLine)
                        {
                            gameControler.AttackAnimal("ダチョウ", deadlyNote1, true, CharaStatus.datyo.OffensivePower, true);
                            datyoAnimation.AttackAnimation();
                            tokageAttackScript.AttackEffect("datyo");
                            noteFrequency.NoteCreateFrequency("datyonote");
                            audioSource.PlayOneShot(datyoATK, 0.7f);
                            StartCoroutine(datyoPlayMovie.PlayOnMovie());
                        }
                        else if (deadlyNote1.transform.position.x > 3.8f && deadlyNote1.transform.position.x < 5 || deadlyNote1.transform.position.x < 3.2f && deadlyNote1.transform.position.x > 2)
                        {
                            gameControler.AttackAnimal("ダチョウ", deadlyNote1, false, CharaStatus.datyo.OffensivePower, true);
                            noteFrequency.NoteCreateFrequency("datyonote");
                        }
                    }
                }
            }
            //2番目の勇者が攻撃する時の処理
            if (ray.x >= 2.6 && ray.x <= 6.1)
            {
                if (ray.y >= 1 && ray.y < 2.2)
                {
                    if (GameObject.Find("tokagenote") == true)
                    {
                        if (gameControler.tokageLine)
                        {
                            gameControler.AttackAnimal("トカゲ", note2, true, CharaStatus.tokage.OffensivePower, false);
                            tokageAnimation.AttackAnimation();
                            tokageAttackScript.AttackEffect("tokage");
                            noteFrequency.NoteCreateFrequency("tokagenote");
                            audioSource.PlayOneShot(tokageATK, 0.7f);
                            StartCoroutine(tokagePlayMovie.PlayOnMovie());
                        }
                        else if (note2.transform.position.x > 4 && note2.transform.position.x < 5 || note2.transform.position.x < 3 && note2.transform.position.x > 2)
                        {
                            gameControler.AttackAnimal("トカゲ", note2, false, CharaStatus.tokage.OffensivePower, false);
                            noteFrequency.NoteCreateFrequency("tokagenote");
                        }
                    }
                }
            }
            if (ray.x >= 2.6 && ray.x <= 6.1)
            {
                if (ray.y >= 1 && ray.y < 2.2)
                {
                    if (GameObject.Find("tokagedeadlyNote") == true)
                    {
                        if (gameControler.tokageLine)
                        {
                            gameControler.AttackAnimal("トカゲ", deadlyNote2, true, CharaStatus.tokage.OffensivePower, true);
                            tokageAnimation.AttackAnimation();
                            tokageAttackScript.AttackEffect("tokage");
                            noteFrequency.NoteCreateFrequency("tokagenote");
                            audioSource.PlayOneShot(tokageATK, 0.7f);
                            StartCoroutine(tokagePlayMovie.PlayOnMovie());
                        }
                        else if (deadlyNote2.transform.position.x > 4 && deadlyNote2.transform.position.x < 5 || deadlyNote2.transform.position.x < 3 && deadlyNote2.transform.position.x > 2)
                        {
                            gameControler.AttackAnimal("トカゲ", deadlyNote2, false, CharaStatus.tokage.OffensivePower, true);
                            noteFrequency.NoteCreateFrequency("tokagenote");
                        }
                    }
                }
            }
            //3番目の勇者が攻撃するときの処理
            if (ray.x >= 2.6 && ray.x <= 6.1)
            {
                if (ray.y >= -0.4 && ray.y <= 0.6)
                {
                    if (GameObject.Find("momonganote") == true)
                    {
                        if (gameControler.momongaLine)
                        {
                            gameControler.AttackAnimal("モモンガ", note3, true, CharaStatus.momonga.OffensivePower, false);
                            momongaAnimation.AttackAnimation();
                            momongaAttackScript.AttackEffect("momonga");
                            noteFrequency.NoteCreateFrequency("momonganote");
                            audioSource.PlayOneShot(momongaATK, 0.7f);
                            StartCoroutine(momongaPlayMovie.PlayOnMovie());
                        }
                        else if (note3.transform.position.x > 4 && note3.transform.position.x < 5 || note3.transform.position.x < 3 && note3.transform.position.x > 2)
                        {
                            gameControler.AttackAnimal("モモンガ", note3, false, CharaStatus.momonga.OffensivePower, false);
                            noteFrequency.NoteCreateFrequency("momonganote");
                        }
                    }
                }
            }
            if (ray.x >= 2.6 && ray.x <= 6.1)
            {
                if (ray.y >= -0.4 && ray.y <= 0.6)
                {
                    if (GameObject.Find("momongadeadlyNote") == true)
                    {
                        if (gameControler.momongaLine)
                        {
                            gameControler.AttackAnimal("モモンガ", deadlyNote3, true, CharaStatus.momonga.OffensivePower, true);
                            momongaAnimation.AttackAnimation();
                            momongaAttackScript.AttackEffect("momonga");
                            noteFrequency.NoteCreateFrequency("momonganote");
                            audioSource.PlayOneShot(momongaATK, 0.7f);
                            StartCoroutine(momongaPlayMovie.PlayOnMovie());
                        }
                        else if (deadlyNote3.transform.position.x > 4 && deadlyNote3.transform.position.x < 5 || deadlyNote3.transform.position.x < 3 && deadlyNote3.transform.position.x > 2)
                        {
                            gameControler.AttackAnimal("モモンガ", deadlyNote3, false, CharaStatus.momonga.OffensivePower, true);
                            noteFrequency.NoteCreateFrequency("momonganote");
                        }
                    }
                }
            }
            //4番目の勇者が攻撃するときの処理
            if (ray.x >= 2.6 && ray.x <= 6.1)
            {
                if (ray.y >= -2.3 && ray.y <= -1.0)
                {
                    if (GameObject.Find("kamenote") == true)
                    {
                        if (gameControler.kameLine)
                        {
                            gameControler.AttackAnimal("カメ", note4, true, CharaStatus.kame.OffensivePower, false);
                            kameAnimation.AttackAnimation();
                            kameAttackScript.AttackEffect("kame");
                            noteFrequency.NoteCreateFrequency("kamenote");
                            audioSource.PlayOneShot(kameATK, 0.7f);
                            StartCoroutine(kamePlayMovie.PlayOnMovie());
                        }
                        else if (note4.transform.position.x > 4 && note4.transform.position.x < 5 || note4.transform.position.x < 3 && note4.transform.position.x > 2)
                        {
                            gameControler.AttackAnimal("カメ", note4, false, CharaStatus.kame.OffensivePower, false);
                            noteFrequency.NoteCreateFrequency("kamenote");
                        }
                    }
                }
            }
            if (ray.x >= 2.6 && ray.x <= 6.1)
            {
                if (ray.y >= -2.3 && ray.y <= -1.0)
                {
                    if (GameObject.Find("kamedeadlyNote") == true)
                    {
                        if (gameControler.kameLine)
                        {
                            gameControler.AttackAnimal("カメ", deadlyNote4, true, CharaStatus.kame.OffensivePower, true);
                            kameAnimation.AttackAnimation();
                            kameAttackScript.AttackEffect("kame");
                            noteFrequency.NoteCreateFrequency("kamenote");
                            audioSource.PlayOneShot(kameATK, 0.7f);
                            StartCoroutine(kamePlayMovie.PlayOnMovie());
                        }
                        else if (deadlyNote4.transform.position.x > 4 && deadlyNote4.transform.position.x < 5 || deadlyNote4.transform.position.x < 3 && deadlyNote4.transform.position.x > 2)
                        {
                            gameControler.AttackAnimal("カメ", deadlyNote4, false, CharaStatus.kame.OffensivePower, true);
                            noteFrequency.NoteCreateFrequency("kamenote");

                        }
                    }
                }
            }
        }
    }
}
