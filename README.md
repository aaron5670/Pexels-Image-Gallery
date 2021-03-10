# Pexels Image Finder
This project was build as an assignment for the HAN University of Applied Sciences.
It features a WPF client and .NET Core server application.

## Features
- The server has a external API Connection with [Pexels](https://www.pexels.com/api/).
- WPF client with the MVVM pattern.
- Data binding (WPF)
- Continuous integration; Automatic deploy to Azure App Services.

### Continuous integration
When pushing to the Master branch, a new GitHub Actions pipeline will start.
This pipeline will deploy the new server features to Microsoft Azure App Services.

**Azure App Service production URL:** https://photo-library.azurewebsites.net/test
