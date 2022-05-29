# excercise_api
### About
REST API built with dotnet core for an excercise application
### Implementations
✔ Docker for container support </br>
✔ NUnit for writing tests </br>
✔ ASP.NET Identity for Authentication & authorization </br>
✔ Azure SQL Server Database for persistence </br>


### Endpoints
☁ <s>Published to Azure @ http://wenzzzelexcerciseapi.northeurope.azurecontainer.io:5000/</s> </br>
#### Base
🧪 Test endpoint @ GET <s> http://wenzzzelexcerciseapi.northeurope.azurecontainer.io:5000/weatherforecast </s> </br>
🙍‍♂️ User registration @ POST <s> http://wenzzzelexcerciseapi.northeurope.azurecontainer.io:5000/AuthManagement/Register </s> </br>
🔑 User login @ POST <s> http://wenzzzelexcerciseapi.northeurope.azurecontainer.io:5000/AuthManagement/Login </s> </br>
🔁 Refresh token @ POST <s> http://wenzzzelexcerciseapi.northeurope.azurecontainer.io:5000/AuthManagement/RefreshToken </s> </br>
#### Excercise CRUD
🏃‍♂️ All Excercises @ GET <s> http://wenzzzelexcerciseapi.northeurope.azurecontainer.io:5000/Excercise </s> </br>
🏃‍♂️ Specific Excercise @ GET <s> http://wenzzzelexcerciseapi.northeurope.azurecontainer.io:5000/Excercise/{id} </s> </br>
🏃‍♂️ Create Excercise @ POST <s> http://wenzzzelexcerciseapi.northeurope.azurecontainer.io:5000/Excercise </s> </br>
🏃‍♂️ Delete Excercise @ DELETE <s> http://wenzzzelexcerciseapi.northeurope.azurecontainer.io:5000/Excercise/{id} </s> </br>
