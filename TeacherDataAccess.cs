using System;
using System.Collections.Generic;
using System.IO;


namespace TeacherRecordSystemAssesmentofSL
{
    public class TeacherDataAccess
    {
        private const string filePath = "C:\\Users\\basan\\OneDrive\\Desktop\\Training\\Day1\\TeacherRecordSystemAssesmentofSL\\TeacherRecordSystemAssesmentofSL\\teachers.csv"; // Update the file path as needed

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    int id = int.Parse(data[0]);
                    string name = data[1];
                    string classAndSection = data[2];

                    Teacher teacher = new Teacher
                    {
                        ID = id,
                        Name = name,
                        ClassAndSection = classAndSection
                    };

                    teachers.Add(teacher);
                }
            }

            return teachers;
        }

        public void AddTeacher(Teacher teacher)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                string line = $"{teacher.ID},{teacher.Name},{teacher.ClassAndSection}";
                sw.WriteLine(line);
            }
        }

        public void UpdateTeacher(Teacher updatedTeacher)
        {
            List<Teacher> teachers = GetAllTeachers();
            int index = teachers.FindIndex(t => t.ID == updatedTeacher.ID);
            if (index >= 0)
            {
                teachers[index] = updatedTeacher;
                SaveTeachersToFile(teachers);
            }
        }

        private void SaveTeachersToFile(List<Teacher> teachers)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (Teacher teacher in teachers)
                {
                    string line = $"{teacher.ID},{teacher.Name},{teacher.ClassAndSection}";
                    sw.WriteLine(line);
                }
            }
        }
    }
}

