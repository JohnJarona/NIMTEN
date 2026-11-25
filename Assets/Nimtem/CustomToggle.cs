using UnityEngine;
using UnityEngine.Events;

public class CustomToggle : MonoBehaviour
{
    [SerializeField] private GameObject _checkObj;
    [SerializeField] private GameObject _crossObj;
    [SerializeField] private bool IsOn;
    public void Press()
    {
        SetState(!IsOn);
        if (IsOn) OnToggle.Invoke();
        else OffToggle.Invoke();
    }
    private void UpdateVisual()
    {
        _checkObj.SetActive(!IsOn);
        _crossObj.SetActive(IsOn);
    }
    public void SetState(bool what)
    {
        IsOn = what;
        UpdateVisual();
    }
    public void Start()
    {
        UpdateVisual();
    }
    [SerializeField] private UnityEvent OnToggle;
    [SerializeField] private UnityEvent OffToggle;
}
