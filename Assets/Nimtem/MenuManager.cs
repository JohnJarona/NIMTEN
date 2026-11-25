using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private RectTransform _clickerVisual;
    [SerializeField] private Image _clickerImageBlink;
    [SerializeField] private ClickParticle _clickParticlePrefab;
    [SerializeField] private RectTransform _clickParticleRoot;
    [SerializeField] private RectTransform _logoRect;
    [SerializeField] private RectTransform _btnRect;
    public IEnumerator CoRandomClicks()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0f,1f));
            Click();
        }
    }
    public void Click()
    {
        _clickerVisual.DOKill();
        _clickerImageBlink.DOKill();
        _clickerVisual.eulerAngles = Vector3.zero;
        _clickerVisual.localScale = Vector3.one * 1.5f;
        _clickerImageBlink.color = Color.white;
        _clickerVisual.DOShakeRotation(1, 5, 25, 200).SetEase(Ease.OutCirc);
        _clickerVisual.DOScale(Vector3.one, 1f).SetEase(Ease.OutCirc);
        _clickerImageBlink.DOFade(0,0.5f).SetEase(Ease.OutCirc);

        ClickParticle particle = GameObject.Instantiate(_clickParticlePrefab, _clickParticleRoot);
        particle.transform.position = new Vector2(
            Random.Range(_clickerVisual.position.x - _clickerVisual.sizeDelta.x/2f, _clickerVisual.position.x + _clickerVisual.sizeDelta.x/2f),
            Random.Range(_clickerVisual.position.y - _clickerVisual.sizeDelta.y/2f, _clickerVisual.position.y + _clickerVisual.sizeDelta.y/2f));
        particle.SetValue($"+{Random.Range(1, 1000):F2}$");
    }
    public void Start()
    {
        StartCoroutine(CoRandomClicks());
    }
    public void StartGame()
    {
        StopAllCoroutines();
        StartCoroutine(CoStartGame());
    }
    public IEnumerator CoStartGame()
    {
        float speed = 0.5f;
        float speedAlt = 0;
        while(speed > -3)
        {
            speedAlt += Time.deltaTime;
            speed += -Time.deltaTime * 2f;
            _clickerVisual.anchoredPosition += new Vector2(0, speed) * 5;
            _clickerVisual.eulerAngles = new Vector3(0, 0, _clickerVisual.eulerAngles.z + speedAlt);
            _logoRect.anchoredPosition += new Vector2(0, speed) * 5;
            _logoRect.eulerAngles = new Vector3(0, 0, _logoRect.eulerAngles.z + -speedAlt);
            _btnRect.anchoredPosition += new Vector2(0, speed) * 5;
            _btnRect.eulerAngles = new Vector3(0, 0, _btnRect.eulerAngles.z + speedAlt/ 2f);
            yield return null;
        }
        SceneManager.LoadScene(1);
    }
}
