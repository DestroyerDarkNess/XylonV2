# XylonV2


<img align="left" width="240" height="260" src="https://i.ibb.co/B3pMppn/Pngtree-antivirus-icon-4351716-burned.png">



## Introduction
Antivirus API that provides many features. This is a remaster of the old [Xylon Antivir](hhttps://github.com/DestroyerDarkNess/XylonAntivir).

This version contains many useful functions.

Remember to leave a Star to the Project! Thank you!

If you love this project, you should donate. It helps to continue to improve the API. <br> <br>
 [![Doate Image](https://raw.githubusercontent.com/poucotm/Links/master/image/PayPal/donate-paypal.png)][PM]


![]()

# [API v2] Xylon Antivir v1.0.0

[![Build Status](https://travis-ci.org/mailjet/mailjet-apiv3-php-simple.svg?branch=master)](https://travis-ci.org/mailjet/mailjet-apiv3-php-simple)

**Table of Contents**

![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+) **Documentation may be incomplete or confusing. If you want to collaborate, make a Pull Request.**

- [Introduction](#introduction)
  - [Prerequisites](#prerequisites)
- [Usage](#usage)
- <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki" target="_blank">WIKI</a>
  - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/3.-Index" target="_blank">Index</a>
  - Core
    - File
      - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/4.-FileDirSearcher" target="_blank">FileDirSearcher</a> ```Searchs for files and directories```
      - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/5.-FileTypeDetective" target="_blank">FileTypeDetective</a> ```Gets information about the binary header at the beginning of the file and Identifies it```
      - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/6.-InfoFile" target="_blank">InfoFile</a> ```Equivalent to System.IO.FileInfo - It is more Extended and Provides more information ```
    - Folder
      - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/7.-InfoDir" target="_blank">InfoDir</a> ```Equivalent to System.IO.DirectoryInfo - It is more Extended and Provides more information ```
    - Hash
      - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/8.-FileHashCalculator" target="_blank">FileHashCalculator</a> ```Gets the MD5 hash and all SHA types of a file```
  - Helper
    - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/9.--Paths" target="_blank">Paths</a>  ```Get some generic windows paths```
    - Util ```Some Useful Features```
  - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/90.-CARO" target="_blank">Malware Naming</a> ```Identifier Generator according to CARO Regulations (Computer Antivirus Research Organization)```
  - Engine
    - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/91.-External" target="_blank">External</a>  ```Wrappers for antivirus solutions and other command line tools```
    - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/92.-PE" target="_blank">PE</a> ```The Heart of the Xylon Engine - Scans Files and determines if it is malicious```
    - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/93.-Services" target="_blank">Services</a> ```Fully handles Windows services```
    - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/94.-String-Extractor" target="_blank">String Extract</a> ```As the name implies - Extract all text string from any File.```
    - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/95.-Watcher" target="_blank">Watcher</a> ```Process / Registry / File / Devices Monitor. in real time```
    - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/96.-WMI" target="_blank">WMI</a> ```Better known as Windows Management Instrumentation - Wrapper for Win32_StartupCommand / Win32Process / Win32_ComputerSystem```
    - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/97.-Web-Browsers" target="_blank">WebBrowser</a> ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+) **Incomplete / Early Stage of Development** ```Obtain Information from Browsers. History / Favorites / Cache. It also includes Extensions and all your information.```
  - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/98.-Manager" target="_blank">Startup Manager</a>  ```Gets all the Windows Startup items. (Registry / Folder / TaskSchedulers)```
  - <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki/99.-Registry" target="_blank">Regedit Manager</a>  ```All kinds of functions to manage the windows registry.```
- [Reporting issues](#reporting-issues)
- [Contributor](#contributors)

### Prerequisites

Make sure to have the following prerequisites:
* API Secret Key (OPTIONAL) 🔑
* .NET Framework (v. >= 4.5.2, preferably v. >= 4.6) ✔
* Your love 💝


## Installation

First clone the repository 
```
git clone https://github.com/DestroyerDarkNess/XylonV2.git
```

Add Xylonv2 to your Project through Package Manager `https://www.nuget.org/packages/XylonV2/ `
```
Install-Package XylonV2 -Version 1.0.0
```

You are now ready to go!

## Usage

You must start all the modules of the library from the method:

**Info:** You Can Enjoy the API Without a License, but it is recommended that you obtain it.

- VB
```visualbasic
XylonV2.Modules.Initialization() ' Or XylonV2.Modules.Initialization("API Key")
```

- C#
```c#
XylonV2.Modules.Initialization(); //Or XylonV2.Modules.Initialization("API Key");
```

**Be Careful:** You can use the API completely free of charge, without limitations. Sim Embargo if you want an extension / changes / modifications of any kind, you must buy the license and you will be provided with your API Key.

The benefits of acquiring your license will be explained in detail. Take a tour of the [Reference Documentation](https://github.com/DestroyerDarkNess/XylonV2/wiki) to see all available resources.

## Reporting issues

Open an issue [here](https://github.com/DestroyerDarkNess/XylonV2/issues).

## Contributors

```diff
- Destroyer : Creator and Developer.
+ Discord : 
!    Destroyer#8328
# 
@@ If you want to Contribute to the Project, Talk to me on Discord. :) @@
```

## Special thanks :
- [ElektroStudios](https://github.com/ElektroStudios): For its Snippet FileDirSearcher and other Functions.
   - Which are part of its [DevCase Framework](https://codecanyon.net/item/elektrokit-class-library-for-net/19260282)

[PM]:https://www.paypal.me/SalvadorKrilewski "PayPal"
