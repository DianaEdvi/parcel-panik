using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private float duration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shake());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Shake()
    {
        var startPosition = transform.position;
        var elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            var strength = _animationCurve.Evaluate(elapsedTime / duration);
            var shakeOffset = Random.insideUnitCircle * strength;
            transform.position = startPosition + new Vector3(shakeOffset.x, shakeOffset.y, 0) * strength;
            yield return null;
        }
    }
    
}
