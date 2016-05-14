using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Console;
using static CSharp6.Customer;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Static_Button(object sender, RoutedEventArgs e)
        {
            WriteLine("Static Message");
        }

        private void AutoInitilizers_button(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Age: {0}", ShowAge().ToString()) ;
        }

        private void DictionaryInitializers_button(object sender, RoutedEventArgs e)
        {
            var stars = new Dictionary<string, string>()
            {
                 { "Michael Jordon", "Basketball" },
                 { "Peyton Manning", "Football" },
                 { "Babe Ruth", "Baseball" }
            };

            foreach (KeyValuePair<string, string> keyValuePair in stars)
            {
                MessageBox.Show(keyValuePair.Key + ": " +
                keyValuePair.Value + "\n");
            }
        }

        private void StringInterpolation_button(object sender, RoutedEventArgs e)
        {
            string firstName = "Michael";
            string lastName = "Crump";

            string Name = ($"{firstName} {lastName} is my name!");
            MessageBox.Show("Name : " + Name );

        }

        private void nameOfExpression_button(object sender, RoutedEventArgs e)
        {
            try
            {
                Nameof(null);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Nameof(string name)
        {
            if (name == null) throw new Exception(nameof(name) + " is null");
        }
        private static double MultiplyNumbers(double num1, double num2) => num1 * num2;

        private void ExpressionBodiedFunctionProperty_button(object sender, RoutedEventArgs e)
        {
            double num1 = 5;
            double num2 = 10;

            MessageBox.Show(MultiplyNumbers(num1, num2).ToString());
        }

        private void ExceptionFilters_button(object sender, RoutedEventArgs e)
        {
            var httpStatusCode = 404;
            Write("HTTP Error: ");

            try
            {
                throw new Exception(httpStatusCode.ToString());
            }
            catch (Exception ex) when (ex.Message.Equals("400"))
            {
                MessageBox.Show("Bad Request");
            }
            catch (Exception ex) when (ex.Message.Equals("401"))
            {
                MessageBox.Show("Unauthorized");
            }
            catch (Exception ex) when (ex.Message.Equals("402"))
            {
                MessageBox.Show("Payment Required");
            }
            catch (Exception ex) when (ex.Message.Equals("403"))
            {
                MessageBox.Show("Forbidden");
            }
            catch (Exception ex) when (ex.Message.Equals("404"))
            {
                MessageBox.Show("Not Found");
            }
        }

        private void AwaitCatchandFinallyBlock_button(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() => GetPage());
        }

        private async static Task GetPage()
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync("test");
                MessageBox.Show(result);
            }
            catch (Exception exception)
            {
                try
                {
                    //This asynchronous request will run if the first request failed. 
                    var result = await client.GetStringAsync("test2");
                    MessageBox.Show(result);
                }
                catch
                {
                    MessageBox.Show("Entered Catch Block");
                }
                finally
                {
                    MessageBox.Show("Entered Finally Block");
                }
            }
        }

        private void NullConditionalOperator_button(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            if (person.Name == String.Empty)
            {
                person = null;
            }

            MessageBox.Show(person?.Name ?? "Field is null.");
        }
    }
}
