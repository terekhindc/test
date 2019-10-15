using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{

    Mesh mesh; // Мы объявляем переменную для хранения геометрической формы объекта
    Vector3[] vertex; // Мы создаём переменную для хранения массива типа Vector3, чтобы записывать, хранить и менять координаты точек объекта
    int[] trianlges; // Мы создаём переменную для хранения массива типа int, чтобы записывать, хранить и менять индексы точек . Каждые три элемента в массиве - это треугольник.

    [SerializeField] float radius = 0.02f;
    [SerializeField] float height = 2; // Мы объявляем переменную типа float для хранения значения высоты
    [SerializeField] float width = 2; // Мы объявляем переменную типа float для хранения ширины объекта.

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh = new Mesh(); // Мы создаём новую форму объекта (Mesh) и записываем в компонент MeshFilter
        mesh.name = "Procedure Mesh"; //Мы даём форме объекта имя, как он будет отображаться в компоненте MeshFilter в поле Mesh

        vertex = new Vector3[5]; // Мы записываем в переменную создаваемый массив из 5 элементов типа Vector3, представляющих собой координаты точек x,y,z.

        // Мы поочерёдно (по индексу элемента) записываем новую векторную координату каждой точки.
        vertex[0] = new Vector3(0, height, 0); // Например, тут мы записываем в самую первую точку (индекс 0) её координаты x=0, y=height, z=0
        vertex[1] = new Vector3(width, 0, -width);
        vertex[2] = new Vector3(-width, 0, -width);
        vertex[3] = new Vector3(-width, 0, width);
        vertex[4] = new Vector3(width, 0, width);

        mesh.vertices = vertex; // Мы записываем в свойство класса Mesh.vertices массив координат всех точек. Мы можем так сделать, потому что по типу это такой же массив Vector3. Теперь Mesh знает все координаты наших точек

        trianlges = new int[6*3]; // Мы записываем в переменную новый массив чисел, которые представляют собой индексы точек объекта, которые мы перечисляли на строках 26-30
        
        // Каждые три элемента массива представляют собой треугольник. Мы поочерёдно (по индексу элемента) добавляем соответствующий индекс точки.
        trianlges[0] = 0; // Например, здесь мы записываем первую точку с координатами, которые мы описывали на строке 26
        trianlges[1] = 1;
        trianlges[2] = 2;
        // Здесь мы завершили создание треугольника. Теперь он состоит из точек с индексами 0,1,2 из массива vertex

        trianlges[3] = 0;
        trianlges[4] = 4;
        trianlges[5] = 1;

        trianlges[6] = 0;
        trianlges[7] = 2;
        trianlges[8] = 3;

        //Опишите здесь три элемента массива для создания недостающей стороны треугольника
        //trianlges[?] = ?;
        //trianlges[?] = ?;
        //trianlges[?] = ?;

        mesh.triangles = trianlges; // Мы записываем в свойство класса Mesh.triangles массив индексов точек. Теперь меш знает о том, как нужно строить треугольники и мы их видим.
        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (mesh == null) return;

        Gizmos.color = Color.black;

        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            Gizmos.DrawSphere(transform.position + vertex[i], radius);
        }

    }
}
