Agri-Energy Connect - Bradley Bensch (ST10300512)
Module: PROG7311

This application enables farmers to connect with each other and with green energy technology providers. Its goal is to bridge the gap between the agricultural sector and green technology services.

GitHub Repository:
https://github.com/ST10300512/St10300512-AgriEnergy

Getting Started

1.) Clone or Download the Project

   Option 1: Clone from GitHub:
		https://github.com/ST10300512/St10300512-AgriEnergy.git

   Option 2: Extract the provided ZIP file with the complete solution.

2.)Open the Solution

   Open the project in Visual Studio 2022 (or later), or another compatible IDE supporting .NET 8.0.

3.)Attach the Database (AgriEnergyDB)

   The project uses a pre-created SQL Server LocalDB database (AgriEnergyDB.mdf).

   Included Database Files in App_Data:

   AgriEnergyDB.mdf

   AgriEnergyDB_log.ldf

Steps to Attach the Database using SQL Server Management Studio (SSMS):

   Open SQL Server Management Studio (SSMS).

   Connect to (localdb)\MSSQLLocalDB.

   Right-click Databases -> Attach...

   Click 'Add' -> Navigate to the provided .mdf file -> Select 'AgriEnergyDB.mdf'.

   Click OK to attach the database.

   Confirm that 'AgriEnergyDB' appears under Databases.

Update the Connection String if neccesary:

   Open appsettings.json in the project and confirm the connection string:

   "ConnectionStrings": {
   "DefaultConnection": "Server=(localdb)\MSSQLLocalDB;Database=AgriEnergyDB;Integrated Security=True;MultipleActiveResultSets=true"
   }

No changes should be necessary if using LocalDB with default configuration.

4.)Run the Application

   Press F5 in Visual Studio or use the terminal to run the project.

5.)Example Login Details

   Employee:

   Username: admin

   Password: password1

   Farmer:

   Username: farmer

   Password: password1