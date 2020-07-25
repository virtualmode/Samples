using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.IO;
using System.Windows.Forms;

namespace ANS.Essence
{
    /// <summary>
    /// Структура для хранения цвета (3 байта всего). Можно было бы использовать тип Color, но он много жрет при сериализации.
    /// </summary>
    [Serializable]
    struct StructureColor
    {
        public Byte R, G, B; // Биты, кодирующие цвет.
    }

    /// <summary>
    /// Структура нейронной сети (однослойный персептрон). Сюда входит само изображение (чувствительный слой нейронов) и нижний слой нейронов.
    /// </summary>
    [Serializable]
    struct StructureNeuronet
    {
        public String Name; // Имя нейросети.
        public StructureColor[,] Pixel; // Изображение (для возможности его редактирования).
        public float[] Neuron; // Конечный слой нейронов с уже преобразованным образом.
    }

    /// <summary>
    /// Класс для распознавания образов.
    /// </summary>
    [Serializable] // Класс поддерживает сериализацию, т.е. сохранение в поток. В нашем случае в файл.
    class ClassIRNN1
    {
        public String Name; // Имя нейронной сети (просто идентификатор).

        [NonSerialized] public StructureNeuronet m_CurrentNeuronet; // Текущий образ, отображаемый на холсте.
        public StructureNeuronet[] m_Neuronet; // Массив нейросетей с загнанными в них образами. Короче говоря это набор состояний,
                                               // с которыми мы будем сравнивать основную нейросеть (нейросеть с текущим образом) на совпадения.

        Int32 m_PictureDimension, m_ImageDimension; // Длина стороны изображения; количество нейронов в нижнем слое нейросети.

        // Свойства класса:
        public Int32 PictureDimension { get { return m_PictureDimension; } }
        public Int32 ImageDimension { get { return m_ImageDimension; } }

        // Конструкторы:
        public ClassIRNN1(Int32 PictureDimension, Int32 ImageDimension)
        {
            // Поля ниже должны быть инициализированы в конструкторе, т.к. предназначены для сериализации:
            m_Neuronet = new StructureNeuronet[1];
            m_PictureDimension = PictureDimension; // Получение длины стороны изображения.
            m_ImageDimension = ImageDimension; // Получение длины стороны нижнего слоя нейронов. На самом деле этот слой не в двумерном массиве хранится, а в одномерном.
            // Инициализация несериализуемых полей:
            Create(PictureDimension, ImageDimension);
        }

        /// <summary>
        /// Метод инициализации полей, которые не вошли в сериализацию.
        /// </summary>
        /// <param name="PictureDimension"></param>
        /// <param name="ImageDimension"></param>
        public void Create(Int32 PictureDimension, Int32 ImageDimension)
        {
             CreateNeuronet(ref m_CurrentNeuronet, "Текущий образ", PictureDimension, ImageDimension); // Создание текущего образа.
        }

