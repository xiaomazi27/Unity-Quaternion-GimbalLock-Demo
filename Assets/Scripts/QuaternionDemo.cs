using UnityEngine;
using TMPro;

public class QuaternionDemo : MonoBehaviour
{
    [Header("Target Cube")]
    public Transform cube;

    [Header("Euler Angles Input")]
    public Vector3 eulerAngles;

    [Header("Current Quaternion (Read Only)")]
    public Quaternion quat;

    [Header("UI Text (Drag TMP Text Here)")]
    public TextMeshProUGUI infoText;

    private void Update()
    {
        quat = Quaternion.Euler(eulerAngles);
        cube.rotation = quat;

        Debug.Log($"Euler: {eulerAngles} | Quaternion: {quat:F3}");

        string showStr =
$@"Euler XYZ:
({eulerAngles.x:F1}, {eulerAngles.y:F1}, {eulerAngles.z:F1})

Quaternion (x,y,z,w):
({quat.x:F3}, {quat.y:F3}, {quat.z:F3}, {quat.w:F3})";

        infoText.text = showStr;
    }
}
