using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour {

	public float speed;
	public bool doTween;
	public bool reverse;
	public bool tweenPos;
	public Vector3 originPos, targetPos;
	public bool tweenScale;
	public Vector3 originScale,targetScale;
	float tweenFactor;

	// Use this for initialization
	void Start () {
		if (doTween) {
			if (tweenPos)
				transform.localPosition = originPos;
			if (tweenScale)
				transform.localScale = originScale;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (doTween) {
			tweenFactor += speed;
			if (tweenPos) {
				if(reverse)
					transform.localPosition = Vector3.Lerp (targetPos, originPos, tweenFactor);
				else
					transform.localPosition = Vector3.Lerp (originPos, targetPos, tweenFactor);
			}
			if (tweenScale) {
				if(reverse)
					transform.localScale = Vector3.Lerp (targetScale, originScale, tweenFactor);
				else
					transform.localScale = Vector3.Lerp (originScale, targetScale, tweenFactor);
			}
			if (tweenFactor >= 1f) {
				doTween = false;
				tweenFactor = 0f;
			}
		}
		
		
	}

	public void SetTween(Vector3 targetPos, float nSpeed){
		speed = nSpeed;
		SetTween (targetPos);
	}

	public void SetTween(Vector3 targetPos){
		targetPos = targetPos;
		originPos = transform.localPosition;
		doTween = true;
	}
}
