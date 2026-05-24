using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace UnitTestingLab
{
    public class CalculatorForm : Form
    {
        private TabControl tabControl;
        private Label lblResult, lblErrorCode;

        public CalculatorForm()
        {
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Лабораторная работа №8, Гаврилов Артём";
            this.Size = new Size(700, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 245);

            Label lblTitle = new Label
            {
                Text = "КАЛЬКУЛЯТОР С МОДУЛЬНЫМ ТЕСТИРОВАНИЕМ",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 120, 215),
                Location = new Point(20, 15),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            tabControl = new TabControl
            {
                Location = new Point(20, 50),
                Size = new Size(640, 400),
                Font = new Font("Segoe UI", 10F)
            };

            tabControl.TabPages.Add(CreateInchesTab());
            tabControl.TabPages.Add(CreateEvenTab());
            tabControl.TabPages.Add(CreateMaxTab());
            tabControl.TabPages.Add(CreateModuloTab());
            tabControl.TabPages.Add(CreateInterestTab());
            tabControl.TabPages.Add(CreateTestsTab());

            this.Controls.Add(tabControl);

            lblResult = new Label
            {
                Location = new Point(20, 460),
                Size = new Size(400, 30),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.Green,
                Text = "Результат: готов к работе"
            };
            this.Controls.Add(lblResult);

            lblErrorCode = new Label
            {
                Location = new Point(450, 460),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                Text = "Код ошибки: 0"
            };
            this.Controls.Add(lblErrorCode);
        }

        private TabPage CreateInchesTab()
        {
            TabPage tab = new TabPage("Дюймы → См");

            Label lbl = new Label
            {
                Text = "Введите длину в дюймах:",
                Location = new Point(20, 20),
                AutoSize = true
            };
            tab.Controls.Add(lbl);

            TextBox txtInches = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 12F)
            };
            tab.Controls.Add(txtInches);

            Button btn = new Button
            {
                Text = "Перевести",
                Location = new Point(20, 90),
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.Click += (s, e) =>
            {
                if (double.TryParse(txtInches.Text, out double inches))
                {
                    var (result, error) = Calculator.InchesToCentimeters(inches);
                    ShowResult(result.ToString("F2") + " см", error);
                }
                else
                    ShowResult("Ошибка ввода", Calculator.ERROR_INVALID_INPUT);
            };
            tab.Controls.Add(btn);

            return tab;
        }

        private TabPage CreateEvenTab()
        {
            TabPage tab = new TabPage("Чётность");

            Label lbl = new Label
            {
                Text = "Введите число:",
                Location = new Point(20, 20),
                AutoSize = true
            };
            tab.Controls.Add(lbl);

            TextBox txtNumber = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 12F)
            };
            tab.Controls.Add(txtNumber);

            Button btn = new Button
            {
                Text = "Проверить",
                Location = new Point(20, 90),
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.Click += (s, e) =>
            {
                if (int.TryParse(txtNumber.Text, out int num))
                {
                    var (isEven, error) = Calculator.IsEven(num);
                    ShowResult(isEven ? $"{num} - ЧЁТНОЕ" : $"{num} - НЕЧЁТНОЕ", error);
                }
                else
                    ShowResult("Ошибка ввода", Calculator.ERROR_INVALID_INPUT);
            };
            tab.Controls.Add(btn);

            return tab;
        }

        private TabPage CreateMaxTab()
        {
            TabPage tab = new TabPage("Максимум");

            Label lbl = new Label
            {
                Text = "Введите числа через запятую:",
                Location = new Point(20, 20),
                AutoSize = true
            };
            tab.Controls.Add(lbl);

            TextBox txtArray = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(400, 30),
                Font = new Font("Segoe UI", 12F),
            };
            tab.Controls.Add(txtArray);

            Button btn = new Button
            {
                Text = "Найти максимум",
                Location = new Point(20, 90),
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.Click += (s, e) =>
            {
                try
                {
                    int[] arr = txtArray.Text.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => int.Parse(x.Trim())).ToArray();
                    var (max, error) = Calculator.FindMax(arr);
                    ShowResult($"Максимум: {max}", error);
                }
                catch
                {
                    ShowResult("Ошибка ввода массива", Calculator.ERROR_INVALID_INPUT);
                }
            };
            tab.Controls.Add(btn);

            return tab;
        }

        private TabPage CreateModuloTab()
        {
            TabPage tab = new TabPage("Остаток от деления");

            Label lbl1 = new Label
            {
                Text = "Делимое:",
                Location = new Point(20, 20),
                AutoSize = true
            };
            tab.Controls.Add(lbl1);

            TextBox txtDividend = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(150, 30),
                Font = new Font("Segoe UI", 12F)
            };
            tab.Controls.Add(txtDividend);

            Label lbl2 = new Label
            {
                Text = "Делитель:",
                Location = new Point(200, 20),
                AutoSize = true
            };
            tab.Controls.Add(lbl2);

            TextBox txtDivisor = new TextBox
            {
                Location = new Point(200, 50),
                Size = new Size(150, 30),
                Font = new Font("Segoe UI", 12F)
            };
            tab.Controls.Add(txtDivisor);

            Button btn = new Button
            {
                Text = "Вычислить остаток",
                Location = new Point(20, 90),
                Size = new Size(180, 35),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.Click += (s, e) =>
            {
                if (int.TryParse(txtDividend.Text, out int dividend) &&
                    int.TryParse(txtDivisor.Text, out int divisor))
                {
                    var (remainder, error) = Calculator.Modulo(dividend, divisor);
                    if (error == Calculator.ERROR_NONE)
                        ShowResult($"{dividend} % {divisor} = {remainder}", error);
                    else
                        ShowResult("Деление на ноль", error);
                }
                else
                    ShowResult("Ошибка ввода", Calculator.ERROR_INVALID_INPUT);
            };
            tab.Controls.Add(btn);

            return tab;
        }

        private TabPage CreateInterestTab()
        {
            TabPage tab = new TabPage("Банковский процент");

            Label lbl = new Label
            {
                Text = "Введите сумму вклада (руб):",
                Location = new Point(20, 20),
                AutoSize = true
            };
            tab.Controls.Add(lbl);

            TextBox txtDeposit = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 12F)
            };
            tab.Controls.Add(txtDeposit);

            Label lblInfo = new Label
            {
                Text = "Ставки: <100₽ → 5%, 100-200₽ → 7%, >200₽ → 10%",
                Location = new Point(20, 90),
                AutoSize = true,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 9F)
            };
            tab.Controls.Add(lblInfo);

            Button btn = new Button
            {
                Text = "Рассчитать",
                Location = new Point(20, 120),
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.Click += (s, e) =>
            {
                if (double.TryParse(txtDeposit.Text, out double deposit))
                {
                    var (total, error) = Calculator.CalculateBankInterest(deposit);
                    if (error == Calculator.ERROR_NONE)
                    {
                        double rate = deposit < 100 ? 5 : (deposit <= 200 ? 7 : 10);
                        ShowResult($"Сумма с процентом: {total:F2}₽ (ставка {rate}%)", error);
                    }
                    else
                        ShowResult("Отрицательная сумма", error);
                }
                else
                    ShowResult("Ошибка ввода", Calculator.ERROR_INVALID_INPUT);
            };
            tab.Controls.Add(btn);

            return tab;
        }

        private TabPage CreateTestsTab()
        {
            TabPage tab = new TabPage("Запуск тестов");

            Label lbl = new Label
            {
                Text = "Нажмите кнопку для запуска всех модульных тестов",
                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 11F)
            };
            tab.Controls.Add(lbl);

            Button btnRunTests = new Button
            {
                Text = "ЗАПУСТИТЬ ВСЕ ТЕСТЫ",
                Location = new Point(20, 60),
                Size = new Size(250, 50),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRunTests.Click += (s, e) =>
            {
                RunAllTests();
            };
            tab.Controls.Add(btnRunTests);

            TextBox txtTestResults = new TextBox
            {
                Location = new Point(20, 120),
                Size = new Size(580, 240),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Consolas", 9F),
                BackColor = Color.White
            };
            tab.Controls.Add(txtTestResults);

            tab.Tag = txtTestResults;

            return tab;
        }

        private void ShowResult(string text, int errorCode)
        {
            lblResult.Text = "Результат: " + text;
            lblResult.ForeColor = errorCode == Calculator.ERROR_NONE ? Color.Green : Color.Red;
            lblErrorCode.Text = $"Код ошибки: {errorCode}";
            lblErrorCode.ForeColor = errorCode == Calculator.ERROR_NONE ? Color.Gray : Color.OrangeRed;
        }

        private void RunAllTests()
        {
            var results = new System.Text.StringBuilder();
            int passed = 0, total = 0;

            results.AppendLine("ЗАПУСК МОДУЛЬНЫХ ТЕСТОВ\n");

            total++;
            var (r1, e1) = Calculator.InchesToCentimeters(10);
            if (e1 == Calculator.ERROR_NONE && Math.Abs(r1 - 25.4) < 0.001)
            {
                results.AppendLine("InchesToCentimeters(10) = 25.4");
                passed++;
            }
            else
                results.AppendLine("InchesToCentimeters(10) - FAILED");

            total++;
            var (r2, e2) = Calculator.InchesToCentimeters(-5);
            if (e2 == Calculator.ERROR_INVALID_INPUT)
            {
                results.AppendLine("InchesToCentimeters(-5) → ERROR_INVALID_INPUT");
                passed++;
            }
            else
                results.AppendLine("InchesToCentimeters(-5) - FAILED");

            total++;
            var (even1, err1) = Calculator.IsEven(4);
            if (even1 == true)
            {
                results.AppendLine("IsEven(4) = true");
                passed++;
            }
            else
                results.AppendLine("IsEven(4) - FAILED");

            total++;
            var (even2, err2) = Calculator.IsEven(7);
            if (even2 == false)
            {
                results.AppendLine("IsEven(7) = false");
                passed++;
            }
            else
                results.AppendLine("IsEven(7) - FAILED");

            total++;
            var (max1, errMax1) = Calculator.FindMax(new int[] { 3, 7, 2, 9, 1 });
            if (max1 == 9 && errMax1 == Calculator.ERROR_NONE)
            {
                results.AppendLine("FindMax([3,7,2,9,1]) = 9");
                passed++;
            }
            else
                results.AppendLine("FindMax - FAILED");

            total++;
            var (max2, errMax2) = Calculator.FindMax(null);
            if (errMax2 == Calculator.ERROR_NULL_ARRAY)
            {
                results.AppendLine("FindMax(null) → ERROR_NULL_ARRAY");
                passed++;
            }
            else
                results.AppendLine("FindMax(null) - FAILED");

            total++;
            var (mod1, errMod1) = Calculator.Modulo(17, 5);
            if (mod1 == 2 && errMod1 == Calculator.ERROR_NONE)
            {
                results.AppendLine("Modulo(17, 5) = 2");
                passed++;
            }
            else
                results.AppendLine("Modulo(17, 5) - FAILED");

            total++;
            var (mod2, errMod2) = Calculator.Modulo(10, 0);
            if (errMod2 == Calculator.ERROR_DIVISION_BY_ZERO)
            {
                results.AppendLine("Modulo(10, 0) → ERROR_DIVISION_BY_ZERO");
                passed++;
            }
            else
                results.AppendLine("Modulo(10, 0) - FAILED");

            total++;
            var (bank1, errBank1) = Calculator.CalculateBankInterest(100);
            if (Math.Abs(bank1 - 107.0) < 0.001)
            {
                results.AppendLine("CalculateBankInterest(100) = 107.0 (7%)");
                passed++;
            }
            else
                results.AppendLine("CalculateBankInterest(100) - FAILED");

            total++;
            var (bank2, errBank2) = Calculator.CalculateBankInterest(300);
            if (Math.Abs(bank2 - 330.0) < 0.001)
            {
                results.AppendLine("CalculateBankInterest(300) = 330.0 (10%)");
                passed++;
            }
            else
                results.AppendLine("CalculateBankInterest(300) - FAILED");

            results.AppendLine($"\nИТОГО: {passed}/{total} тестов пройдено");
            results.AppendLine(passed == total ? "ВСЕ ТЕСТЫ УСПЕШНЫ" : "ЕСТЬ ОШИБКИ");

            foreach (TabPage tab in tabControl.TabPages)
            {
                if (tab.Text == "Запуск тестов" && tab.Tag is TextBox txtResults)
                {
                    txtResults.Text = results.ToString();
                    break;
                }
            }

            ShowResult($"{passed}/{total} тестов пройдено", passed == total ? Calculator.ERROR_NONE : -999);
        }
    }

    static class ProgramExtension
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalculatorForm());
        }
    }
}