        /// <summary>
        /// Метод сериализации нейросети в файл.
        /// </summary>
        /// <param name="FileName">Путь к файлу, в который будет произведена сериализация.</param>
        public void Serialize(String FileName)
        {
            IFormatter Formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter(); // Инициализация интерфейса сериализации.
            try
            {
                // Если объект в памяти, сохраняем его:
                if (this != null)
                {
                    Stream File = new FileStream(FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None);
                    Formatter.Serialize(File, this); // Сериализация.
                    File.Close(); // Закрываем поток.
                    File.Dispose();
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Невозможно сохранить нейросеть: " + FileName + ".", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Метод десериализации нейросети из файла.
        /// </summary>
        /// <param name="FileName">Путь к файлу, из которого будет произведена десериализация.</param>
        /// <returns>Указатель на загруженную нейросеть.</returns>
        public static ClassIRNN1 Deserialize(String FileName)
        {
            IFormatter Formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter(); // Инициализация интерфейса сериализации.
            try
            {
                Stream File = new FileStream(FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                ClassIRNN1 IRNN = (ClassIRNN1)Formatter.Deserialize(File); // Сохраняем ссылку нового объекта.
                File.Close(); // Закрываем поток.
                File.Dispose(); // Освобождаем ресурсы.
                return IRNN;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Невозможно загрузить нейросеть: " + FileName + ".", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning); // Десериализация провалена.
                return null;
            }
        }

        /// <summary>
        /// Метод перевода цвета в степень возбужденности нейрона.
        /// </summary>
        /// <param name="R"></param>
        /// <param name="G"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static float ColorToExcitation(ref StructureColor Color)
        {
            return (float)((float)(Color.R + Color.G + Color.B) / 3.0f);
        }

        /// <summary>
        /// Метод перевода возбужденности нейрона в целое число от 0 до 255. Необходим для вывода диаграммы.
        /// </summary>
        /// <param name="Excitation"></param>
        /// <returns></returns>
        public static Byte ExcitationToByte(float Excitation)
        {
            if (Excitation > 254.0f) Excitation = 254.0f; // Проверка верхней границы цветности.
            if (Excitation < 1.0f) Excitation = 1.0f; // Проверка нижней границы цветности.
            return (Byte)Excitation; // Если просто эту строку оставить, то перевод в некоторых моментах будет неверным. Программеры знают.
        }

        /// <summary>
        /// Метод создания экземпляра образа.
        /// </summary>
        /// <param name="Name">Имя образа.</param>
        /// <param name="SideLength">Длина стороны образа.</param>
        /// <param name="BottomLayerLength">Длина нижнего слоя нейронов (количество нейронов в нижнем слое).</param>
        /// <returns>Указатель на созданный образ.</returns>
        public static void CreateNeuronet(ref StructureNeuronet Neuronet, String Name, Int32 PictureDimension, Int32 ImageDimension)
        {
            Neuronet = new StructureNeuronet();
            Neuronet.Name = Name;
            Neuronet.Pixel = new StructureColor[PictureDimension, PictureDimension];
            Neuronet.Neuron = new float[ImageDimension];
        }

        /// <summary>
        /// Метод копирования содержимого одного образа в другой.
        /// </summary>
        /// <param name="Destination">Принимающий образ.</param>
        /// <param name="Source">Исходный образ.</param>
        public static void CopyNeuronet(ref StructureNeuronet Destination, ref StructureNeuronet Source)
        {
            Int32 i, j, k = (Int32)Math.Sqrt(Source.Pixel.Length); // i, j - переменные для цыклов; k - размерность матрицы изображения.
            Destination.Name = Source.Name;
            // Копирование изображения:
            Destination.Pixel = new StructureColor[k, k];
            for (i = 0; i < k; i++)
                for (j = 0; j < k; j++)
                    Destination.Pixel[j, i] = Source.Pixel[j, i];
            // Копирование нижнего слоя нейронов:
            Destination.Neuron = new float[Source.Neuron.Length];
            for (i = 0; i < Source.Neuron.Length; i++) Destination.Neuron[i] = Source.Neuron[i];
        }

        /// <summary>
        /// Метод переобучения нейросети с коэффициентом памяти (aka коэф.забывания).
        /// </summary>
        /// <param name="Destination">Указатель на принимающую нейросеть.</param>
        /// <param name="Source">Указатель на исходную нейросеть.</param>
        /// <param name="MemoryFactor">Коэффициент памяти.</param>
        public static void MemorizeNeuronet(ref StructureNeuronet Destination, ref StructureNeuronet Source, float MemoryFactor)
        {
            Int32 i, j, k = (Int32)Math.Sqrt(Source.Pixel.Length); // i, j - переменные для цыклов; k - размерность матрицы изображения.
            Destination.Name = Source.Name;
            // Копирование изображения:
            Destination.Pixel = new StructureColor[k, k];
            for (i = 0; i < k; i++)
                for (j = 0; j < k; j++)
                    Destination.Pixel[j, i] = Source.Pixel[j, i];
            // Копирование нижнего состояния нижнего слоя нейронов с учетом коэффициента памяти (aka коэф. забывания):
            if (MemoryFactor < 0.0f) MemoryFactor = 0.0f;
            if (MemoryFactor > 1.0f) MemoryFactor = 1.0f;
            Destination.Neuron = new float[Source.Neuron.Length];
            for (i = 0; i < Source.Neuron.Length; i++) Destination.Neuron[i] = Destination.Neuron[i] * MemoryFactor + Source.Neuron[i] * (1.0f - MemoryFactor);
        }

        /// <summary>
        /// Метод вычисления состояния нижнего слоя нейронов выбранной нейросети.
        /// </summary>
        /// <param name="Neuronet">Указатель на нейросеть.</param>
        public static void ComputeNeuronet(ref StructureNeuronet Neuronet)
        {
            Int32 i = 0, j = 0, i0 = 0, j0 = 0, k, l; // Переменные для четырех циклов.
            Int32 Square = 0; // Номер текущего квадратика.
            Int32 Side = (Int32)Math.Sqrt(Neuronet.Pixel.Length / Neuronet.Neuron.Length); // Сторона квадратика, на которые разбиваем все изображение.
            float Excitation;
            // Основной цикл по квадратикам:
            while (i < (Int32)Math.Sqrt(Neuronet.Neuron.Length))
            {
                j = 0;
                j0 = 0;
                while (j < (Int32)Math.Sqrt(Neuronet.Neuron.Length))
                {
                    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    Excitation = 0.0f;
                    for (k = 0; k < Side; k++)
                    {
                        for (l = 0; l < Side; l++)
                        {
                            Excitation += ColorToExcitation(ref Neuronet.Pixel[j0 + l, i0 + k]);
                        }
                    }
                    Neuronet.Neuron[Square] = Excitation;
                    Square++;
                    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    j0 += Side;
                    j++;
                }
                i0 += Side;
                i++;
            }
        }

        /// <summary>
        /// Метод сравнения двух нейросетей. Именно нейросетей. Каждый образ поступает на чувствительные нейроны (верхний слой), далее
        /// возбуждает нижний слой. Вот в таком состоянии хранятся образы, в виде возбужденных нейросетей. Сравнивая состояние нейросетей,
        /// мы как бы сравниваем образы, вот и получается это самое распознавание изображений. На выходе этого метода получаем
        /// число, которое показывает степень отличия образов. Чем оно меньше, тем похожее образы.
        /// </summary>
        /// <param name="Neuronet1">Указатель на первую нейросеть.</param>
        /// <param name="Neuronet2">Указатель на вторую нейросеть.</param>
        /// <returns>Степень соответствия нейросетей (ну или образов, как хотите).</returns>
        public static Single CompareImages(ref StructureNeuronet Neuronet1, ref StructureNeuronet Neuronet2)
        {
            Single Result = 0.0f;
            Int32 Length = Math.Min(Neuronet1.Neuron.Length, Neuronet2.Neuron.Length);
            for (Int32 i = 0; i < Length; i++)
                Result += (Single)Math.Pow((Single)(Neuronet1.Neuron[i] - Neuronet2.Neuron[i]), 2.0f);
            return Result / (Single)Length;
        }

        /// <summary>
        /// Метод отрисовки диаграммы возбужденности нейронных слоев нейросети.
        /// </summary>
        /// <param name="Neuronet">Указатель на нейросеть.</param>
        /// <param name="Canvas">Графический буфер для рисования.</param>
        /// <param name="x">Координата по оси OX.</param>
        /// <param name="y">Координата по оси OY.</param>
        /// <param name="Angle">Угол поворота диаграммы.</param>
        public static void DrawNeuronet(ref StructureNeuronet Neuronet, Graphics Canvas, float x, float y, float Angle)
        {
            Pen Pen = new Pen(Color.White, 45.0f); // Кисть с соответствующим цветом и размером.
            float Angl, dAngl, Excitation; // Текущий угол; приращение кугла; цвет сектора диаграммы (пропорционален возбужденности блока нейронов).
            Int32 i = 0, i0 = 0, j, j0, k, l; // Переменные цикла.
            Int32 c, s, Block, Side; // Переменные цикла; c - номер текущего нейрона в блоке; s - текущая часть блока (в данном случае всего 3 части в каждом блоке);
                                     // Block - количество нейронов в блоке; Side - сторона квадратика, см. ниже.
            // Рисуем верхний (чувствительный слой нейронов):
            Angl = Angle; // Установка угла, под которым будем рисовать круговую диаграмму состояния нейросети.
            dAngl = 360.0f / (3 * Neuronet.Neuron.Length); // Установка приращения угла, в которое будет укладываться блок нейронов верхнего слоя.
            Side = (Int32)Math.Sqrt(Neuronet.Pixel.Length / Neuronet.Neuron.Length); // Сторона квадратика, на которые разбиваем все изображение.
            Block = (Int32)(Math.Pow(Side, 2) / 3); // Вычисление количества нейронов в блоке.
            while (i < (Int32)Math.Sqrt(Neuronet.Neuron.Length)) // (Int32) используется для правильного округления и предотвращения выхода за границы массива.
            {
                j = 0; // Количество пройденных кубиков по горизонтали (необходимо для правильного вывода нестандартных нейросетей, т.е. у которых Side не целое число).
                       // i - по вертикали.
                j0 = 0; // Позиция (по горизонтали) в матрице с изображением.
                        // i0 - по вертикали.
                while (j < (Int32)Math.Sqrt(Neuronet.Neuron.Length))
                {
                    //MessageBox.Show(m_PictureDimension.ToString() + " " + j.ToString() + " " + i.ToString());
                    c = 0; // Количество подсчитанных нейронов в блоке.
                    s = 0; // Пройденное количество блоков.
                    Excitation = 0.0f;
                    for (k = 0; k < Side; k++)
                        for (l = 0; l < Side; l++)
                        {
                            Excitation += ColorToExcitation(ref Neuronet.Pixel[j0 + l, i0 + k]); // Ссумируем напряженность текущего нейрона.
                            c++;
                            if (c == Block)
                            {
                                s++;
                                c = 0;
                                Excitation /= Block; // Смегчаем цвет для более приятного и информативного отображения на экране.
                                Pen.Color = Color.FromArgb(0, ExcitationToByte(Excitation / 3.0f), 0); // Вычисляем цвет нейронного блока в зависимости от их возбужденности (делим для более приятного отображения на экране).
                                Canvas.DrawArc(Pen, x, y, 5 * Pen.Width, 5 * Pen.Width, -Angl, -dAngl); // Отрисовка блока нейронов в 3-ех градусах диаграммы.
                                Angl += dAngl; // Переход на новый угол диаграммы.
                                if (s == 3)
                                {
                                    k = Side; // Принудительно завершаем третий цикл.
                                    break; // И выхоим из текущего.
                                }
                            }
                        }
                    j0 += Side;
                    j++;
                }
                i0 += Side;
                i++;
            }
            // Рисуем нижний слой нейронов (образ):
            Angl = Angle; // Установка угла, под которым будем рисовать круговую диаграмму состояния нейросети.
            dAngl = 360.0f / Neuronet.Neuron.Length; // Установка приращения угла, в которое будет укладываться блок нейронов верхнего слоя.
            for (i = 0; i < Neuronet.Neuron.Length; i++)
            {
                Pen.Color = Color.FromArgb(0, ExcitationToByte(Neuronet.Neuron[i] / 42.0f), 0); // Вычисляем цвет нейронного блока в зависимости от их возбужденности.
                Canvas.DrawArc(Pen, x + Pen.Width, y + Pen.Width, 3 * Pen.Width, 3 * Pen.Width, -Angl, -dAngl); // Отрисовка блока нейронов в 3-ех градусах диаграммы.
                Angl += dAngl; // Переход на новый угол диаграммы.
            }
        }
    }
}
