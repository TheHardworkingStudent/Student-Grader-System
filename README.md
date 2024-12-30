![Screenshot 2024-12-30 150329](https://github.com/user-attachments/assets/a158044f-9a0d-4090-9678-d3e72e2ec0b7)
# Student Assignment Score Tracker
Description

The Student Assignment Score Tracker is a Windows Forms (or WPF) application designed to input, display, and manage students' assignment scores. This program leverages arrays to store both student information (single-dimensional array) and assignment scores (multi-dimensional array) efficiently. The application ensures user-friendly interaction by validating inputs, providing error labels for invalid inputs, and preventing common program crashes.

This project was created as an assignment for a class, focusing on the use of arrays, input validation, and UI interaction in a Windows Forms or WPF application.
Features

    Input Management
        Allows the user to specify the number of students (1–10) and the number of assignments (1–99).
        Validates input with error labels for invalid entries (e.g., out-of-range numbers or non-numeric values).
        Defaults student names to Student #1, Student #2, ..., Student #N and all assignment scores to 0.

    Student Navigation and Editing
        Enables navigation between students to view or edit their information.
        Updates and saves student names using a "Save Name" button.

    Assignment Score Management
        Allows entering and saving individual assignment scores for each student using the "Save Score" button.
        Dynamically updates labels (e.g., Enter Assignment Number (1-X)) based on the number of assignments.

    Score Display
        Displays all students, their grades, their average score, and their corresponding letter grade based on the syllabus grading scale.
        Utilizes tab and newline formatting for organized display.

    Program Reset
        Resets the application to its initial state (i.e., inputting counts) using a "Reset Scores" button.

    Error Handling
        Prevents crashes by:
            Validating input for the number of students and assignments.
            Validating assignment numbers and scores.
            Preventing navigation beyond array bounds.
        Ensures smooth operation with error labels instead of message boxes for invalid input.

    XML Documentation
        All classes, attributes, and methods include XML comments to provide clear documentation for developers.

How to Use

    Set Counts:
        Enter the number of students (1–10) and the number of assignments (1–99).
        Submit the counts.

    Edit Students and Scores:
        Navigate between students to view their information.
        Update student names and save them using the "Save Name" button.
        Enter an assignment number and score (0–100) and save the score using the "Save Score" button.

    Display Grades:
        Click the "Display Scores" button to view a table of students with their grades, averages, and letter grades.

    Reset:
        Click the "Reset Scores" button to return the application to its default state.

Requirements

    Environment: Windows Forms or WPF application
    Development Tools: Visual Studio (or equivalent)
    Languages and Frameworks: C# and .NET Framework (or .NET Core/5+ for WPF)

Error Handling

    All invalid inputs are handled with error labels displayed near the respective input fields.
    Prevents user actions on the bottom half of the form (e.g., navigating students, saving scores) until the counts are submitted.

Common Issues Addressed

    Ensured student names default to Student #1, Student #2, ..., not Student #0.

    Validated navigation within the bounds of the student and assignment arrays.
    Properly formatted the display of grades, averages, and letter grades.
    XML comments provided for all classes, attributes, and methods.

Future Improvements

    Enhance formatting of the score display to handle long student names more gracefully.
    Add additional user feedback or tooltips for a better user experience.
    Expand functionality to export scores to a file (e.g., CSV or text).

License

This project is created as part of an academic assignment and may not be used for commercial purposes without prior permission.
Screenshots

(Add screenshots of the application here if available.)
Author

Developed by [Your Name] as part of a class assignment on Windows Forms/WPF programming.
