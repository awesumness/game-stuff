using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class clickUpScript : MonoBehaviour {

  Color DEFAULT_COLOR = Color.black;
  float DELAY_MIN = 1f;
  float DELAY_MAX = 5f;
  Color FLASH_COLOR = Color.gray;
  string TIME_TEXT_NAME = "TimerText";

  float flashTriggerTime;
  SpriteRenderer spriteRenderer;
  Text timerText;
  bool hasDisplayedClickUp = false;
  float startTime;


  // Use this for initialization
  void Start() {
    spriteRenderer = this.GetComponent<SpriteRenderer>();
    timerText = GameObject.Find(TIME_TEXT_NAME).GetComponent<Text>();
    reset();
  }

  // Update is called once per frame
  void Update() {
    if (!hasDisplayedClickUp && (Time.time > flashTriggerTime)) {
      spriteRenderer.color = FLASH_COLOR;
      hasDisplayedClickUp = true;
      timerText.text = "GO";
    }
  }

  public void OnMouseDown() {
    if (hasDisplayedClickUp) {
      timerText.text = (Time.time - flashTriggerTime).ToString();
      reset();
    }
  }

  void reset() {
    hasDisplayedClickUp = false;
    spriteRenderer.color = DEFAULT_COLOR;
    startTime = Time.time;
    flashTriggerTime = Random.Range(startTime + DELAY_MIN, startTime + DELAY_MAX);
    Debug.Log(flashTriggerTime);
    Debug.Log(name);
  }
}
