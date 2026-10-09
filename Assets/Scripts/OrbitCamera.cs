using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [Header("观察目标（Cube）")]
    public Transform target;

    [Header("旋转速度")]
    public float rotateSpeed = 2f;
    [Header("滚轮缩放速度")]
    public float zoomSpeed = 5f;
    [Header("相机距离限制")]
    public float minDistance = 2f;
    public float maxDistance = 15f;

    private float distance;
    private float yAngle;
    private float xAngle;

    void Start()
    {
        // 初始距离
        distance = Vector3.Distance(transform.position, target.position);
        Vector3 dir = transform.position - target.position;
        Vector3 euler = Quaternion.LookRotation(dir).eulerAngles;
        xAngle = euler.x;
        yAngle = euler.y;
    }

    void Update()
    {
        // 鼠标左键拖拽旋转视角
        if (Input.GetMouseButton(0))
        {
            yAngle += Input.GetAxis("Mouse X") * rotateSpeed;
            xAngle -= Input.GetAxis("Mouse Y") * rotateSpeed;
            xAngle = Mathf.Clamp(xAngle, -80f, 80f); // 限制上下俯仰，防止翻转
        }

        // 鼠标滚轮缩放远近
        distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // 计算相机位置
        Quaternion rot = Quaternion.Euler(xAngle, yAngle, 0);
        Vector3 pos = target.position + rot * new Vector3(0, 0, -distance);
        transform.position = pos;
        transform.LookAt(target);
    }
}
