namespace Lab3
{
    public partial class Form1 : Form
    {
        //        поточне число Фібоначчі  сума всіх згенерованих чисел
        private long currentFibonacci = 0, sum = 0;

        // семафор для синхронізації потоків: один чекає, поки інший згенерує число
        // за замовчуванням доступу до нього немає для жодного потоку
        // максимум потоків, які будуть отримувати доступ, встановив в 1
        private Semaphore semaphore = new Semaphore(0, 1);

        // глибина — скільки чисел Фібоначчі буде згенеровано
        private int depth;

        public Form1()
        {
            InitializeComponent();

            // обмеження глибини для коректної роботи
            this.numericUpDown_depth.Minimum = 3;
            this.numericUpDown_depth.Maximum = 15;
        }

        // обробник натискання кнопки "start"
        // в ньому роблю кнопку "start" неактивною, отримую значення для depth з NumericUpDown
        // очищую RichTextBox, скидую суму та запускаю метод Run()
        private void start_Click(object sender, EventArgs e)
        {
            this.button_start.Enabled = false;

            depth = (int)numericUpDown_depth.Value;
            richTextBox_output.Text = "";
            sum = 0;

            this.Run();
        }

        // Безпосередньо метод Run(), в ньому просто запускаю потоки зі встановленим
        // значенням для Thread.IsBackground як true
        // кожен з потоків виконує свій метод для обчислень
        private void Run()
        {
            Thread th1 = new Thread(this.Th1Task);
            Thread th2 = new Thread(this.Th2Task);

            th1.IsBackground = true;
            th2.IsBackground = true;

            th1.Start();
            th2.Start();
        }

        // метод який просто генерує числа Фібоначчі
        // після генерації числа даю дозвіл на виконання для другого потоку
        // для наочності зробив затримку на секунду
        private void Th1Task()
        {
            long a = 0, b = 1;
            for (int i = 0; i < this.depth; ++i)
            {
                this.currentFibonacci = a;
                this.semaphore.Release();

                Thread.Sleep(1000);

                long next = a + b;
                a = b;
                b = next;
            }
        }

        // метод що очікую на генерацію числа, після чого додає його до загальної суми та виводить в UI
        // Invoke()'и для доступу до елементів основного потоку з дочірніх потоків
        private void Th2Task()
        {
            for (int i = 0; i < this.depth; i++)
            {
                this.semaphore.WaitOne();

                this.sum += currentFibonacci;

                this.Invoke(() => richTextBox_output.AppendText(
                    $"Fibonacci num: {currentFibonacci}, Sum: {sum}\r\n"));
            }

            this.Invoke(() => button_start.Enabled = true);
        }
    }
}
