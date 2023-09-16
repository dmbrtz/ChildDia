using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using Unity.VisualScripting;

public class WindowGraph : MonoBehaviour
{
    [SerializeField] private GameObject graphPanel;

    [SerializeField] private Sprite circleSpite;
    private RectTransform graphContainer;
    public float lineWidth = 3f;
    public Color lineColor = Color.black;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private List<int> valueList = new List<int>();

    private void Awake()
    {

        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();

        if(PlayerPrefs.HasKey("ValueList"))
        {
            LoadListFromPlayerPrefs();
            ShowGraph(valueList);
        }
        else
        {
        valueList.AddRange(new List<int>() { 0 });
        ShowGraph(valueList);
        }
        
    }


    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSpite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(20, 20);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private void ShowGraph(List<int> valueList)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMax = 17f;
        float xSize = 50f;
        float yInterval = graphHeight / (valueList.Count + 1);

        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPostition = xSize + i * xSize;
            float yPosition = (valueList[i] / yMax) * graphHeight;
            

            GameObject circleGameObject = CreateCircle(new Vector2(xPostition, yPosition));
            if (lastCircleGameObject != null)
            {
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;

            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPostition, -20f);
            labelX.GetComponent<Text>().text = i.ToString();
        }


    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = lineColor;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, lineWidth);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
    }

    public void AddValueFromPlayerPrefs()
    {
        int value = PlayerPrefs.GetInt("sugarInDay");
        valueList.Add(value);
        ShowGraph(valueList);
    }


    public void OpenGraphBT()
    {
        graphPanel.SetActive(true);
    }
    public void BackBT()
    {
        graphPanel.SetActive(false);
    }

    public void SaveListToPlayerPrefs()
    {
        // Преобразуем список в массив
        int[] valueArray = valueList.ToArray();

        // Преобразуем массив в строку
        string valueString = string.Join(",", valueArray);

        // Сохраняем строку в PlayerPrefs
        PlayerPrefs.SetString("ValueList", valueString);
        PlayerPrefs.Save();
    }

    // Загрузка списка из PlayerPrefs
    private void LoadListFromPlayerPrefs()
    {
        // Получаем сохраненную строку из PlayerPrefs
        string valueString = PlayerPrefs.GetString("ValueList");

        // Разбиваем строку на элементы массива
        string[] valueArray = valueString.Split(',');

        // Преобразуем элементы массива в целочисленные значения и добавляем их в список
        valueList.Clear();
        foreach (string value in valueArray)
        {
            if (int.TryParse(value, out int intValue))
            {
                valueList.Add(intValue);
            }
        }
    }
}