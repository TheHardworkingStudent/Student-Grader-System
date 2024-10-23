using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment3
{
    /// <summary>
    /// Main application logic
    /// </summary>
    public partial class MainWindow : Window
    {   
        /// <summary>
        /// Number of students
        /// </summary>
        int number_of_students = 0;

        /// <summary>
        /// Number of assignments
        /// </summary>
        int number_of_assignments = 0;

        /// <summary>
        /// Student who is selected
        /// </summary>
        int selected_student = 0;

        /// <summary>
        /// Assignment that is selected
        /// </summary>
        int selected_assignment = 0;

        /// <summary>
        /// Maximum number of students
        /// </summary>
        int MAX_STUDENTS = 10;

        /// <summary>
        /// Maximum number of assignments.
        /// </summary>
        int MAX_ASSIGNMENTS = 99;

        /// <summary>
        /// Boolean for keep track if number of students and number of assignments has been assigned.
        /// </summary>
        bool assigned = false;

        /// <summary>
        /// Array that keeps track of student names.
        /// </summary>
        string[]? student_name;

        /// <summary>
        /// Keeps track of the assignment scores of students, first index is student, second index is the assignment of that student.
        /// </summary>
        double[,]? assignment_scores;
        /// <summary>
        /// Constructor for program
        /// </summary>
        public MainWindow()
        {
            InitalizeValues();
            InitializeComponent();
        }
        /// <summary>
        /// Will set the values of the arrays to 0 and allocate memory for the arrays.
        /// </summary>
        void InitalizeValues()
        {
            student_name = new string[MAX_STUDENTS];
            assignment_scores = new double[MAX_STUDENTS, MAX_ASSIGNMENTS];
            for(int i = 0; i < MAX_STUDENTS; i++)
            {
                for(int j = 0; j < MAX_ASSIGNMENTS; j++)
                {
                    assignment_scores[i,j] = 0;
                }
            }
            for(int i = 0; i < MAX_STUDENTS; i++)
            {
                student_name[i] = "Student#" + (i + 1).ToString();
            }
        }
        /// <summary>
        /// This button submits the counts of the number of students and number of assignments.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit_Counts_Button(object sender, RoutedEventArgs e)
        {
            // Checks user input and sees if it is a number
            if(Int32.TryParse(StudentCountTextbox.Text, out number_of_students) == true && Int32.TryParse(AssignmentCountTextbox.Text, out number_of_assignments) == true)
            {
                //makes sure the range is valid
                if(number_of_students > 0 && number_of_students <=10 && number_of_assignments > 0 && number_of_assignments < 100)
                {
                    //fixs error messages if input is correct
                    SubmitCountsButton.Content = "Submit";
                    StudentCountLabel.Content = "Number of Students:";
                    AssignmentCountLabel.Content = "Number of Assigments:";
                    AssignmentIndexLabel.Content = "Enter Assignment Number (1-"+number_of_assignments.ToString()+"):";
                    assigned = true;
                }
                else
                {
                    StudentCountLabel.Content = "Must be between 1 and 10 students";
                    AssignmentCountLabel.Content = "Must be between between\n1 and 99 assignments";
                }
            }
            else
            {
                SubmitCountsButton.Content = "Error! Enter Number!";
            }
        }
        /// <summary>
        /// Saves the score when given assignment number of assignment score.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Score_Button(object sender, RoutedEventArgs e)
        {
            // assignment_number_textbox and assignment_score_textbox store the result of the parse for later use
            bool assignment_number_textbox = false;
            bool assignment_score_textbox = false;
            assignment_number_textbox = Int32.TryParse(AssignmentIndexTextBox.Text, out selected_assignment);
            // user inputs one but is actually index 0 behind the scenes
            selected_assignment = selected_assignment - 1;
            if (assigned == true && selected_assignment >=0)
            {
                assignment_score_textbox = Double.TryParse(AssignmentScoreTextBox.Text, out assignment_scores[selected_student, selected_assignment]);
                // checks to see if the input turned out to be numbers or are valid
                if (assignment_number_textbox == true && assignment_score_textbox == true)
                {
                    // check to see if the numbers are in a valid range
                    if(selected_assignment >= 0 && selected_assignment < number_of_assignments && assignment_scores[selected_student, selected_assignment] >= 0 && assignment_scores[selected_student, selected_assignment] <= 100)
                    {
                        SaveScoreButton.Content = "Save Score";
                    }
                    else
                    {
                        SaveScoreButton.Content = "Please enter a valid\n range of numbers\nassignment score must be\nbetween 0 and 100";
                    }
                }
                else
                {
                    SaveScoreButton.Content = "Make sure the\ninput are numbers";
                }
            }
            else
            {
                SaveScoreButton.Content = "Error! You have not assigned\nthe number of students\nand assignments yet.\nOr there is invalid\ninput!";
            }
        }
        /// <summary>
        /// Previous student button. Decreases index by one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Previous_Student_Button(object sender, RoutedEventArgs e)
        {
            // decrement student index if student index > 0 and number of students and number of assignments are assigned
            if(selected_student > 0 && assigned==true)
            {
                selected_student--;
                SelectedStudentLabel.Content = "Student#" + (selected_student + 1).ToString() + ":";
            }
        }
        /// <summary>
        /// Jumps student index to the first one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void First_Student_Button(object sender, RoutedEventArgs e)
        {
            // checks to see if number of students and number of assignments are assigned
            if(assigned==true)
            {
                selected_student = 0;
                SelectedStudentLabel.Content = "Student#" + (selected_student + 1).ToString() + ":";
            }
        }
        /// <summary>
        /// Next student button. Increases index by one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Next_Student_Button(object sender, RoutedEventArgs e)
        {
            // checks to see if not at max and number of assignments and students have been assigned
            if(selected_student < number_of_students - 1 && assigned == true)
            {
                selected_student++;
                SelectedStudentLabel.Content = "Student#" + (selected_student + 1).ToString() + ":";
            }
        }
        /// <summary>
        /// Jumps to last student index.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Last_Student_Button(object sender, RoutedEventArgs e)
        {
            if(assigned == true)
            {
                selected_student = number_of_students - 1;
                SelectedStudentLabel.Content = "Student#" + (selected_student + 1).ToString() + ":";
            }
        }
        /// <summary>
        /// Save name button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Name_Button(object sender, RoutedEventArgs e)
        {
            // if number of assignments and students has been assigned, then save the student name.
            if(assigned == true)
            {
                student_name[selected_student] = SelectedStudentTextBox.Text;
            }

        }
        /// <summary>
        /// Display scores button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Display_Scores_Button(object sender, RoutedEventArgs e)
        {
            // prints table information to textbox
            string table = "STUDENT";
            double student_average_grade = 0;
            for(int i = 0; i < number_of_assignments; i++)
            {
                table = table + "    #" + (i + 1).ToString();
            }
            table = table + "    AVG    GRADE\n";
            for(int i = 0; i < number_of_students; i++)
            {
                table = table + student_name[i];
                for(int j = 0; j < number_of_assignments; j++)// $"{(arrPercentage[0] * 100):F2}%
                {
                    table = table + "    "+String.Format("{0:0.00}", assignment_scores[i, j]);
                }
                student_average_grade = Find_Average_For_Student(i);
                table = table + "    " + String.Format("{0:0.00}",(student_average_grade.ToString()));
                table = table + "    " + Find_Letter_Grade_For_Student(student_average_grade)+"\n";
            }

            TableTextBox.Text = table;
        }
        /// <summary>
        /// Finds average for the student given the student index.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        double Find_Average_For_Student(int i)
        {
            double sum = 0;
            for(int j = 0; j < number_of_assignments; j++)
            {
                sum = sum + assignment_scores[i, j];
            }
            return (sum/(double)number_of_assignments);
        }
        /// <summary>
        /// Series of if else statements for determining letter grade from student grade
        /// </summary>
        /// <param name="student_grade"></param>
        /// <returns></returns>
        string Find_Letter_Grade_For_Student(double student_grade)
        {
            if(student_grade >= 93)
            {
                return "A";
            }
            else if(student_grade >= 90)
            {
                return "A-";
            }
            else if(student_grade >= 87)
            {
                return "B+";
            }
            else if(student_grade >= 83)
            {
                return "B";
            }
            else if(student_grade >= 80)
            {
                return "B-";
            }
            else if(student_grade >= 77)
            {
                return "C+";
            }
            else if(student_grade >= 73)
            {
                return "C";
            }
            else if(student_grade >= 70)
            {
                return "C-";
            }
            else if(student_grade >= 67)
            {
                return "D+";
            }
            else if(student_grade >= 63)
            {
                return "D";
            }
            else if(student_grade >= 60)
            {
                return "D-";
            }
            return "E";
        }
        /// <summary>
        /// Resets all the values to the default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reset_Scores_Button(object sender, RoutedEventArgs e)
        {
            // sets array values to 0
            for (int i = 0; i < MAX_STUDENTS; i++)
            {
                for (int j = 0; j < MAX_ASSIGNMENTS; j++)
                {
                    assignment_scores[i, j] = 0;
                }
            }
            for (int i = 0; i < MAX_STUDENTS; i++)
            {
                student_name[i] = "";
            }
            // resets buttons and labels and other values.
            SubmitCountsButton.Content = "Submit";
            StudentCountLabel.Content = "Number of Students:";
            AssignmentCountLabel.Content = "Number of Assigments:";
            AssignmentIndexLabel.Content = "Enter Assignment Number (1-X):";
            SaveScoreButton.Content = "Save Score";
            TableTextBox.Text = "";
            number_of_students = 0;
            number_of_assignments = 0;
            selected_student = 0;
            selected_assignment = 0;
            assigned = false;

        }
    }
}