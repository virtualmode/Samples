using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using ANS.Essence;

namespace ANS
{
    /// <summary>
    /// Класс для работы с формой распознавания образов.
    /// </summary>
    public partial class FormImgRcg : Form
    {
        // Декларирование API функций:
        [DllImport("Gdi32.dll")] static extern Int32 GetPixel(IntPtr hDC, Int32 x, Int32 y);

        // Основные поля для работы с нейронной сетью:
        ClassIRNN1 IRNN1 = null; // Экземпляр класса, использующего нейросеть NN1 для распознования образов.

        // Поля для рисования образов:
        BufferedGraphics BgrpImage, BgrpNeuronet; // Указатель на графический буфер для рисования образа; ...для рисования состояния нейросети.
        Random Rnd; // Генератор случайных чисел.
        Int32 i, j, k; // Вспомогательные переменные.
        Boolean Painting; // Флаг процесса отрисовки образа.
        Pen Stylus; // Кисть для рисования.
        Byte StylusType; // Тип кисти для рисования. 0 - обычная кисть; 1 - распылитель.

        /// <summary>
        /// Основной конструктор класса.
        /// </summary>
        public FormImgRcg()
        {
            InitializeComponent();
            Rnd = new Random(); // Создаем экземпляр датчика случайных чисел.
            // Установка двойной буферизации для отрисовки образов и состояния нейросети:
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true); // Игнорируем сообщение WM_PAINT.
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // Рисуем сначала в контексте, а потом выводим на экран.
            // Установка интерфейса по умолчанию:
            ResetNN();
        }

        /// <summary>
        /// Ивент при активации данной формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormImgRcg_Activated(object sender, EventArgs e)
        {
            FormImgRcg_Resize(null, null); // Выполняем выравнивание объектов на форме.
            TimerRefresher.Enabled = true; // Если окно теряло активность, перерисовываем.
        }

        /// <summary>
        /// Метод деактивации формы. Используется для всплытия основного окна в момент диактивации этого.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormImgRcg_Deactivate(object sender, EventArgs e)
        {
            if (Program.UseShell) Program.Shell.WindowState = FormWindowState.Normal; // Отображаем всплывающее окно на экране.
            // Придумано это для упрощения работы с программой (чтоб перед глазами лишних окон не маячило).
        }

        /// <summary>
        /// Метод выравнивания объектов на форме.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormImgRcg_Resize(object sender, EventArgs e)
        {
            if (LabelStatus.Visible == true) // Если надпись на экране, выравниваем её по центру:
            {
                LabelStatus.Left = ContainerImgRcg.ContentPanel.ClientRectangle.Width / 2 - LabelStatus.Width / 2;
                LabelStatus.Top = ContainerImgRcg.ContentPanel.ClientRectangle.Height / 2 - LabelStatus.Height / 2;
            }
        }

        /// <summary>
        /// Метод создания и выравнивания необходимых элементов для загруженной или созданной нейросети.
        /// </summary>
        void SetNN()
        {
            // Изменения в интерфейсе:
            LabelStatus.Visible = false;
            LabelImage.Visible = true;
            PictureImage.Width = IRNN1.PictureDimension + 2; // + 2 для метода GetPixel (он неправильно работает на границе холста).
            PictureImage.Height = PictureImage.Width;
            PictureImage.Visible = true;
            PictureNeuronet.Left = PictureImage.Right + 14;
            PictureNeuronet.Top = PictureImage.Top;
            PictureNeuronet.Width = 270;
            PictureNeuronet.Height = PictureNeuronet.Width;
            LabelNeuronet.Left = PictureNeuronet.Left - 3;
            LabelNeuronet.Visible = true;
            PictureNeuronet.Visible = true;
            Width = PictureNeuronet.Right + 24;
            Height = Math.Max(PictureImage.Bottom, PictureNeuronet.Bottom) + 50 + ToolStripImgRcg.Height;
            // Открытие доступа к панели инструментов:
            LabelImage.Visible = true;
            PictureImage.Visible = true;
            LabelNeuronet.Visible = true;
            PictureNeuronet.Visible = true;
            ToolSave.Enabled = true;
            ToolClose.Enabled = true;
            ToolRefresh.Enabled = true;
            ToolName.Enabled = true;
            ToolImage.Enabled = true;
            ToolImage.Text = "";
            ToolAddImage.Enabled = true;
            ToolDeleteImage.Enabled = true;
            ToolImgRcg.Enabled = true;
            LabelStatus.Visible = false;
            // Создание графических объектов:
            StylusType = 0; // Обычная кисть.
            Stylus = new Pen(Color.FromArgb(128, 255, 128), 9.0f); // Создание пера с заданным цветом и размером.
            BgrpImage = BufferedGraphicsManager.Current.Allocate(PictureImage.CreateGraphics(), new Rectangle(0, 0, PictureImage.Width, PictureImage.Height)); // Создаем для этого графический буфер.
            BgrpNeuronet = BufferedGraphicsManager.Current.Allocate(PictureNeuronet.CreateGraphics(), new Rectangle(0, 0, PictureNeuronet.Width, PictureNeuronet.Height)); // Аналогично для рисования состояния нейросети.
        }

