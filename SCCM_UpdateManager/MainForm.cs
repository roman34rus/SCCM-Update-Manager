using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCCM_UpdateManager
{
    public partial class MainForm : Form
    {
        // объект для работы с сервером SCCM
        private SccmClass Sccm;
        //-------------------------------------------------------

        // список контейнеров Update'ов
        private List<UpdateContainerClass> Containers;
        //-------------------------------------------------------

        // конструктор формы
        public MainForm()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------
        
        // нажатие на кнопку "подключиться"
        private void fConnect_Click(object sender, EventArgs e)
        {
            // подключаемся к серверу SCCM
            Sccm = new SccmClass();
            if (!Sccm.Connect(fServerName.Text.ToString(), fUserName.Text.ToString(), fUserPassword.Text.ToString()))
                return;
            // отключаем панель "соединение", включаем панель "сравнение"
            fPanelConnect.Enabled = false;
            fPanelCompare.Enabled = true;
            // получаем список список контейнеров Update'ов
            Containers = new List<UpdateContainerClass>();
            Containers.AddRange(Sccm.GetAllUpdateLists());
            Containers.AddRange(Sccm.GetAllDeployments());
            // отображаем список на форме
            fObject1.Items.Clear();
            fObject2.Items.Clear();
            foreach (UpdateContainerClass Container in Containers)
            {
                fObject1.Items.Add(Container.DisplayName);
                fObject2.Items.Add(Container.DisplayName);
            }
            if (fObject1.Items.Count > 0)
                fObject1.SelectedIndex = 0;
            if (fObject2.Items.Count > 0)
                fObject2.SelectedIndex = 0;
        }
        //-------------------------------------------------------

        // нажатие на кнопку "сравнить"
        private void fCompare_Click(object sender, EventArgs e)
        {
            // проверяем, выбраны ли контейнеры для сравнения
            if ((fObject1.SelectedIndex < 0) || (fObject2.SelectedIndex < 0))
            {
                MessageBox.Show("Не выбраны объекты для сравнения!");
                return;
            }
            // отключаем панель "сравнение"
            fPanelCompare.Enabled = false;
            // уведомляем о начале сравнения
            MessageBox.Show("Сравнение начато. Нажмите ОК и дождитесь результатов.");
            // получаем время начала сравнения
            DateTime Begin = DateTime.Now;
            // получаем списки ID Update'ов из контейнеров
            List<int> UpdateIds1 = Sccm.GetUpdateIds(Containers[fObject1.SelectedIndex].Type, Containers[fObject1.SelectedIndex].Id);
            List<int> UpdateIds2 = Sccm.GetUpdateIds(Containers[fObject2.SelectedIndex].Type, Containers[fObject2.SelectedIndex].Id);
            // сравниваем списки ID, находим недостающие в первом контейнере
            List<int> MissIds1 = Sccm.CompareUpdateIds(UpdateIds1, UpdateIds2);
            // формируем сведения о ходе сравнения
            string Res = "Сравнивались:\n" +
                         Containers[fObject1.SelectedIndex].Name + " (" + UpdateIds1.Count.ToString() + ") c " +
                         Containers[fObject2.SelectedIndex].Name + " (" + UpdateIds2.Count.ToString() + ")\n\n" +
                         Containers[fObject1.SelectedIndex].Name + ": не хватает " + MissIds1.Count.ToString() + " обновлений";
            // создаем новый UpdateList с недостающими в первом контейнере обновлениями
            if (fCreateNewList.Checked)
            {
                string NewListName = Containers[fObject1.SelectedIndex].Name + " # " + Containers[fObject2.SelectedIndex].Name;
                if (Sccm.CreateUpdateList(NewListName, MissIds1.ToArray()))
                    Res += "\nСоздан новый UpdateList: " + NewListName;
            }
            // получаем время конца сравнения
            DateTime End = DateTime.Now;
            Res += "\n\n Время сравнения: " + (End - Begin).Seconds.ToString() + " сек.";
            // показываем результат сравнения
            MessageBox.Show(Res);
            // включаем панель "сравнение"
            fPanelCompare.Enabled = true;
        }
        //-------------------------------------------------------
    }
}