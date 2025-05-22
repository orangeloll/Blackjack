using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ToastManager : MonoBehaviour
{
    public GameObject toastPrefab;  // 미리 만들어둔 ToastPanel 프리팹
    public Transform toastParent;   // 보통 Canvas 밑에 빈 GameObject (위치 기준)
    public float duration = 2.5f;   // 보여줄 시간

    public void ShowToast(string message)
    {
        GameObject toastGO = Instantiate(toastPrefab, toastParent);
        toastGO.transform.SetAsLastSibling(); // 항상 위로
        toastGO.GetComponentInChildren<Text>().text = message;

        StartCoroutine(FadeOutAndDestroy(toastGO));
        Debug.Log($" 토스트 생성됨: {toastPrefab.name}, 부모: {toastParent.name}");
    }

    private IEnumerator FadeOutAndDestroy(GameObject toastGO)
    {
        CanvasGroup cg = toastGO.GetComponent<CanvasGroup>();
        yield return new WaitForSeconds(duration);

        float fadeTime = 0.5f;
        float t = 0;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(1, 0, t / fadeTime);
            yield return null;
        }

        Destroy(toastGO);
    }
}