        /// <summary>
        /// Метод закрытия нейронной сети и обновления интерфейса соответствующим образом.
        /// </summary>
        void ResetNN()
        {
            // Изменение интерфейса:
            LabelImage.Visible = false;
            PictureImage.Visible = false;
            LabelNeuronet.Visible = false;
            PictureNeuronet.Visible = false;
            ToolSave.Enabled = false;
            ToolClose.Enabled = false;
            ToolRefresh.Enabled = false;
            ToolName.Enabled = false;
            ToolImage.Enabled = false;
            ToolImage.Text = "";
            ToolAddImage.Enabled = false;
            ToolDeleteImage.Enabled = false;
            ToolImgRcg.Enabled = false;
            LabelStatus.Text = "Нейронная сеть отсутствует.";
            LabelStatus.Visible = true;
            FormImgRcg_Resize(null, null);
            // Освобождение ресурсов системы:
            IRNN1 = null; // Обнуляем указатель, а ресурсы удалит сборщик мусора.
            if (BgrpImage != null) { BgrpImage.Dispose(); BgrpImage = null; }
            if (BgrpNeuronet != null) { BgrpNeuronet.Dispose(); BgrpNeuronet = null; }
            //GC.Collect(); // Это принудительная сборка мусора. Является плохим тоном программирования (так в книге писали). Незнаю.
        }

        /// <summary>
        /// Метод создания новой нейронной сети с заданными характеристиками.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolCreate_Click(object sender, EventArgs e)
        {
            Program.UseShell = false; // Запрещаем всплывание основного окна.
            if (IRNN1 != null) ToolClose_Click(null, null); // Попытка уничтожить старую нейросеть.
            if (IRNN1 == null) // Если попытка удалась, открываем диалоговое окно:
            {
                FormCreate Dialog = new FormCreate(); // Создаем форму с характеристиками создаваемой нейронной сети.
                Dialog.ShowDialog(this); // Показываем её пользователю.
                if (!Dialog.Cancel) // Если нажата клавиша 'Создать'...
                {
                    // Сигнализация (визуальная, через интерфейс) хода создания:
                    Cursor = Cursors.WaitCursor;
                    LabelStatus.Text = "Идет создание нейронной сети...";
                    FormImgRcg_Resize(null, null);
                    Refresh();
                    // Создание нейронной сети:
                    IRNN1 = new ClassIRNN1((Int32)Dialog.PictureDimension.Value, (Int32)Dialog.ImageDimension.Value); // Создание экземпляра распознавания.
                    IRNN1.Name = Dialog.TextName.Text; // Задание имени сети.
                    SetNN(); // Подготовка интерфейса.
                    // Восстановление интерфейса (после сигнализирования):
                    Cursor = Cursors.Default;
                }
                Dialog.Hide(); // Предотвращаем мерцание при вызове метода Dispose().
                Dialog.Dispose(); // Освобождаем ресурсы системы.
            }
            Program.UseShell = true; // Разрешаем всплывание основного окна.
        }

