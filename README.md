# XylonV2


<img align="left" width="230" height="250" src="https://i.ibb.co/B3pMppn/Pngtree-antivirus-icon-4351716-burned.png">



## Introduction
Antivirus API that provides many features. It's a remastering of the old [Xylon Antivir](hhttps://github.com/DestroyerDarkNess/XylonAntivir) .

This Version contains many really useful functions.

Remember to leave your Star to the Project! Thank you!

Thank you for donating. It is helpful to continue to improve the API. <br> <br>
 [![Doate Image](https://raw.githubusercontent.com/poucotm/Links/master/image/PayPal/donate-paypal.png)][PM]


![]()

# [API v2] Xylon Antivir v1.0.0

[![Build Status](https://travis-ci.org/mailjet/mailjet-apiv3-php-simple.svg?branch=master)](https://travis-ci.org/mailjet/mailjet-apiv3-php-simple)

**Table of Contents**

![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+) **Documentation may be Incomplete or somewhat Confusing. If you want to collaborate, make a Pull Request**

- [Introduction](#introduction)
  - [Prerequisites](#prerequisites)
- [Usage](#usage)
- <a href="https://github.com/DestroyerDarkNess/XylonV2/wiki" target="_blank">WIKI</a>
  - <a href="http://example.com" target="_blank">Core</a>
    - <a href="http://example.com" target="_blank">File</a>
      - <a href="http://example.com" target="_blank">FileDirSearcher</a> ```Searchs for files and directories```
      - <a href="http://example.com" target="_blank">FileTypeDetective</a> ```Gets information about the binary header at the beginning of the file and Identifies it```
      - <a href="http://example.com" target="_blank">InfoFile</a> ```Equivalent to System.IO.FileInfo - It is more Extended and Provides more information ```
    - <a href="http://example.com" target="_blank">Folder</a>
      - <a href="http://example.com" target="_blank">InfoDir</a> ```Equivalent to System.IO.DirectoryInfo - It is more Extended and Provides more information ```
    - <a href="http://example.com" target="_blank">Hash</a>
      - <a href="http://example.com" target="_blank">FileHashCalculator</a> ```Gets the MD5 hash and all SHA types of a file```
  - <a href="http://example.com" target="_blank">Helper</a>
    - <a href="http://example.com" target="_blank">Paths</a>  ```Get some generic windows paths```
    - <a href="http://example.com" target="_blank">Util</a> ```Some Useful Features```
  - <a href="http://example.com" target="_blank">Malware Naming</a> ```Identifier Generator according to CARO Regulations (Computer Antivirus Research Organization)```
  - <a href="http://example.com" target="_blank">Engine</a>
    - <a href="http://example.com" target="_blank">External</a>  ```Wrappers for antivirus solutions and other command line tools```
    - <a href="http://example.com" target="_blank">PE</a> ```The Heart of the Xylon Engine - Scans Files and determines if it is malicious```
    - <a href="http://example.com" target="_blank">Services</a> ```Fully handles Windows services```
    - <a href="http://example.com" target="_blank">String Extract</a> ```As the name implies - Extract all text string from any File.```
    - <a href="http://example.com" target="_blank">Watcher</a> ```Process / Registry / File / Devices Monitor. in real time```
    - <a href="http://example.com" target="_blank">WMI</a> ```Better known as Windows Management Instrumentation - Wrapper for Win32_StartupCommand and Win32Process```
    - <a href="http://example.com" target="_blank">WebBrowser</a> ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+) **Incomplete / Early Stage of Development** ```Obtain Information from Browsers. History / Favorites / Cache. It also includes Extensions and all your information.```
  - <a href="http://example.com" target="_blank">Startup Manager</a>  ```Process / Registry / File / Devices Monitor. in real time```
- [Reporting issues](#reporting-issues)

### Prerequisites

Make sure to have the following details:
* API Secret Key (OPTIONAL)
* .NET Framework (v. >= 4.5, preferably v. >= 4.6)
* This VB classes


## Installation

First clone the repository 
```
git clone https://github.com/DestroyerDarkNess/XylonV2.git
```

Add Xylonv2 to your Project through Nuget `myProjectEmailer.php`
```
dotnet install xxx
```

You are now ready to go !

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

The benefits of acquiring your license will be explained in detail. Take a tour of the [Reference Documentation](http://dev.mailjet.com/email-api/v3/apikey/) to see all available resources.

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


[PM]:https://www.paypal.me/SalvadorKrilewski "PayPal"
