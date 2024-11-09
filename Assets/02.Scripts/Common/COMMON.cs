using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class COMMON : MonoSingleton<COMMON>
{
    public GameObject NewObject(string prefabPath, Transform transform)
    {
        GameObject obj = Instantiate((GameObject) Resources.Load(prefabPath), transform);
        return obj;
    }

    public GameObject NewObject(GameObject targetObject, Transform transform)
    {
        GameObject obj = Instantiate(targetObject, transform);
        return obj;
    }

    public GameObject NewObject(Transform targetObject, Transform transform)
    {
        GameObject obj = Instantiate(targetObject.gameObject, transform);
        return obj;
    }

    public void Log(string msg1, object msg2, string color = "#ffffff")
    {
        //if (CONSTVALUE.Instance.ISDEV)
            Debug.Log("<color=" + color + ">" + msg1 + " / " + msg2 + "</color>");
    }

    public void SetImage(bool isLocal, string resourcePath, RawImage image)
    {
        if (isLocal)
        {
            image.texture = Resources.Load<Texture>(resourcePath);
        }
        else
        {

        }
    }

    public void SetImage(bool isLocal, string resourcePath, Image image)
    {
        if (isLocal)
            image.sprite = Resources.Load<Sprite>(resourcePath);
        else
        {

        }
    }

    public void SetImage(bool isLocal, string resourcePath, Button button)
    {
        if (isLocal)
            button.GetComponent<Image>().sprite = Resources.Load<Sprite>(resourcePath);
        else
        {

        }
    }
    public void SetImage(bool isLocal, string resourcePath, GameObject gameObject)
    {
        Image image;
        if (isLocal)
        {
            if (gameObject.TryGetComponent<Image>(out image))
                image.sprite = Resources.Load<Sprite>(resourcePath);
        }
        else
        {

        }
    }

    public void SetImageAlpha(Image image, float alpha)
    {
        Vector3 color = new Vector3(image.color.r, image.color.g, image.color.b);

        float convertAlpha = alpha * 2.56f;

        image.color = new Color(color.x, color.y, color.z, convertAlpha / 256f);
    }

    public void SetText(string text, TextMeshProUGUI textMeshPro)
    {
        textMeshPro.text = text;
    }

    public void SetText(string text, TextMeshPro textMeshPro)
    {
        textMeshPro.text = text;
    }

    public void SetTextColor(string colorCode, TextMeshProUGUI textMeshProUI)
    {
        Vector4 convertColor;
        if (colorCode.Length == 7) //#ffffff
            convertColor = new Vector4(Convert.ToInt32(colorCode.Substring(1, 2), 16), Convert.ToInt32(colorCode.Substring(3, 2), 16), Convert.ToInt32(colorCode.Substring(5, 2), 16), 255);
        else
            convertColor = new Vector4(Convert.ToInt32(colorCode.Substring(1, 2), 16), Convert.ToInt32(colorCode.Substring(3, 2), 16), Convert.ToInt32(colorCode.Substring(5, 2), 16), Convert.ToInt32(colorCode.Substring(7, 2), 16));

        textMeshProUI.color = new Color(convertColor.x / 256f, convertColor.y / 256f, convertColor.z / 256f, convertColor.w / 256f);
    }

    public void SetTextColor(string colorCode, TextMeshPro textMeshPro)
    {

    }

    public void SetImageColor(string colorCode, Image image)
    {
        Vector4 convertColor;
        if (colorCode.Length == 7) //#ffffff
            convertColor = new Vector4(Convert.ToInt32(colorCode.Substring(1, 2), 16), Convert.ToInt32(colorCode.Substring(3, 2), 16), Convert.ToInt32(colorCode.Substring(5, 2), 16), 255);
        else
            convertColor = new Vector4(Convert.ToInt32(colorCode.Substring(1, 2), 16), Convert.ToInt32(colorCode.Substring(3, 2), 16), Convert.ToInt32(colorCode.Substring(5, 2), 16), Convert.ToInt32(colorCode.Substring(7, 2), 16));

        image.color = new Color(convertColor.x / 256f, convertColor.y / 256f, convertColor.z / 256f, convertColor.w / 256f);
    }

    public void SetImageColor(string colorCode, GameObject gameObject)
    {
        Vector4 convertColor;
        if (colorCode.Length == 7) //#ffffff
            convertColor = new Vector4(Convert.ToInt32(colorCode.Substring(1, 2), 16), Convert.ToInt32(colorCode.Substring(3, 2), 16), Convert.ToInt32(colorCode.Substring(5, 2), 16), 255);
        else
            convertColor = new Vector4(Convert.ToInt32(colorCode.Substring(1, 2), 16), Convert.ToInt32(colorCode.Substring(3, 2), 16), Convert.ToInt32(colorCode.Substring(5, 2), 16), Convert.ToInt32(colorCode.Substring(7, 2), 16));

        Image image;
        if (gameObject.TryGetComponent<Image>(out image))
            image.color = new Color(convertColor.x, convertColor.y, convertColor.z, convertColor.w);
    }

    public AudioClip GetAudioClip(bool isLocal, string audioPath)
    {
        AudioClip audioClip = null;

        if (isLocal)
            audioClip = Resources.Load<AudioClip>("Sounds/" + audioPath);

        return audioClip;
    }

    public void SetLocalization(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    public string GetLocalizedString(string tableName, string key)
    {
        var loacaleString = LocalizationSettings.StringDatabase.GetLocalizedString(tableName, key);

        return loacaleString;
    }

    public Bounds CalculateBounds(GameObject target)
    {
        // Check if target is null
        if (target == null) return new Bounds(Vector3.zero, Vector3.zero);

        // Get all Renderers in the target's children
        Renderer[] renderers = target.GetComponentsInChildren<Renderer>();

        // If no renderers found, use the target's transform position
        if (renderers.Length == 0)
        {
            return new Bounds(target.transform.position, Vector3.zero);
        }

        // Initialize bounds with the first renderer's bounds center
        Bounds bounds = new Bounds(renderers[0].bounds.center, Vector3.zero);

        // Encapsulate all renderer bounds
        foreach (Renderer renderer in renderers)
        {
            bounds.Encapsulate(renderer.bounds);
        }

        return bounds;
    }

    public void AppExit()
    {
        GC.Collect();
        StopAllCoroutines();

#if !UNITY_EDITOR
        Application.Quit();
#endif
    }
}