        /// <summary>
        /// Метод открытия существующей нейронной сети.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolOpen_Click(object sender, EventArgs e)
        {
            if (IRNN1 != null) ToolClose_Click(null, null); // Попытка уничтожить старую нейросеть.
            if (IRNN1 == null) // Если попытка удалась, открываем диалоговое окно:
            {
                Program.UseShell = false;
                // Создание диалогового окна для открытия нейронной сети:
                OpenFileDialog Dialog = new OpenFileDialog();
                Dialog.Title = "Открытие нейронной сети...";
                Dialog.AddExtension = true;
                Dialog.CheckFileExists = true;
                Dialog.Multiselect = false;
                Dialog.RestoreDirectory = true;
                Dialog.DefaultExt = "ir1";
                Dialog.Filter = "Файл нейронной сети IRNN1(*.ir1)|*.ir1|Все файлы (*.*)|*.*";
                Dialog.FilterIndex = 1;
                // Отображение диалогового окна на экране:
                if (Dialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Сигнализация (визуальная, через интерфейс) хода загрузки:
                    Cursor = Cursors.WaitCursor; // Изменение курсора в занятое состояние.
                    LabelStatus.Text = "Идет загрузка нейронной сети...";
                    FormImgRcg_Resize(null, null);
                    Refresh(); // Перерисовываем форму.
                    // Загрузка нейросети:
                    IRNN1 = ClassIRNN1.Deserialize(Dialog.FileName);
                    IRNN1.Create(IRNN1.PictureDimension, IRNN1.ImageDimension);
                    SetNN();
                    ToolDeleteImage_Click(null, null); // В данном случае метод ничего не удалит, он просто обновит список образов.
                    // Восстановление интерфейса (после сигнализирования):
                    Cursor = Cursors.Default; // Изменение курсора в занятое состояние.
                }
                Dialog.Dispose(); // Освобождение ресурсы системы.
                Program.UseShell = true;
            }
        }

        /// <summary>
        /// Метод сохранения нейросети в файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolSave_Click(object sender, EventArgs e)
        {
            if (IRNN1 != null) // Если есть, что сохранять...
            {
                Program.UseShell = false;
                // Создание диалога для сохранения нейронной сети:
                SaveFileDialog Dialog = new SaveFileDialog();
                Dialog.Title = "Сохранение нейронной сети...";
                Dialog.AddExtension = true;
                Dialog.RestoreDirectory = true;
                Dialog.DefaultExt = "ir1";
                Dialog.Filter = "Файл нейронной сети IRNN1(*.ir1)|*.ir1|Все файлы (*.*)|*.*";
                Dialog.FilterIndex = 1;
                // Отображение диалогового окна на экране:
                if (Dialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Сигнализация (визуальная, через интерфейс) процесса сохранения нейронной сети:
                    Cursor = Cursors.WaitCursor;
                    LabelStatus.Text = "Идет сохранение нейронной сети...";
                    LabelStatus.Visible = true;
                    PictureImage.Visible = false;
                    LabelImage.Visible = false;
                    PictureNeuronet.Visible = false;
                    LabelNeuronet.Visible = false;
                    FormImgRcg_Resize(null, null);
                    Refresh();
                    // Сохранение нейронной сети:
                    IRNN1.Serialize(Dialog.FileName);
                    // Восстановление интерфейса (после сигнализирования):
                    LabelStatus.Visible = false;
                    PictureImage.Visible = true;
                    LabelImage.Visible = true;
                    PictureNeuronet.Visible = true;
                    LabelNeuronet.Visible = true;
                    Cursor = Cursors.Default;
                }
                Dialog.Dispose();
                TimerRefresher.Enabled = true; // Запускаем таймер обновления экрана. Если просто ToolRefresh_Click вызвать, окно не перерисуется. Незнаю почему, в проблему не вникал.
                Program.UseShell = true;
            }
        }

