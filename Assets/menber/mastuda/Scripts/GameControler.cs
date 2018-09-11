
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
        AllCharaPartyDefence();
        hp.DownPartyHp(i, attakePower);
        if(hp.partyhp <= 0)
        {
            StartCoroutine(BattleLose());
            scenarioText.ChengeScenarioText("負けてしまった...orz");
        }
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
            if (hp.enemyhp <= 0)
            {
                scenarioText.ChengeScenarioText("敵を倒した！！");
                StartCoroutine(BattleWin());
                return;
            }
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
    private void AllCharaPartyDefence()
    {
        datyoAnimation.DamegeAnimation();
        tokageAnimation.DamegeAnimation();
        momongaAnimation.DamegeAnimation();
        kameAnimation.DamegeAnimation();
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
    public IEnumerator BattleWin()
    {
        GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");
        for (int i = 0; i < notes.Length; i++)
        {
            notes[i].SetActive(false);
        }
        if (BattleManager.Instance.nowBattleScene == 2)
        {
            tinpanAnimation.DownAnimation();
            yield return new WaitForSeconds(3.0f);
            SceneManager.LoadScene("Win3");
        }
        else if (BattleManager.Instance.nowBattleScene == 1)
        {
            tinpanAnimation.DownAnimation();
            yield return new WaitForSeconds(3.0f);
            SceneManager.LoadScene("Win2");
        }
        else
        {
            tinpanAnimation.DownAnimation();
            yield return new WaitForSeconds(3.0f);
            SceneManager.LoadScene("Win");
        }
    }
    public IEnumerator BattleLose()
    {
        GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");
        for (int i = 0; i < notes.Length; i++)
        {
            notes[i].SetActive(false);
        }
        datyoAnimation.DownAnimation();
        yield return new WaitForSeconds(1.0f);

        tokageAnimation.DownAnimation();
        yield return new WaitForSeconds(1.0f);

        momongaAnimation.DownAnimation();
        yield return new WaitForSeconds(1.0f);

        kameAnimation.DownAnimation();
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("GameOver");
    }
    
}
