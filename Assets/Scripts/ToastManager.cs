using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ToastManager : MonoBehaviour
{
    public GameObject toastPrefab;  // �̸� ������ ToastPanel ������
    public Transform toastParent;   // ���� Canvas �ؿ� �� GameObject (��ġ ����)
    public float duration = 2.5f;   // ������ �ð�

    public void ShowToast(string message)
    {
        GameObject toastGO = Instantiate(toastPrefab, toastParent);
        toastGO.transform.SetAsLastSibling(); // �׻� ����
        toastGO.GetComponentInChildren<Text>().text = message;

        StartCoroutine(FadeOutAndDestroy(toastGO));
        Debug.Log($" �佺Ʈ ������: {toastPrefab.name}, �θ�: {toastParent.name}");
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
