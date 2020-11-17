using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public MovePlayer Player;
    public Transform MainCamera;
    private float shakeX = 0.05f, shakeY = 0.05f;
    private bool CameraShake = false;
    private Vector3 OriginPlaceCamera;
    private AudioSource FonAudio;
    void Start()
    {
        OriginPlaceCamera = MainCamera.localPosition;
        FonAudio = GetComponent<AudioSource>();
    }
    IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.5f);
        Player.GameOver = false;
        MainCamera.transform.localPosition = OriginPlaceCamera;

    }
    private void LateUpdate()
    {
        if (Player.GameOver == true)
        {
            Vector3 Shake = new Vector3(Random.Range(-shakeX, shakeX), Random.Range(-shakeY, shakeY), 0);
            MainCamera.transform.localPosition += Shake;
            StartCoroutine("Pause");
            FonAudio.Stop();
        }
    }
}
