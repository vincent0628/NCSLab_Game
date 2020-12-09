using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer: MonoBehaviour {

  public Image loading;
  public Text timeText;
  private int minutes = 0;
  private int sec = 5;
  int totalSeconds = 0;
  int TOTAL_SECONDS = 0;
  float fillamount;

  void Start() {
    timeText.text = string.Format("{0:00}:{1:00}", minutes, sec);
    // fillLoading();
    if (minutes > 0) totalSeconds += minutes * 60;
    if (sec > 0) totalSeconds += sec;
    TOTAL_SECONDS = totalSeconds;
    StartCoroutine(second());
  }

  void Update() {
    if (sec == 0 && minutes == 0) {
      timeText.text = "Over!";
      StopCoroutine(second());
      FindObjectOfType<GameManager>().EndGame();
    }
  }
  IEnumerator second() {
    yield
    return new WaitForSeconds(1f);
    if (sec > 0) sec--;
    if (sec == 0 && minutes != 0) {
      sec = 60;
      minutes--;
    }
    timeText.text = string.Format("{0:00}:{1:00}", minutes, sec);
    fillLoading();
    StartCoroutine(second());
  }

  void fillLoading() {
    totalSeconds--;
    float fill = (float) totalSeconds / TOTAL_SECONDS;
    loading.fillAmount = fill;
  }
}