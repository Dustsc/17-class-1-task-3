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
using System.Collections.ObjectModel;
using System.ComponentModel;
using log4net;
using WpfApp1.Triton.Common;
using WpfApp1.Triton.Common.settings;
using Logger = WpfApp1.Triton.Common.LogUtilities.LogManagers;

using System.Windows.Forms;
using ClosedXML;
using ClosedXML.Excel;
using System.Text.RegularExpressions;
using System.IO;

namespace WpfApp1.Plugins.P114T4
{

    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class P114T4Settings : JsonSettings, INotifyPropertyChanged
    {
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();
        private static P114T4Settings _instance;
        private Stream outputfile;
        public string filename="", extension="",savepath="";
        private int below=1;
        private int wage=1;
        private int age=1;
        private int number=1;
        private int person=1;
        private int perage=1;
        private int name=1;
        private bool rowcol1 =true, methods1=true,rowcol2=false,methods2=false;
        private string path;

        public static P114T4Settings Instance
        {
            get { return _instance ?? (_instance = new P114T4Settings()); }
        }

        public P114T4Settings() : base(GetSettingsFilePath(Configuration.Instance.Name, string.Format("{0}.json", "P114T4")))
        {
        }

        public void Dealfile()
        {
            if (!Savefile())
            {
                Log.InfoFormat("[P114T4] Failed.");
                return;
            }
            Dealxls();
        }

        public int Wage { get { return wage; } set { wage = value; if(wage<=1){Log.InfoFormat("[P114T4] this is started by 1.");wage=1; } } }
        public int Age { get { return age; } set { age = value; if(age<=1){Log.InfoFormat("[P114T4] this is started by 1.");age=1; }  } }
        public int Number { get { return number; } set { number = value; if(number<=1){Log.InfoFormat("[P114T4] this is started by 1.");number=1; }  } }
        public int Person { get { return person; } set { person = value;  } }
        public int Perage { get { return perage; } set { perage = value; } }
        public int Below { get { return below; } set { below = value; } }
        public int Names { get { return name; } set { name = value; if(name<=1){Log.InfoFormat("[P114T4] this is started by 1.");name=1; }  } }

        public bool Rowcol1 { get { return rowcol1; } set { rowcol1 = value; rowcol2 = !rowcol1;
                OnPropertyChanged("Rowcol2");
                OnPropertyChanged("labelstext");
            } }
        public string Labelstext { get { return rowcol1 ? "列" : "行"; } }
        public bool Methods1 { get { return methods1; } set { methods1 = value; methods2 = !methods1;
                OnPropertyChanged("Methods2");
            } }
        public bool Rowcol2 { get { return rowcol2; } set { rowcol2 = value; rowcol1 = !rowcol2;
                OnPropertyChanged("Rowcol1");
                OnPropertyChanged("labelstext");
            } }
        public bool Methods2 { get { return methods2; } set { methods2 = value; methods1 = !methods2;
                OnPropertyChanged("Methods1");
            } }

        public string Path { get { return path; } set { path = value;
                extension = System.IO.Path.GetExtension(path); } }

        public bool Openfile()
        {
            /*
            System.Windows.Forms.FolderBrowserDialog folder = new System.Windows.Forms.FolderBrowserDialog();

            if (folder.ShowDialog() == DialogResult.OK)
            {
                this.txtboxPath.Text = folder.SelectedPath;

            }*/

            // 获取文件和路径名 一起显示在 txtbox 控件里

            using (OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "EXCEL|*.xlsx"//|XMLdocment|*.xml
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Path = dialog.FileName;
                    filename = dialog.SafeFileName;
                    extension = System.IO.Path.GetExtension(Path);
                    OnPropertyChanged("Path");
                    return true;
                }
            }
            return false;
        }

        public double Exchan0(object values)
        {
            var isA = values.GetType() == typeof(string);
            if (isA) return double.Parse((string)values);
            isA = values.GetType() == typeof(double);
            if (isA) return (double)values;
            isA = values.GetType() == typeof(float);
            if (isA) return (double)(float)values;
            isA = values.GetType() == typeof(int);
            if (isA) return (double)(int)values;
            return (double)values;
        }

