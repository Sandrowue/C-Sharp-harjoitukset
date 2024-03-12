using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Libraries for serialization
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialisointi
{
    [Serializable]
    public class Student
    {
        // Fields
        string firstName;
        string lastName;
        string dateOfBirth;
        int startYear;
        string studyArea;

        // Properties
        public string FirstName 
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string DateOfBirth {
            get { return dateOfBirth; }
            set {  dateOfBirth = value; }
                }
        public int StartYear
        {
            get { return startYear; }
            set { startYear = value; }
        }
        public string StudyArea
        {
            get { return studyArea; }
            set { studyArea = value; }

        }

        // Constructors

        // Default constructor
        
        public Student() 
        {
            this.FirstName = "Sandro";
            this.LastName = "Wüthrich";
            this.dateOfBirth = "1978-10-04";
            this.startYear = 2023;
            this.studyArea = "Ohjelmistokehittäjä";
        }

        // Constructor with all arguments
        public Student(string firstName, string lastName, string dateOfBirth,
            int startYear, string studyArea)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.startYear = startYear;
            this.studyArea = studyArea;
        }
        
        // Methods 

        public void StudentInfo()
        {
            Console.WriteLine("OPISKELIJAN TIEDOT");
            Console.WriteLine("------------------");
            Console.WriteLine("Etunimi: " + this.firstName);
            Console.WriteLine("Sukunimi: " + this.lastName);
            Console.WriteLine("Opintojen ala: " + this.studyArea);
            Console.WriteLine("Syntymäaika: " + this.dateOfBirth);
            Console.WriteLine("Opintojen aloitusvuosi: " + this.startYear);
        }

        static void Main()
        {
            // Create an array of Student objects
            Student[] students = new Student[3];
            students[0] = new Student("Josse", "Kesto", "1986-03-13", 2022, "IT-tkukihenkilö");
            students[1] = new Student("Kaila", "Hanuri", "1976-05-29", 2021, "Puutaideartesaani");
            students[2] = new Student("Hans", "Popp", "1968-10-11", 2024, "Inernet vaikuttaja");
            // Create a binary formatter
            IFormatter formatter = new BinaryFormatter();

            // Create a stream for writting to the file
            Stream writeStream = new FileStream("StudentData.dat", FileMode.Create, FileAccess.Write);

            // Serialize to the file
            formatter.Serialize(writeStream, students);

            // Close the stream when finished serializing
            writeStream.Close();

            // Create a stream for reading data from the file
            Stream readStream = new FileStream("StudentData.dat", FileMode.Open, FileAccess.Read);

            // Create an array to store student data
            Student[] studentsFromDisk;

            // Deserialize from the file 
            studentsFromDisk = (Student[])formatter.Deserialize(readStream);

            // Close the file after read operation
            readStream.Close();

            // Show all data in a loop
            foreach (var item in studentsFromDisk)
            {
                item.StudentInfo();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
