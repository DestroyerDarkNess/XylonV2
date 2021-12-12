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

![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+)

- [Introduction](#introduction)
  - [Prerequisites](#prerequisites)
- [Usage](#usage)
- [Examples](#examples)
  - [SendAPI](#sendapi)
    - [A function to send an email](#a-function-to-send-an-email)
    - [A function to send an email with some attachments](#a-function-to-send-an-email-with-some-attachments-absolute-paths-on-your-computer)
    - [A function to send an email with some inline attachments](#a-function-to-send-an-email-with-some-inline-attachments-absolute-paths-on-your-computer)
    - [A function to send an email with a custom ID](#a-function-to-send-an-email-with-a-custom-id-as-described-here)
    - [A function to send an email with a event payload](#a-function-to-send-an-email-with-a-event-payload-as-described-here)
  - [Account Settings](#account-settings)
    - [A function to get your profile information](#a-function-to-get-your-profile-information)
    - [A function to update the field AddressCity of your profile](#a-function-to-update-the-field-addresscity-of-your-profile)
  - [Contact & Contact Lists](#contact--contact-lists)
    - [Principle functionalities](#principle-functionalities)
      - [A function to print the list of your contacts](#a-function-to-print-the-list-of-your-contacts)
      - [A function to update your contactData resource with its ID, using arrays](#a-function-to-update-your-contactdata-resource-with-id-id-using-arrays)
      - [A function to create a list with name $Lname](#a-function-to-create-a-list-with-name-lname)
      - [A function to get a list through its ID](#a-function-to-get-a-list-with-id-listid)
      - [A function to create a contact with its email](#a-function-to-create-a-contact-with-email-cemail)
      - [A function to get the lists for a single contact with its ID](#a-function-to-get-the-lists-for-a-single-contact-which-id-is-contactid)
      - [A function to add a contact to a list through IDs](#a-function-to-add-the-contact-which-id-is-contactid-to-the-list-which-id-is-listid)
      - [A function to add a new detailed contact to a list with its ID](#a-function-to-add-the-contact-described-in-contact-to-the-list-which-id-is-listid)
      - [A function to add, remove or unsub a contact to/from detailed lists](#a-function-to-add-remove-or-unsub-the-contact-which-id-is-contactid-to--from-the-lists-contained-in-lists)
      - [A function to delete a list with its ID](#a-function-to-delete-the-list-which-id-is-listid)
      - [A function to get unsubscribed contact(s) from a list](#a-function-to-get-unsubscribed-contacts-from-a-list-with-id-listid)
      - [A function to get a contact with its ID](#a-function-to-get-a-contact-with-id-contactid)
    - [Asynchronous jobs](#asynchronous-jobs)
      - [On the contact resource](#performing-an-async-job-on-the-contact-resource)
      - [On the contactslist resource](#performing-an-async-job-on-the-contactslist-resource)
      - [Monitoring](#monitoring-an-async-job)
    - [Managing contacts in a contactslist from a CSV file](#managing-contacts-in-a-contactslist-from-a-csv-file)
      - [Step zero: CSV file structure.](#step-zero-csv-file-structure)
      - [First step: upload the data](#first-step-upload-the-data)
      - [Second step: Manage the contacts subscription to the contactslist](#second-step-manage-the-contacts-subscription-to-the-contactslist)
      - [Third step: Monitor the process](#third-step-monitor-the-process)
  - [Newsletters](#newsletters)
    - [Managing the content of a newsletter](#managing-the-content-of-a-newsletter)
    - [Scheduling a newsletter](#scheduling-a-newsletter)
    - [Sending a newsletter immediately](#sending-a-newsletter-immediately)
    - [Sending a newsletter to test recipients](#sending-a-newsletter-to-test-recipients)
    - [Duplicating an existing newsletter](#duplicating-an-existing-newsletter)
- [Filtering](#filtering)
    - [For GET requests](#for-get-requests)
    - [For POST requests](#for-post-requests)
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

```diff
- text in red
+ text in green
! text in orange
# asas
@@ text in purple (and bold)@@
```

The benefits of acquiring your license will be explained in detail. Take a tour of the [Reference Documentation](http://dev.mailjet.com/email-api/v3/apikey/) to see all available resources.





[PM]:https://www.paypal.me/SalvadorKrilewski "PayPal"
