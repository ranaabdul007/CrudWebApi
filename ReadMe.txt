
Please Include following steps to configure CRUD application on your local server.



Step 1:
 Replace your connection string with 


"ConnectionStrings": {
    "ConEmp": "Server=DESKTOP-UI66116\\SQLEXPRESS; Database=ReactAppDb;Trusted_Connection=True"
  }, 

Step 2:

I'm using code first approach to build crud API.So, Please execute following command in Package Manager Console to create data base. 


1- add-migration init

2- update-database

Step 3:

run both react and web api project.

visual studio 2022
1 - Clean Solution
2 - Rebuild Solution

VS Code

npm run build
npm start

add your react app url in the program.cs file of CrudWebApi Project .

-------------------------

npm install axios
npm install react-bootstrap bootstrap
npm install react-toastify
npm install @fortawesome/react-fontawesome @fortawesome/free-solid-svg-icons
npm install @fortawesome/fontawesome-svg-core
npm install react react-dom
