using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private SaveLoad SaveLoad;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] StatePlatform statePlatform;
    [HideInInspector] public bool GameOver = false, FirstPlatform = false;
    [SerializeField] private TextMeshProUGUI PlatformText, MoneyText, ScoreGameText, MaxScoreText;
    [SerializeField] private GameObject StartPlatForm, Lava;
    [SerializeField] private GameObject PlatformDef;
    [SerializeField] private AudioClip[] AudioClips;
    [SerializeField] private Transform[] SpawnCoin;
    [SerializeField] private GameObject Coin;
    private AudioSource AudioSource;
    private float RenTime = 0;
    private int ScorePlatform = 0, Money = 0, MaxScore;
    [HideInInspector] public int Score = 0;
    private Rigidbody2D Rigidbody;
    private float ForceJump;
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        AudioSource = GetComponent<AudioSource>();
        SaveLoad.Load();
        MaxScore = SaveLoad.ScoreLoad;
        GameOverPanel.SetActive(false);
        Instantiate(Coin, SpawnCoin[Random.Range(0, SpawnCoin.Length)]);
    }

    private void Update()
    {
        AddForceJump();
        MoneyText.text ="Money: "+ Money.ToString();
        ScoreGameText.text ="Final Score: " + (ScorePlatform + Money).ToString();
        PlatformText.text = "Score: "+ ScorePlatform.ToString();
        MaxScoreText.text = "MaxScore :" + MaxScore;
        GameObject[] PlatformInScene = GameObject.FindGameObjectsWithTag("Platform");
        if (PlatformInScene.Length < 2 && FirstPlatform == true)
        {
            GameObject Platform = Instantiate(PlatformDef, new Vector2(0, 6), Quaternion.identity);
            AudioSource.PlayOneShot(AudioClips[0]);
            Platform.GetComponent<SpriteRenderer>().sprite = statePlatform.PlatformState[Random.Range(0, statePlatform.PlatformState.Length)];
            Platform.transform.DOMoveY(2.5f, 3f);
        }
    }
    private float AddForceJump()
    {
        if (Input.GetKey(KeyCode.Space) )
        {
            RenTime += 100;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            ForceJump =Mathf.Clamp(RenTime, 0, 11000);
            Rigidbody.AddForce(Vector2.up * Time.deltaTime * ForceJump * 10);
            AudioSource.PlayOneShot(AudioClips[1]);
            RenTime = 0;
        }
        return ForceJump;  
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        this.transform.parent = collision.transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.tag == ("Trap"))
         {
           Score = ScorePlatform + Money;
           if(Score > SaveLoad.ScoreLoad)
           {
                MaxScore = Score;
                SaveLoad.Save();
           }
            GameOver = true;
            if (!AudioSource.isPlaying && GameOver==true)
            {
                AudioSource.PlayOneShot(AudioClips[2]);
            }
            GameOverPanel.SetActive(true);
         }
         if(collision.tag == ("Coin"))
         {
            Money += 1;
            AudioSource.PlayOneShot(AudioClips[3]);
            Destroy(collision.gameObject);
            Instantiate(Coin, SpawnCoin[Random.Range(0, SpawnCoin.Length)]);
         }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Platform"))
        {
            ScorePlatform += 1;
            StartCoroutine("StartFlor"); 
        }
    }
    IEnumerator StartFlor()
    {
        yield return new WaitForSeconds(1.5f);
        StartPlatForm.transform.DOMoveY(-6f, 2f);
        Lava.transform.DOMoveY(-7, 1f);
        FirstPlatform = true;
    }
}
