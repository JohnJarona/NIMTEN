using DG.Tweening;
using TMPro;
using UnityEngine;

public class ClickParticle : MonoBehaviour
{
    [SerializeField] private TMP_Text _clickText;
    [SerializeField] private RectTransform _rect;
    
    public void SetValue(string val)
    {
        _clickText.text = val;
    }
    public void Start()
    {
        _rect.DOScale(new Vector3(2, 2, 1), 1);
        _clickText.DOFade(0, 1f);
        Destroy(gameObject, 1.1f);
    }
}