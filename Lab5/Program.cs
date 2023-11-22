/*using System;

public class MyMatrix
{
    private int[,] matrix;


    public MyMatrix(int rows, int cols)
    {
        matrix = new int[rows, cols];
        Fill();
    }

    public void Fill()
    {
        Random rand = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rand.Next(100);
            }
        }
    }

    public void ChangeSize(int newRows, int newCols)
    {
        var newMatrix = new int[newRows, newCols];
        for (int i = 0; i < Math.Min(matrix.GetLength(0), newRows); i++)
        {
            for (int j = 0; j < Math.Min(matrix.GetLength(1), newCols); j++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }
        matrix = newMatrix;
        if (newRows > matrix.GetLength(0) || newCols > matrix.GetLength(1))
        {
            Fill();
        }
    }

    public void Show()
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public void ShowPartially(int startRow, int startCol, int endRow, int endCol)
    {
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startCol; j <= endCol; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    //Индексы для матрицы
    public int this[int row, int col]
    {
        get { return matrix[row, col]; }
        set { matrix[row, col] = value; }
    }
}

class Lab5_1
{
    static void Main()
    {
        MyMatrix matrix = new MyMatrix(5, 5);
        matrix.Show();
        Console.WriteLine();

        matrix.ChangeSize(3, 3);
        matrix.Show();
        Console.WriteLine();

        matrix.ShowPartially(0, 0, 2, 2);
        Console.WriteLine();

        matrix[1, 1] = 999;
        matrix.Show();
    }
}

using System;

public class MyList<T>
{
    private T[] array;
    private int count;

    public MyList()
    {
        array = new T[0];
        count = 0;
    }


    public void Add(T item)
    {
        T[] newArray = new T[count + 1];
        array.CopyTo(newArray, 0);
        newArray[count] = item;
        array = newArray;
        count++;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            return array[index];
        }
    }

    public int Count
    {
        get { return count; }
    }

    public void AddRange(params T[] items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }
}

class Lab5_2
{
    static void Main()
    {
        MyList<int> myList = new MyList<int>();
        myList.Add(1);
        myList.Add(2);
        myList.AddRange(3, 4, 5);

        Console.WriteLine("List items:");
        for (int i = 0; i < myList.Count; i++)
        {
            Console.WriteLine(myList[i]);
        }
    }
}
*/
using System;
using System.Collections;
using System.Collections.Generic;

public class MyDictionary<TKey, TValue> : IEnumerable
{
    private TKey[] keys;
    private TValue[] values;
    private int size;

    public MyDictionary()
    {
        keys = new TKey[4];
        values = new TValue[4];
        size = 0;
    }

    public void Add(TKey key, TValue value)
    {
        if (size == keys.Length)
        {
            Array.Resize(ref keys, size + 1);
            Array.Resize(ref values, size + 1);
        }

        for (int i = 0; i < size; i++)
        {
            if (Equals(keys[i], key))
            {
                throw new ArgumentException("An item with the same key has already been added.");
            }
        }

        keys[size] = key;
        values[size] = value;
        size++;
    }

    public TValue this[TKey key]
    {
        get
        {
            for (int i = 0; i < size; i++)
            {
                if (Equals(keys[i], key))
                {
                    return values[i];
                }
            }
            throw new KeyNotFoundException("The given key was not present in the dictionary.");
        }
        set
        {
            int index = Array.IndexOf(keys, value); 
              if (index == -1)
            {
                Add(key, value);
            }
            else
            {
                values[index] = value;
            }
        }
    }

    public int Count
    {
        get { return size; }
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < size; i++)
        {
            yield return new KeyValuePair<TKey, TValue>(keys[i], values[i]);
        }
    }
}

public class Lab5_3
{
    public static void Main()
    {
        var myDict = new MyDictionary<string, int>();
        myDict.Add("one", 1);
        myDict.Add("two", 2);
        myDict["cczxc"] = 3;

        foreach (KeyValuePair<string, int> kvp in myDict)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }

        Console.WriteLine($"Count: {myDict.Count}");
        Console.WriteLine($"Value for 'one': {myDict["one"]}");

    }
}
