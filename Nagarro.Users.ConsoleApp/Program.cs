using Nagarro.Users.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Users.ConsoleApp
{
    class Program
    {
        static IUserBDC userBDC = FactoryBase.CreateBDCInstance<IUserBDC>();
        static IUserDTO userDTO = FactoryBase.CreateDTOInstance<IUserDTO>();

        static void Main(string[] args)
        {
            char ifContinue;
            do
            {
                Console.WriteLine("\n***********************NEW OPERATION*************************\n");
                Console.WriteLine("1. Get all Users.");
                Console.WriteLine("2. Get an User.");
                Console.WriteLine("3. Insert an User.");
                Console.WriteLine("4. update an User.");
                Console.WriteLine("5. Delete an User.");
                Console.Write("\nPlease select one of the above option: ");

                // Functions called in below cases are in this class only (after main function)
                switch (Console.ReadLine()[0])
                {
                    case '1':
                        GetAllUsers();
                        break;
                    case '2':
                        GetAUser();
                        break;
                    case '3':
                        InsertUser();
                        break;
                    case '4':
                        UpdateUser();
                        break;
                    case '5':
                        DeleteUser();
                        break;
                    default:
                        Console.WriteLine("Please select a valid input!");
                        break;
                }

                Console.WriteLine("\n***********************OPERATION OVER*************************\n");
                Console.Write("\nDo you wish to continue? y/n: ");
                ifContinue = Console.ReadLine()[0];                
            }
            while (ifContinue == 'y' || ifContinue == 'Y');
         
        }
        // Main function ended

        //static functions definitions
        private static void GetAllUsers()
        {
            List<IUserDTO> usersDTO = new List<IUserDTO>();
            usersDTO = userBDC.GetAllUsers();
            PrintJSONifiedUsersDTO(usersDTO);
        }

        private static void GetAUser()
        {
            Console.Write("Please enter the User ID: ");
            int id = int.Parse(Console.ReadLine());
            IUserDTO retrievedUserDTO = FactoryBase.CreateDTOInstance<IUserDTO>();
            retrievedUserDTO = userBDC.GetAUser(id);
            PrintJSONifyUserDTO(retrievedUserDTO);
        }

        private static void InsertUser()
        {
            Console.Write("\nEnter User ID: ");
            userDTO.UserId = int.Parse(Console.ReadLine());
            Console.Write("Enter User Name: ");
            userDTO.Name = Console.ReadLine();
            Console.Write("Enter User Age: ");
            userDTO.Age = int.Parse(Console.ReadLine());
            Console.Write("Enter User Gender: ");
            userDTO.Gender = Console.ReadLine();

            int retrievedId = userBDC.InsertUser(userDTO);
            Console.WriteLine("User successfully inserted with ID: {0}", retrievedId);
            IUserDTO retrievedUserDTO = userBDC.GetAUser(retrievedId);
            PrintJSONifyUserDTO(retrievedUserDTO);
        }

        private static void UpdateUser()
        {
            Console.Write("\nEnter User ID: ");
            userDTO.UserId = int.Parse(Console.ReadLine());
            Console.Write("\nEnter User Name : ");
            userDTO.Name = Console.ReadLine();
            Console.Write("\nEnter User Age: ");
            string age = Console.ReadLine();
            if (age != "" && age.Trim() != "")
            {
                userDTO.Age = int.Parse(age);
            }
            else
            {
                userDTO.Age = -1;
            }
            Console.Write("\nEnter User Gender: ");
            userDTO.Gender = Console.ReadLine();

            if (userBDC.UpdateUser(userDTO))
            {
                Console.WriteLine("User successfully updated with ID: {0}", userDTO.UserId);
                IUserDTO retrievedUserDTO =  userBDC.GetAUser(userDTO.UserId);
                PrintJSONifyUserDTO(retrievedUserDTO);
            }
            else
            {
                Console.WriteLine("Operation could not be successful. Please try again.");
            }
        }

        private static void DeleteUser()
        {
            Console.Write("Please enter the User ID: ");
            int deleteId = int.Parse(Console.ReadLine());
            if (userBDC.DeleteUser(deleteId))
            {
                Console.WriteLine("User with Id: {0} has been successfully deleted.", deleteId);
            }
            else
            {
                Console.WriteLine("User with Id: {0} could not be deleted. Please try again.", deleteId);
            }
        }

        private static void PrintJSONifyUserDTO(IUserDTO userDTO)
        {
            Console.WriteLine("\t{");
            Console.WriteLine("\t\tUserID: {0},", userDTO.UserId);
            Console.WriteLine("\t\tName: {0},", userDTO.Name);
            Console.WriteLine("\t\tAge: {0},", userDTO.Age);
            Console.WriteLine("\t\tGender: {0}", userDTO.Gender);
            Console.WriteLine("\t}");
        }

        private static void PrintJSONifiedUsersDTO(List<IUserDTO> usersDTO){
            Console.WriteLine("\t{");
            foreach (IUserDTO user in usersDTO)
            {
                Console.WriteLine("\t\t{");
                Console.WriteLine("\t\t\tUserID: {0},", user.UserId);
                Console.WriteLine("\t\t\tName: {0},", user.Name);
                Console.WriteLine("\t\t\tAge: {0},", user.Age);
                Console.WriteLine("\t\t\tGender: {0}", user.Gender);

                if (!user.Equals(usersDTO.Last()))
                {
                    Console.WriteLine("\t\t},");
                }
                else
                {
                    Console.WriteLine("\t\t}");
                }

            }
            Console.WriteLine("\t}");
        }
    }
}