        /// <summary>
        /// Метод закрытия нейронной сети.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolClose_Click(object sender, EventArgs e)
        {
            Program.UseShell = false; // Запрещаем всплывание основного окна.
            if (MessageBox.Show("Вы действительно хотите закрыть текущую нейронную сеть?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ResetNN(); // Закрытие нейросети и изменение интерфейса.
            }
            //Program.UseShell = true; // Убрано, т.к. есть моменты, где всплывающее окно не должно маячить перед глазами.
        }

        /// <summary>
        /// Метод обновления основного экрана.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolRefresh_Click(object sender, EventArgs e)
        {
            if (IRNN1 != null) // Проверяем наличие того, что будем обновлять, а именно - нейросеть с библиотекой образов.
            {
                Cursor = Cursors.WaitCursor; // Изменение курсора в занятое состояние.
                ClassIRNN1.ComputeNeuronet(ref IRNN1.m_CurrentNeuronet); // Вычисляем возбужденность нейронов основной нейросети.
                ClassIRNN1.DrawNeuronet(ref IRNN1.m_CurrentNeuronet, BgrpNeuronet.Graphics, 20.0f, 20.0f, 0.0f); // Отрисовываем состояние нейросети.
                BgrpImage.Render();
                BgrpNeuronet.Render();
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Метод отсчета таймера. Выполняется каждый раз единожды и обновляет при этом графику (образ и состояние нейронной сети).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerRefresher_Tick(object sender, EventArgs e)
        {
            ToolRefresh_Click(null, null); // Обновление.
            TimerRefresher.Enabled = false; // Остановка таймера.
        }

        /// <summary>
        /// Метод отрисовки компонента с образом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_Paint(object sender, PaintEventArgs e)
        {
            BgrpImage.Render(); // Выводим на экран содержимое графического буфера.
        }

        /// <summary>
        /// Метод отрисовки компонента с состоянием нейронной сети.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NNStatus_Paint(object sender, PaintEventArgs e)
        {
            BgrpNeuronet.Render(); // Выводим на экран содержимое графического буфера.
        }

        /// <summary>
        /// Метод выбора текущего образа из библиотеки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.UseShell = false;
            for (Int32 i = 0; i < IRNN1.m_Neuronet.Length; i++)
            {
                // Выбираем образ, имя которого соответствует тексту в поле ToolImage.Text:
                if (IRNN1.m_Neuronet[i].Name == ToolImage.Text.Trim())
                {
                    StructureColor Clr; // Вспомогательная переменная.
                    Pen Pen = new Pen(Stylus.Color, 1.0f); // Создаем кисть по умолчанию.
                    // Делаем выбранный образ текущим:
                    ClassIRNN1.CopyNeuronet(ref IRNN1.m_CurrentNeuronet, ref IRNN1.m_Neuronet[i]);
                    // Рисуем на холсте все то, что хранится в текущем образе:
                    for (Int32 k = 0; k < IRNN1.PictureDimension; k++)
                        for (Int32 j = 0; j < IRNN1.PictureDimension; j++)
                        {
                            Clr = IRNN1.m_CurrentNeuronet.Pixel[j, k];
                            Pen.Color = Color.FromArgb(Clr.R, Clr.G, Clr.B);
                            BgrpImage.Graphics.DrawLine(Pen, j, k, j + 1, k + 1);
                        }
                    // Выводим результат на экран:
                    ToolRefresh_Click(null, null);
                }
            }
            Program.UseShell = true;
        }

        /// <summary>
        /// Метод добавления образа в библиотеку для распознаваня. Очень пафосные и самопереоценивающие себя люди,
        /// работающие в этой области, называют это обучением. Но на самом деле этому сраному персептрону далеко до
        /// такого биологического понятия, как обучение. А еще нельзя природу загнать в рамки математики...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolAddImage_Click(object sender, EventArgs e)
        {
            Program.UseShell = false;
            if (ToolImage.Text.Trim() == "") // Проверяем, ввели ли имя образа...
                MessageBox.Show("Необходимо ввести имя образа.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                Int32 i;
                Boolean Create = true; // Флаг необходимости добавить новый образ в библиотеку.
                IRNN1.m_CurrentNeuronet.Name = ToolImage.Text.Trim(); // Получаем имя образа без пробелов.
                for (i = 0; i < IRNN1.m_Neuronet.Length; i++) // Ищем образ с таким именем в библиотеке и заменяем его (если надо).
                    if (IRNN1.m_Neuronet[i].Name == IRNN1.m_CurrentNeuronet.Name)
                    {
                        FormMemorize Dialog = new FormMemorize();
                        Dialog.ShowDialog(this);
                        switch (Dialog.Result)
                        {
                            case 1: // Замена:
                                ClassIRNN1.CopyNeuronet(ref IRNN1.m_Neuronet[i], ref IRNN1.m_CurrentNeuronet);
                                break;
                            case 2: // Переобучение:
                                try
                                {
                                    ClassIRNN1.MemorizeNeuronet(ref IRNN1.m_Neuronet[i], ref IRNN1.m_CurrentNeuronet, Convert.ToSingle(Dialog.TextMemoryFactor.Text));
                                }
                                catch
                                {
                                    MessageBox.Show("Коэффициент имеет неправильный формат. Операция переобучения отменена.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                break;
                            default:
                                break;
                        }
                        Create = false; // Заменили, значит дополнительное место выделять не надо.
                        Dialog.Dispose();
                        break;
                    }
                // В противном случае добавляем образ в конец массива:
                if (Create == true)
                {
                    Array.Resize(ref IRNN1.m_Neuronet, IRNN1.m_Neuronet.Length + 1);
                    ClassIRNN1.CopyNeuronet(ref IRNN1.m_Neuronet[IRNN1.m_Neuronet.Length - 1], ref IRNN1.m_CurrentNeuronet);
                }
                // Обновляем список образов:
                ToolImage.Items.Clear();
                for (i = 1; i < IRNN1.m_Neuronet.Length; i++) ToolImage.Items.Add(IRNN1.m_Neuronet[i].Name);
            }
            Program.UseShell = true;
        }

        /// <summary>
        /// Метод удаления образа из библиотеки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolDeleteImage_Click(object sender, EventArgs e)
        {
            Program.UseShell = false;
            Int32 i;
            for (i = 1; i < IRNN1.m_Neuronet.Length; i++)
            {
                if (IRNN1.m_Neuronet[i].Name == ToolImage.Text.Trim())
                {
                    if (MessageBox.Show("Вы действительно хотите удалить образ '" + IRNN1.m_Neuronet[i].Name + "'?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        IRNN1.m_Neuronet[i] = IRNN1.m_Neuronet[IRNN1.m_Neuronet.Length - 1]; // Передача ссылок, т.е. на освободившееся место ставим последний элемент.
                        Array.Resize(ref IRNN1.m_Neuronet, IRNN1.m_Neuronet.Length - 1); // Удаляем последний элемент из массива.
                    }
                }
            }
            // Обновление списка образов:
            ToolImage.Items.Clear();
            for (i = 1; i < IRNN1.m_Neuronet.Length; i++) ToolImage.Items.Add(IRNN1.m_Neuronet[i].Name);
            Program.UseShell = true;
        }

        /// <summary>
        /// Метод запуска процесса распознавания образа.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolImgRcg_Click(object sender, EventArgs e)
        {
            Program.UseShell = false;
            Int32 ProbableIndex = 0; // Индекс наиболее соответствующего образа.
            Single Probable = 1e10f, Equivalence; // Самое вероятное соответствие с образом под индексом ProbableIndex; текущее соответствие.
            for (Int32 i = 1; i < IRNN1.m_Neuronet.Length; i++) // Цикл по библиотеке образов.
            {
                Equivalence = ClassIRNN1.CompareImages(ref IRNN1.m_CurrentNeuronet, ref IRNN1.m_Neuronet[i]);
                if (Equivalence < Probable)
                {
                    Probable = Equivalence;
                    ProbableIndex = i;
                }
            }
            if (ProbableIndex != 0)
                if (Probable < 2e8f) // 2e8f - это порог, за которым уже нельзя сказать, что это за образ.
                    MessageBox.Show("Это " + IRNN1.m_Neuronet[ProbableIndex].Name + ".\n\nОшибка: " + Probable.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Невозможно распознать образ. Ошибка слишком велика.\n\nОшибка: " + Probable.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Program.UseShell = true;
        }

        /// <summary>
        /// Метод начала рисования на холсте с текущим образом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) Painting = true; // Если нажата левая кнопка мыши, начинаем рисовать.
        }

        /// <summary>
        /// Основной метод отрисовки образа.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (Painting) // При нажатой левой кнопке, рисуем на холсте...
            {
                switch (StylusType)
                {
                    case 1: // Распылитель.
                        Pen EStylus = new Pen(Stylus.Color, 1.0f);
                        for (k = 0; k < 15; k++)
                        {
                            i = Rnd.Next(e.Y - (Int32)Stylus.Width, e.Y + (Int32)Stylus.Width);
                            j = Rnd.Next(e.X - (Int32)Stylus.Width, e.X + (Int32)Stylus.Width);
                            if (Math.Pow(e.X - j, 2) + Math.Pow(e.Y - i, 2) < Math.Pow(Stylus.Width, 2))
                                BgrpImage.Graphics.DrawLine(EStylus, j, i, j + 1, i + 1);
                        }
                        break;
                    default: // Обычная кисть.
                        BgrpImage.Graphics.FillEllipse(Stylus.Brush, e.X - Stylus.Width, e.Y - Stylus.Width, 2 * Stylus.Width, 2 * Stylus.Width);
                        break;
                }
                BgrpImage.Render(); // Сразу рисуем на экране содержимое графического буфера.
            }
        }

        /// <summary>
        /// Метод завершения рисования на холсте.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_MouseUp(object sender, MouseEventArgs e)
        {
            // Прекращаем рисование:
            if (Painting == true)
            {
                Color Clr;
                IntPtr hDC = BgrpImage.Graphics.GetHdc(); // Указатель на контекст.
                // Переписываем содержимое графического буфера в текущий образ:
                for (Int32 i = 0; i < IRNN1.PictureDimension; i++)
                    for (Int32 j = 0; j < IRNN1.PictureDimension; j++)
                    {
                        // Преобразуем в специальную структуру цвета:
                        Clr = ColorTranslator.FromWin32(GetPixel(hDC, j, i));
                        IRNN1.m_CurrentNeuronet.Pixel[j, i].R = Clr.R;
                        IRNN1.m_CurrentNeuronet.Pixel[j, i].G = Clr.G;
                        IRNN1.m_CurrentNeuronet.Pixel[j, i].B = Clr.B;
                    }
                BgrpImage.Graphics.ReleaseHdc(hDC); // Освобождаем ранее занятые ресурсы.
                Painting = false; // Рисование прекращено.
                ToolRefresh_Click(null, null); // Перерисовывание образа и состояния нейронной сети.
            }
        }

        /// <summary>
        /// Метод изменения параметров кисти.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextPenProperties_Click(object sender, EventArgs e)
        {
            Program.UseShell = false;
            FormPenProperties Dialog = new FormPenProperties(); // Создание экземпляра диалога для выбора параметров кисти.
            // Установка текущих параметров кисти:
            Dialog.ButtonColor.BackColor = Stylus.Color;
            Dialog.NumberSize.Value = (Decimal)Stylus.Width;
            Dialog.ComboType.Text = Dialog.ComboType.Items[StylusType].ToString();
            // Отображение диалога:
            Dialog.Left = Right;
            Dialog.Top = Top;
            TimerRefresher.Enabled = true; // Запускаем таймер обновления экрана. Если просто ToolRefresh_Click вызвать, окно не перерисуется. Незнаю почему, в проблему не вникал.
                                           // Мда... не C++, словом язык для домохозяек, зато интерфейс быстро и удобно мутить можно.
            Dialog.ShowDialog(); // Показываем её пользователю.
            if (!Dialog.Cancel) // Если нажата клавиша 'Ok'...
            {
                // Сохраняем новые параметры кисти:
                Stylus.Color = Dialog.ButtonColor.BackColor;
                Stylus.Width = (float)Dialog.NumberSize.Value;
                switch (Dialog.ComboType.Text.ToLower())
                {
                    case "распылитель": // Распылитель.
                        StylusType = 1;
                        break;
                    default: // Обычная кисть.
                        StylusType = 0;
                        break;
                }
            }
            Dialog.Dispose(); // Освобождаем ресурсы системы.
            TimerRefresher.Enabled = true;
            Program.UseShell = true;
        }

        /// <summary>
        /// Метод очистки образа.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextClear_Click(object sender, EventArgs e)
        {
            BgrpImage.Graphics.Clear(Color.Black); // Очистка холста.
            BgrpNeuronet.Graphics.Clear(Color.Black); // Очистка состояния нейронной сети.
            // Очистка текущего образа:
            for (Int32 i = 0; i < IRNN1.PictureDimension; i++)
                for (Int32 j = 0; j < IRNN1.PictureDimension; j++)
                {
                    // Задаем черный цвет:
                    IRNN1.m_CurrentNeuronet.Pixel[j, i].R = 0;
                    IRNN1.m_CurrentNeuronet.Pixel[j, i].G = 0;
                    IRNN1.m_CurrentNeuronet.Pixel[j, i].B = 0;
                }
            ToolRefresh_Click(null, null);
        }

        /// <summary>
        /// Метод освобождения ресурсов при закрытии программы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormImgRcg_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.UseShell = false;
            if (MessageBox.Show("Вы действительно хотите завершить работу программы?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
            Program.UseShell = true;
        }
    }
}