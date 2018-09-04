using System;

namespace HVCC
{
    internal class Person
    {
        private String relations;
        private String firstName;
        private String imageFile;
        private String lastName;

        public String Relations
        {
            get { return relations; }
            set { relations = value; }
        }

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public String ImageFile
        {
            get { return imageFile; }
            set { imageFile = value; }
        }

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public Person(String firstName, String lastName, String relations)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.relations = relations;
            imageFile = "../images/" + firstName + ".png";
        }
    }
}