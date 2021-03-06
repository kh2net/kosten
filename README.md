
```
   _____ _          __  __      _     _           
  / ____| |        / _|/ _|    | |   | |          
 | (___ | | ____ _| |_| |_ ___ | | __| | ___ _ __ 
  \___ \| |/ / _` |  _|  _/ _ \| |/ _` |/ _ \ '__|
  ____) |   < (_| | | | || (_) | | (_| |  __/ |   
 |_____/|_|\_\__,_|_| |_| \___/|_|\__,_|\___|_| 


 __   __                          _       
 \ \ / /                         (_)      
  \ V / __ _ _ __ ___   __ _ _ __ _ _ __  
   > < / _` | '_ ` _ \ / _` | '__| | '_ \ 
  / . \ (_| | | | | | | (_| | |  | | | | |
 /_/ \_\__,_|_| |_| |_|\__,_|_|  |_|_| |_|
                                          
                                                                   
    
```
                                       

This project was generated by Skaffolder

For more documentation visit https://skaffolder.com/#/documentation


--------------
### START APPLICATION
--------------

To start the application open Visual Studio:

* On top bar menu: File -> Open -> Project/Solution
* Select `kosten.sln` into your project root folder

Login using:

username:   admin
password:   password

--------------
### CONFIGURE
--------------

Set properties in: `kosten/Properties.cs`

* The first time you start the app you have to update the NuGet Packages:
    * Right click on Solution `kosten`
    * Manage NuGet Packages for Solution...
    * Updates
    * Update all NuGet Packages to latest stable version

* For Android, the Minimum Android Version for debugging is set to "Android 4.4". If you wish to lower it:
    * Right click on `kosten.Android`
    * Properties
    * Android Manifest
    * Scroll down and choose from "Minimum Android Version" (The application has been tested till Android 4.2) 

--------------
### USING SKAFFOLDER-CLI
--------------

With Skaffolder-CLI you can easily manage your Skaffolder project from command line and customize your generator template from your IDE.

Install Skaffolder-CLI with
``` bash
$ yarn install -g skaffolder-cli
```

Login running the command
``` bash
$ sk login
```

Generate your project with the command
``` bash
$ sk generate
```

You can customize your generator template working with files in .skaffolder folder in your project root.

Please refer to https://www.yarnjs.com/package/skaffolder-cli for more information.
