using System;
using System.Collections.Generic;
using System.IO;
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
using WpfApp1;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Fuvar> fuvarok = new List<Fuvar>();
        public MainWindow()
        {
            InitializeComponent();

            StreamReader sr = new StreamReader("fuvar.csv");
            sr.ReadLine();
            while (!sr.EndOfStream){
                string[] adat = sr.ReadLine().Split(";");
                fuvarok.Add(new Fuvar(int.Parse(adat[0]), adat[1], int.Parse(adat[2]), float.Parse(adat[3]), float.Parse(adat[4]), float.Parse(adat[5]), adat[6]));
            }
            sr.Close();
        }

        private void btnHarmadik_Click(object sender, RoutedEventArgs e)
        {
            harmadikFeladat.Content = $"3. feladat: {fuvarok.Count()} fuvar";
        }

        private void btnNegyedik_Click(object sender, RoutedEventArgs e)
        {
            negyedikFeladat.Content = $"4. feladat: {fuvarok.Count(x => x.TaxiAzonosito == 6185)} fuvar alatt: {fuvarok.Where(x=>x.TaxiAzonosito == 6185).Sum(x=>x.Viteldij)}$";
        }

        private void btnOtodik_Click(object sender, RoutedEventArgs e)
        {
            otodikFeladat.Items.Add("5. feladat:");
            fuvarok.GroupBy(x => x.Fizetes).ToList().ForEach(x => otodikFeladat.Items.Add($"\t{x.Key}: {x.Count()} fuvar"));
        }

        private void btnHatodik_Click(object sender, RoutedEventArgs e)
        {
            hatodikFeladat.Content = $"{Math.Round(fuvarok.Sum(x => x.Tav * 1.6), 2)}km";
        }

        private void btnNyolcadik_Click(object sender, RoutedEventArgs e)
        {
            nyolcadikFeladat.Content = "8. feladat: hibak.txt";
            using (StreamWriter writer = new StreamWriter("hibak.txt"))
            {
                writer.WriteLine("fuvar_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja");
                fuvarok.Where(x => x.Idotartam > 0 && x.Viteldij > 0 && x.Tav == 0).OrderBy(x => x.Indulas).ToList().ForEach
                    (x => writer.WriteLine($"{x.TaxiAzonosito};{x.Indulas};{x.Idotartam};{x.Tav};{x.Viteldij};{x.Borravalo};{x.Fizetes}"));
            }
        }
    }
}
