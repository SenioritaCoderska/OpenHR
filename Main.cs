using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace OpenHR
{
    public partial class Main : Form
    {
        //Activate file helper to WritetToAndReadFrom_JSON_file
        private FileHelper<List<Information>> _fileHelper = new FileHelper<List<Information>>(Program.filePath);
        //Assign main employee list
        private List<Information> _informations = new List<Information>();

        public Main()
        {
            //Create Form with all components
            InitializeComponent();
            //Create Form read from file all stored input
            RefreshDataGridView();
            //Set Headers
            SetDataGridViewHeaders();
            //Initialize filters base on available data
            InitializeFilters();
        }
        #region FormViewMain
        private void RefreshDataGridView()
        {
            try
            {
                //Read data to grid
                _informations = _fileHelper.DeserializedFromFile();
                dgvHrInfo.DataSource = _informations;
                //set form default figures
                tbLastName.Text = null;
                cmbCity.SelectedItem = default;
                cbDismissed.Checked = default;
                cbHired.Checked = default;
            }
            catch (Exception ex)
            {
                //if JSON file empty then:
                rtbLogMain.AppendText($"Error message from {DateTime.Now.ToString()}: " +
                $"No records available {Environment.NewLine}. Please add new one");
            }
        }
        private void SetDataGridViewHeaders()
        {
            try
            {
                dgvHrInfo.Columns[0].HeaderText = "Employee Id";
                dgvHrInfo.Columns[1].HeaderText = "First Name";
                dgvHrInfo.Columns[2].HeaderText = "Last Name";
                dgvHrInfo.Columns[3].HeaderText = "Work From";
                dgvHrInfo.Columns[4].HeaderText = "Dismissed On";
                dgvHrInfo.Columns[5].HeaderText = "Street";
                dgvHrInfo.Columns[6].HeaderText = "City";
                dgvHrInfo.Columns[7].HeaderText = "Zip Code";
                dgvHrInfo.Columns[8].HeaderText = "Salary";
                dgvHrInfo.Columns[9].HeaderText = "Remarks";
            }
            catch (Exception ex)
            {
                //If JSON file contains different number of columns, and headers cannot be named then:
                rtbLogMain.AppendText($"Error message from {DateTime.Now.ToString()}: {ex.Message} {Environment.NewLine}");
            }
        }
        private void InitializeFilters()
        {
            //Initialize filters vased on full available data
            var cities = _informations.GroupBy(x => x.City).Select(cities => cities.Key).ToArray();
            cmbCity.Items.AddRange(cities);
        }
        private void InitializeFilters(List<Information> information)
        {
            //Initialize filters vased on selection (dismissed - hired)
            var cities = information.GroupBy(x => x.City).Select(cities => cities.Key).ToArray();
            cmbCity.Items.Clear();
            cmbCity.Items.AddRange(cities);
        }
       
        #endregion

        #region events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            rtbLogMain.Clear();
            var addEditInformation = new AddEditInformation(0, "a");
            addEditInformation.FormClosing += AddEditInformation_FormClosing;
            addEditInformation.ShowDialog();
            addEditInformation.FormClosing -= AddEditInformation_FormClosing;
        }
        private void AddEditInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefreshDataGridView();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            rtbLogMain.Clear();
            RefreshDataGridView();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            rtbLogMain.Clear();
            if (dgvHrInfo.SelectedRows.Count == 0)
            {
                rtbLogMain.AppendText($"Error message from {DateTime.Now.ToString()}: " +
                $"Please select the employee you want to edit {Environment.NewLine}");
                return;
            }
            var addEditInformation = new AddEditInformation((Convert.ToInt32(dgvHrInfo.SelectedRows[0].Cells["Id"].Value)), "e");
            addEditInformation.FormClosing += AddEditInformation_FormClosing;
            addEditInformation.ShowDialog();
            addEditInformation.FormClosing -= AddEditInformation_FormClosing;
        }
        private void btnDismiss_Click(object sender, EventArgs e)
        {
            rtbLogMain.Clear();
            if (dgvHrInfo.SelectedRows.Count == 0)
            {
                rtbLogMain.AppendText($"Error message from {DateTime.Now.ToString()}: " +
                $"Please select the employee you want to dismiss {Environment.NewLine}");
                return;
            }
            //Opens AddEdit form with all fields locked except dismiss date
            var addEditInformation = new AddEditInformation((Convert.ToInt32(dgvHrInfo.SelectedRows[0].Cells["Id"].Value)));
            addEditInformation.FormClosing += AddEditInformation_FormClosing;
            addEditInformation.ShowDialog();
            addEditInformation.FormClosing -= AddEditInformation_FormClosing;
        }
        private void tbLastName_TextChanged(object sender, EventArgs e)
        {
            //Filter for last name
            rtbLogMain.Clear();
            TextBox textBox = sender as TextBox;
            string text = textBox.Text.ToLower();
            AssigneFromFilter(text, "lastname");
        }
        private bool _cbHiredChecked;
        private void cbDismissed_CheckedChanged(object sender, EventArgs e)
        {
            //Filter for dismissed
            if (_cbDismissedChecked)
            {
                _cbDismissedChecked = false;
            }
            else
            {
                CheckBox checkBox = sender as CheckBox;
                if (checkBox.Checked)
                { 
                    AssigneFromFilter("", "dismissed");
                }
                else
                {
                    RefreshDataGridView();
                }
                if (cbHired!=null && cbHired.Checked)
                {
                    _cbHiredChecked = true;
                    cbHired.Checked = false;
                }
            }
        }
        private bool _cbDismissedChecked;
        private void cbHired_CheckedChanged(object sender, EventArgs e)
        {
            //Filter for hired
            if (_cbHiredChecked)
            {
                _cbHiredChecked = false;
            }
            else
            {
                CheckBox checkBox = sender as CheckBox;
                if (checkBox.Checked)
                {
                    AssigneFromFilter("", "hired");
                }
                else
                {
                    RefreshDataGridView();
                }
                if (cbDismissed!= null && cbDismissed.Checked)
                {
                    _cbDismissedChecked = true;
                    cbDismissed.Checked = false;
                }

            }
        }
        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            //filter for the cities
            ComboBox comboBox = sender as ComboBox;
            AssigneFromFilter(comboBox.Text, "city");
        }
        #endregion

        //Void to chose proper filtering
        private void AssigneFromFilter(string input, string inpupType)
        {
            List<Information> information = new List<Information>();
            try
            {
                switch (inpupType)
                {
                    case "lastname":
                        information = _informations.Where(x => (x.LastName.ToLower().Contains(input))).ToList();
                        break;
                    case "dismissed":
                        information = _informations.Where(x => x.DismissedOn != default(DateTime)).ToList();
                        break;
                    case "hired":
                        information = _informations.Where(x => x.DismissedOn == default(DateTime)).ToList();
                        break;
                    case "city":
                        information = _informations.Where(x => (x.City.Contains(input))).ToList();
                        break;
                }

                InitializeFilters(information);
            }
            catch
            {
                rtbLogMain.AppendText($"Error message from {DateTime.Now.ToString()}: " +
                $"Selected record does not exists {Environment.NewLine}");
            }
            if (information != null)
            {
                dgvHrInfo.DataSource = null;
                dgvHrInfo.DataSource = information;
            }
            else
            {
                rtbLogMain.AppendText($"Error message from {DateTime.Now.ToString()}: " +
                $"Selected record does not exists {Environment.NewLine}");
            }
        }

    }
}