        public string Exchan1(object values)
        {
            var isA = values.GetType() == typeof(string);
            if (isA) return (string)values;
            isA = values.GetType() == typeof(double);
            if (isA) return (double)values + "";
            isA = values.GetType() == typeof(float);
            if (isA) return (float)values + "";
            isA = values.GetType() == typeof(int);
            if (isA) return (int)values + "";
            return "" + values;
        }

        public bool Savefile()
        {
            /*
            System.Windows.Forms.FolderBrowserDialog folder = new System.Windows.Forms.FolderBrowserDialog();

            if (folder.ShowDialog() == DialogResult.OK)
            {
                this.txtboxPath.Text = folder.SelectedPath;

            }*/

            // 获取文件和路径名 一起显示在 txtbox 控件里
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Filter = "File|*" + extension;
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    Log.InfoFormat("[P114T4] Reading the file from the source......");
                    savepath = sf.FileName;
                    outputfile = sf.OpenFile();
                    try
                    {
                        int line = 1;
                        int alllines = 0;
                        string importExcelPath = Path;
                        string exportExcelPath = savepath;
                        var workbook = new XLWorkbook(importExcelPath);
                        Log.InfoFormat("[P114T4] Statistics......");

                        IXLWorksheet sheet = workbook.Worksheet(1);//这个库也是从1开始
                                                                   //设置第一行第一列值,更多方法请参考官方Demo
                        IXLWorksheet sheet2 = workbook.Worksheet(2);//这个库也是从1开始
                                                                    //设置第一行第一列值,更多方法请参考官方Demo
                        if (Rowcol1)
                            for (; Exchan1(sheet.Cell(line, Wage).Value) != ""; line++)
                            {
                                if (IsNumeric(Exchan1(sheet.Cell(line, Wage).Value)))
                                {
                                    break;
                                }
                            }
                        else
                            for (; Exchan1(sheet.Cell(Wage, line).Value) != ""; line++)
                            {
                                if (IsNumeric(Exchan1(sheet.Cell(Wage, line).Value)))
                                {
                                    break;
                                }
                            }
                        if (Rowcol1)
                            for (int i = line; Exchan1(sheet.Cell(i, Wage).Value) != ""; i++)
                            {
                                alllines++;
                            }
                        else
                            for (int i = line; Exchan1(sheet.Cell(Wage, i).Value) != ""; i++)
                            {
                                alllines++;
                            }
                        Log.InfoFormat("[P114T4] Start. Working......");
                        sheet2.Cell(1, 1).Value = "姓名";
                        sheet2.Cell(1, 2).Value = "旧工资";
                        sheet2.Cell(1, 3).Value = "新工资";
                        if (Rowcol1 && Methods1)
                            for (int i = line, j = 2; Exchan1(sheet.Cell(i, Wage).Value) != ""; i++, j++)
                            {
                                sheet2.Cell(j, 1).Value = sheet.Cell(i, Names).Value;
                                sheet2.Cell(j, 2).Value = sheet.Cell(i, Wage).Value;
                                sheet2.Cell(j, 3).Value = sheet.Cell(i, Wage).Value;
                                double w = Exchan0(sheet.Cell(i, Wage).Value);
                                if (w >= below) continue;
                                double a = Exchan0(sheet.Cell(i, Age).Value);
                                double n = Exchan0(sheet.Cell(i, Number).Value);
                                w = w + perage * a + Person * n;
                                if (w > below)
                                {
                                    w = below;
                                }
                                sheet.Cell(i, Wage).Value = "" + w;
                                sheet2.Cell(j, 3).Value = sheet.Cell(i, Wage).Value;
                                Log.InfoFormat("[P114T4] Finshed {0}% ({1}/{2})", ((j - 1.0f) * 100) / alllines, j - 1, alllines);
                            }
                        else if (Rowcol1 && !Methods1)
                            for (int i = line, j = 2; Exchan1(sheet.Cell(i, Wage).Value) != ""; i++, j++)
                            {
                                sheet2.Cell(j, 1).Value = sheet.Cell(i, Names).Value;
                                sheet2.Cell(j, 2).Value = sheet.Cell(i, Wage).Value;
                                sheet2.Cell(j, 3).Value = sheet.Cell(i, Wage).Value;
                                double w = Exchan0(sheet.Cell(i, Wage).Value);
                                if (w >= below) continue;
                                double a = Exchan0(sheet.Cell(i, Age).Value);
                                double n = Exchan0(sheet.Cell(i, Number).Value);
                                w = w + perage * a + Person * n;
                                if (w > below)
                                {
                                    w = below;
                                }
                                sheet.Cell(i, Wage).Value = "" + w;
                                sheet2.Cell(j, 3).Value = sheet.Cell(i, Wage).Value;
                                Log.InfoFormat("[P114T4] Finshed {0}% ({1}/{2})", ((j - 1.0f) * 100) / alllines, j - 1, alllines);
                            }
                        else if (!Rowcol1 && Methods1)
                            for (int i = line, j = 2; Exchan1(sheet.Cell(Wage, i).Value) != ""; i++, j++)
                            {
                                sheet2.Cell(j, 1).Value = sheet.Cell(Names, i).Value;
                                sheet2.Cell(j, 2).Value = sheet.Cell(Wage, i).Value;
                                sheet2.Cell(j, 3).Value = sheet.Cell(Wage, i).Value;
                                double w = Exchan0(sheet.Cell(Wage, i).Value);
                                if (w >= below) continue;
                                double a = Exchan0(sheet.Cell(Age, i).Value);
                                double n = Exchan0(sheet.Cell(Number, i).Value);
                                w = w + perage * a + Person * n;
                                if (w > below)
                                {
                                    w = below;
                                }
                                sheet.Cell(Wage, i).Value = "" + w;
                                sheet2.Cell(j, 3).Value = sheet.Cell(Wage, i).Value;
                                Log.InfoFormat("[P114T4] Finshed {0}% ({1}/{2})", ((j - 1.0f) * 100) / alllines, j - 1, alllines);
                            }
                        else if (!Rowcol1 && !Methods1)
                            for (int i = line, j = 2; Exchan1(sheet.Cell(Wage, i).Value) != ""; i++, j++)
                            {
                                sheet2.Cell(j, 1).Value = sheet.Cell(Names, i).Value;
                                sheet2.Cell(j, 2).Value = sheet.Cell(Wage, i).Value;
                                sheet2.Cell(j, 3).Value = sheet.Cell(Wage, i).Value;
                                double w = Exchan0(sheet.Cell(Wage, i).Value);
                                if (w >= below) continue;
                                double a = Exchan0(sheet.Cell(Age, i).Value);
                                double n = Exchan0(sheet.Cell(Number, i).Value);
                                w = w + perage * a + Person * n;
                                if (w > below)
                                {
                                    w = below;
                                }
                                sheet.Cell(Wage, i).Value = "" + w;
                                sheet2.Cell(j, 3).Value = sheet.Cell(Wage, i).Value;
                                Log.InfoFormat("[P114T4] Finshed {0}% ({1}/{2})", ((j - 1.0f) * 100) / alllines, j - 1, alllines);
                            }
                        //sheet.Cell(1, 1).Value = "test";//该方法也是从1开始，非0

                        //workbook.SaveAs(exportExcelPath);
                        using (var ms = outputfile)
                        {
                            workbook.SaveAs(ms);
                            ms.Flush();
                            ms.Dispose();
                            ms.Close();
                        }
                        workbook.Dispose();
                        sf.Dispose();
                    }
                    catch (Exception e)
                    {
                        Log.DebugFormat("[P114T4] A terrible Error was happened when the program is dealing the file(*.xls).{0} {1}", e.Message, e.StackTrace);
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
        public bool Dealxls()
        {
            Log.InfoFormat("[P114T4] Succeed!");
            return true;
        }
        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }
        public static bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }
        public static bool IsUnsign(string value)
        {
            return Regex.IsMatch(value, @"^\d*[.]?\d*$");
        }

        public static bool IsTel(string strInput)
        {
            return Regex.IsMatch(strInput, @"\d{3}-\d{8}|\d{4}-\d{7}");
        }


        public new event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
			if(propertyName!=null)
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
