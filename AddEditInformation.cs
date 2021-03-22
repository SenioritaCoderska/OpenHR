using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace OpenHR
{
    public partial class AddEditInformation : Form
    {//Activate file helper to WritetToAndReadFrom_JSON_file
        private FileHelper<List<Information>> _fileHelper = new FileHelper<List<Information>>(Program.filePath);
        //Assign main employee list
        private Information _information;
        //
        private int _employeeId = 0;
        private bool _error = false;
        //int id =0 then list empty, actionType d=dismiss, a=add, e=edit
        public AddEditInformation(int id = 0, string actionType = "d")
        {
            //Assign Id
            _employeeId = id;
            //Create form components
            InitializeComponent();
            //Take action
            TakeAnAction(actionType);
        }
        #region events
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Clear Application Log
            rtbLogAddEdit.Clear();
            //get Informations about the employee
            GetInformations();
        }
        #endregion
        #region validation
        private string TextValidation(string input, string caseToValidate)
        {
            //Validate text fields
            switch (caseToValidate)
            {
                case "Street":
                    if (!Regex.Match(input, @"([a-zA-Z]+\s\d{1,3})$").Success)
                    {
                        throw new Exception("Invalid street name. Please provide correct one!");
                    }
                    else
                    {
                        return input;
                    }
                case "City":
                    if (!Regex.Match(input, @"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$").Success)
                    {
                        throw new Exception("Invalid city name. Please provide correct one!");
                    }
                    else
                    {
                        return input;
                    }
                case "ZipCode":
                    if (!Regex.Match(input, @"\d{2}-\d{3}").Success)
                    {
                        throw new Exception("Invalid Zip Code. Please provide correct one __-___!");
                    }
                    else
                    {
                        return input;
                    }
                default:
                    return input;
            }
        }
        private DateTime ConvertToDate(string stringToConvert)
        {
            //validate date input
            DateTime date = DateTime.Now;
            if (Regex.Match(stringToConvert, @"^([0-2][0-9]|(3)[0-1])(\/|.|-)(((0)[0-9])|((1)[0-2]))(\/|.|-)\d{2,4}$").Success)
            {
                if ((stringToConvert != null) && (!DateTime.TryParse(stringToConvert, out date)))
                {
                    if (date != default)
                        throw new Exception("Incorrect date! Please provide correct date format.");
                }
            }
            else
            {
                throw new Exception("Incorrect date! Please provide correct date format.");
            }
            return date;
        }
        private int ConvertToInt(string stringToConvert)
        {
            //validate integer for salary
            int integer = 0;
            if ((stringToConvert != null) && (!int.TryParse(stringToConvert, out integer)))
            {
                throw new Exception($"Incorrect Salary! Please provide salary as a number {Environment.NewLine}");
            }
            return integer;
        }
        #endregion
        #region takeAction
        private void TakeAnAction(string actionType)
        {
            //If action type dismiss
            if (actionType == "d")
            {
                //fill up form based on selected ID
                var employee = _fileHelper.DeserializedFromFile();
                _information = employee.FirstOrDefault(x => x.Id == _employeeId);
                FillUpForm();
                //make all other controls read only, stay only with dismissOn for edition
                foreach (var element in Controls)
                {
                    if (element != tbDismissedOn && element.GetType() == typeof(TextBox))
                    {
                        TextBox tb = element as TextBox;
                        tb.ReadOnly = true;
                    }
                }
                //Log to application log
                rtbLogAddEdit.AppendText($"Information {DateTime.Now.ToString()}: Please provide the date of dismissing the employee { Environment.NewLine}");
            }
            else
            {
                //if actionType a or e then check if it is edition or adding new
                if (_employeeId != 0)
                {
                    //if edition display existing record
                    var employee = _fileHelper.DeserializedFromFile();
                    _information = employee.FirstOrDefault(x => x.Id == _employeeId);
                    if (_information == null)
                        rtbLogAddEdit.AppendText($"Error message from {DateTime.Now.ToString()}: No employee exists under provided Id { Environment.NewLine}");
                    FillUpForm();
                }
            }
        }
        private void FillUpForm()
        {
            //fill up form fields
            tbId.Text = _information.Id.ToString();
            tbFirstName.Text = _information.FirstName;
            tbLastName.Text = _information.LastName;
            tbWorkFrom.Text = _information.WorkFrom.ToString("d");
            tbDismissedOn.Text = _information.DismissedOn?.ToString("d");
            tbStreet.Text = _information.Street;
            tbCity.Text = _information.City;
            tbZipCode.Text = _information.ZipCode;
            tbSalary.Text = _information.Salary.ToString();
            rtbRemarks.Text = _information.Remarks;
        }
        private void GetInformations()
        {
            _error = false;
            List<Information> employees = new List<Information>();
            try
            {
                employees = _fileHelper.DeserializedFromFile();
            }
            catch
            {
                rtbLogAddEdit.AppendText($"Error message from {DateTime.Now.ToString()}: " +
                $"No records available {Environment.NewLine}. Please add new one");
            }
            //If employee exists
            if (!String.IsNullOrEmpty(tbId.Text))
            {
                UpdateExistingUser(employees);
            }
            else // if employee needs to be added
            {
                AddNewEmployee(employees);
            }
            //if error occured while adding, editing the record then do not serialize, wait for corrections
            if (!_error)
            {
                _fileHelper.SerializeToFile(employees);
                Close();
            }
        }
        private void AddNewEmployee(List<Information> employees)
        {
            //Read max ID for new employee
            AssignIdToNewEmployee(employees);
            try
            {
                _information = new Information()
                {
                    Id = _employeeId,
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    WorkFrom = ConvertToDate(tbWorkFrom.Text),
                    DismissedOn = ConvertToDate(tbDismissedOn.Text),
                    Street = TextValidation(tbStreet.Text, "Street"),
                    City = TextValidation(tbCity.Text, "City"),
                    ZipCode = TextValidation(tbZipCode.Text, "ZipCode"),
                    Salary = ConvertToInt(tbSalary.Text),
                    Remarks = rtbRemarks.Text
                };
                employees.Add(_information);
            }
            catch (Exception ex)
            {
                rtbLogAddEdit.AppendText($"Error message from {DateTime.Now.ToString()}: " +
                ex.Message);
                _error = true;
            }
        }
        private void AssignIdToNewEmployee(List<Information> employee)
        {
            var employeeWithHighestId = employee
            .OrderByDescending(x => x.Id).FirstOrDefault();
            _employeeId = employeeWithHighestId == null ?
            1 : employeeWithHighestId.Id + 1;
        }
        private void UpdateExistingUser(List<Information> employees)
        {
            try
            {
                Information selectEmployeeBasedOnId = employees
                .OrderByDescending(x => x.Id == _employeeId).FirstOrDefault();
                selectEmployeeBasedOnId.Id = _employeeId;
                selectEmployeeBasedOnId.FirstName = tbFirstName.Text;
                selectEmployeeBasedOnId.LastName = tbLastName.Text;
                selectEmployeeBasedOnId.WorkFrom = ConvertToDate(tbWorkFrom.Text);
                selectEmployeeBasedOnId.Street = TextValidation(tbStreet.Text, "Street");
                selectEmployeeBasedOnId.City = TextValidation(tbCity.Text, "City");
                selectEmployeeBasedOnId.ZipCode = TextValidation(tbZipCode.Text, "ZipCode");
                selectEmployeeBasedOnId.Salary = ConvertToInt(tbSalary.Text);
                selectEmployeeBasedOnId.Remarks = rtbRemarks.Text;
            }
            catch (Exception ex)
            {
                rtbLogAddEdit.AppendText($"Error message from {DateTime.Now.ToString()}: " +
                ex.Message);
                _error = true;
            }
        }
        #endregion
    }
}