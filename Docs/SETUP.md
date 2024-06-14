# Setting up Tinylytics

## Download the latest plugin

Go to releases and download the latest version, a .unitypackage file.
TODO

## Import the package into your project
In Unity, right click in the assets area and go to "Import Package > Import Custom Package" and import all the contents.
SCREENSHOT TODO


# Configuring your GoogleSheet database
These steps will show you how to set up a google sheet to act as your "database" to send event data to.

## Setting up the sheet

1. Click here: [Tinylytics Data Destination Template](https://docs.google.com/spreadsheets/d/1afYRzPYwN3HHg_G63SF9lM1i2gaFDpsbTZCkur6cVnk/copy "Tinylytics Data Destination Template"), then "Create Copy" to create your own copy of the template sheet
![Copying the template doc](../Docs/Imgs/Setup_copytemplate.png "Copying the template")

2. Name it whatever you’d like. You can rename it whenever you want later too, and you can move the document wherever you want as well.

3. In your new copy, go to Extensions > AppsScript
   
   ![Open AppsScript](../Docs/Imgs/Setup_openappsscript.png "Open the AppsScript editor")

   This will open a new tab, a project named Tinylytics_Instance, with a single script called PostGetHandling.gs
4. In the Apps Script window, go to Deploy > New Deployment
   ![New Deployment](../Docs/Imgs/Setup_newdeployment.png "Deploy / New Deployment")

5. That will bring up a prompt like this.
   Enter a quick description for what you’re using this for ("Gathering data!").
   Make sure “Who has Access” is set to “Anyone”.
   ![Deployment Access](../Docs/Imgs/Setup_deployaccess.png "Configuring the new deployment")
7. Then click “Deploy”
8. An Authorization Required prompt should appear. Click “Authorize Access”
  ![Authorizing Access](../Docs/Imgs/Setup_authdeployment.png "Authorizing Access")

      Note: This is authorizing this workbook's scripts to edit this particular workbook. No one else has access to your data!
10. An authorization window will appear, click "Allow"
   ![Allowing Access](../Docs/Imgs/Setup_allowaccess.png "Allowing Access")
11. After a short delay, you'll get a deployment confirmation. Click “Done” to close the deployments window. Don't worry about the deployment_id, we'll come back and copy it in a moment.
12. Back in the Apps Script window, click the dropdown at the top of the code editor, and select the “Setup” function. Then click “Run”.
    ![Running setup code](../Docs/Imgs/Setup_runsetupfunction.png "Running the setup function")

   Note: If the authorization prompt didn’t appear earlier, it should now.

13. After running the setup function, navigate again to “Deploy”, and “Manage Deployments”.
   We need the “Deployment ID”, it’s a long code of letters and numbers. Copy it.
   ![Get the deployment id](../Docs/Imgs/Setup_copydeploymentid.png "Getting the deployment ID")

   Now we go back to Unity!

## Configuring Tinylytics in Unity
